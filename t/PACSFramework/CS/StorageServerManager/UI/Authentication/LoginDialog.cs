// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using Leadtools.Medical.Winforms;
// using My.SmartCard;
using Leadtools.Dicom.AddIn;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.UserManagementDataAccessLayer;
using System.Diagnostics;

namespace Leadtools.Demos.StorageServer.UI.Authentication
{
   public partial class LoginDialog : Form
   {
      public event EventHandler<AuthenticateUserEventArgs> AuthenticateUser = delegate { };

      private BackgroundWorker _cardReaderWorker;
      private readonly List<CardUserInfo> _cardReaderArray = new List<CardUserInfo>();

      private readonly LoginType _loginType;

      private Size ? _originalCacCardSize = null;
      private Point ? _originalCacCardLocation = null;

      public string GetSelectedCacCardUser()
      {
         int index = comboBoxCacCard.SelectedIndex;
         return comboBoxCacCard.Items[index].ToString();
      }

      private LoginDialogOptions _options = LoginDialogOptions.Login;
      public LoginDialogOptions Options
      {
         get
         {
            return _options;
         }
         set
         {
            _options = value;
         }
      }

      public bool UseCardReaderCheckBox
      {
         get
         {
            return this.checkBoxCardReader.Checked;
         }
         set
         {
            this.checkBoxCardReader.Checked = value;
         }
      }

      public string RegularUsername 
      {
         get
         {
            return textBoxUserName.Text;
         }
         set
         {
            textBoxUserName.Text = value;
         }
      }

      public string GetUserName()
      {
         if (checkBoxCardReader.Checked)
         {
            // return comboBoxCacCard.SelectedItem.ToString();
            return _ediNumber;
         }
         return RegularUsername;
      }

      public string GetFriendlyName()
      {
         if (checkBoxCardReader.Checked)
         {
            return comboBoxCacCard.SelectedItem.ToString();
         }
         return RegularUsername;
      }

      private string _ediNumber = "";
      public string EdiNumber
      {
         get
         {
            return _ediNumber;
         }
         set
         {
            _ediNumber = value;
         }
      }

      public string Info
      {
         get
         {
            return labelInfo.Text;
         }
         set
         {            
            labelInfo.Text = value;
            labelInfo.Visible = !string.IsNullOrEmpty(value);
         }
      }

      public bool CanSetUserName
      {
         get
         {
            return textBoxUserName.Enabled;
         }
         set
         {
            textBoxUserName.Enabled = value;
         }
      }

      public LoginDialog()
      {
         _loginType = LoginType.UsernamePassword;
         InitializeComponent();
         Initialize();
      }

      public LoginDialog(LoginType loginType)
      {
         _loginType = loginType;
         InitializeComponent();
         Initialize();
      }

      private void buttonLogin_Click(object sender, EventArgs e)
      {
         AuthenticateUserEventArgs ea = null;
         if (checkBoxCardReader.Checked)
         {
            bool validateCardUserPinOnly = (this.Options == LoginDialogOptions.AddUser);
            CardUserInfo cardUserInfo = comboBoxCacCard.SelectedItem as CardUserInfo;
            if (cardUserInfo != null)
            {
               ea = new AuthenticateUserEventArgs(cardUserInfo.CardUserIndex, textBoxCacPin.Text, validateCardUserPinOnly);
            }
         }
         else
         {
            ea = new AuthenticateUserEventArgs(textBoxUserName.Text, textBoxPassword.Text.ToSecureString());
         }

         if (ea == null)
         {
            return;
         }

         AuthenticateUser(this, ea);
         if (ea.Cancel)
         {
            DialogResult = DialogResult.Cancel;
         }

         if (ea.InvalidCredentials)
         {
            DialogResult = DialogResult.None;
            textBoxPassword.Text = string.Empty;
            textBoxCacPin.Text = string.Empty;

            if (checkBoxCardReader.Checked )
            {
               comboBoxCacCard.Focus();
            }
            else
            {
               textBoxUserName.Focus();
            }
         }

         if (checkBoxCardReader.Checked)
         {
            this.EdiNumber = ea.EdiNumber;
         }
      }

      private void Credentials_Changed(object sender, EventArgs e)
      {
         if (this.checkBoxCardReader.Checked)
         {
            buttonLogin.Enabled = comboBoxCacCard.Items.Count > 0 && textBoxCacPin.Text.Length > 0;
         }
         else
         {
            buttonLogin.Enabled = textBoxUserName.Text.Length > 0 && textBoxPassword.Text.Length > 0;
         }

#if LEADTOOLS_V19_OR_LATER
         CardUserInfo selectedCardUser  = comboBoxCacCard.SelectedItem as CardUserInfo;
         if (selectedCardUser != null)
         {
            this.textBoxCacPin.Enabled = UserManager.IsUserCardReaderReady(selectedCardUser.CardUserIndex);
         }
#endif
      }

      private void LoginDialog_Shown(object sender, EventArgs e)
      {
         if (Options == LoginDialogOptions.Login)
         {
            if (_originalCacCardSize.HasValue == false)
               _originalCacCardSize = comboBoxCacCard.Size;

            if (_originalCacCardLocation.HasValue == false)
               _originalCacCardLocation = comboBoxCacCard.Location;

         }

         if (textBoxUserName.Text.Length > 0)
         {
            textBoxPassword.Focus();
         }
      }

      private void Initialize()
      {
#if LEADTOOLS_V19_OR_LATER
         _cardReaderWorker = new BackgroundWorker();
         _cardReaderWorker.DoWork += new DoWorkEventHandler(_cardReaderWorker_DoWork);
         _cardReaderWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_cardReaderWorker_RunWorkerCompleted);
         _cardReaderWorker.WorkerReportsProgress = false;
         _cardReaderWorker.WorkerSupportsCancellation = false;
#endif

         switch (_loginType)
         {
            case LoginType.None:
            case LoginType.UsernamePassword:
               this.checkBoxCardReader.Checked = false;
               this.checkBoxCardReader.Visible = false;
               this.panelCacCard.Visible = false;
               this.panelUsernamePassword.Visible = true;
               break;

            case LoginType.SmartcardPin:
               this.checkBoxCardReader.Checked = true;
               this.checkBoxCardReader.Visible = false;
               this.panelCacCard.Visible = true;
               this.panelUsernamePassword.Visible = false;
               break;

            case LoginType.Both:
               this.checkBoxCardReader.Checked = false;
               this.checkBoxCardReader.Visible = true;
               this.panelCacCard.Visible = true;
               this.panelUsernamePassword.Visible = true;
               break;
         }

         UpdateUI();
      }

#if LEADTOOLS_V19_OR_LATER
      void _cardReaderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         comboBoxCacCard.Items.Clear();
         if (_cardReaderArray.Count == 0)
         {
            Info = "No Smart Card Readers Detected";
            comboBoxCacCard.Enabled = false;
            textBoxCacPin.Enabled = false;
         }
         else
         {
            List<User> users = UserManager.GetUsers(true);
            foreach(CardUserInfo cardUserInfo in _cardReaderArray)
            {
               if (Options == LoginDialogOptions.Login)
               {
                  comboBoxCacCard.Items.Add(cardUserInfo);
               }
               else
               {
                  // Add only the users not already in the database
                  int index = users.FindIndex(f => f.FriendlyName == cardUserInfo.FriendlyName);
                  if (index < 0)
                  {
                     comboBoxCacCard.Items.Add(cardUserInfo);
                  }
               }
            }
            if (comboBoxCacCard.Items.Count > 0)
            {
               comboBoxCacCard.SelectedIndex = 0;
               this.textBoxCacPin.Enabled = true;
               comboBoxCacCard.Enabled = true;
            }
            else
            {
               this.textBoxCacPin.Enabled = false;
               comboBoxCacCard.Enabled = false;
            }
         }
         this.checkBoxCardReader.Enabled = true;
         this.panelCacCard.Enabled = true;
         Credentials_Changed(sender, e);
      }

      void _cardReaderWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         ReadSmartCardsThread();
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      private void UpdateUI()
      {
         bool useCardReader = checkBoxCardReader.Checked;
         panelUsernamePassword.Visible = !useCardReader;
         panelCacCard.Visible = useCardReader;

         if (useCardReader)
         {
            if (_cardReaderWorker.IsBusy == false)
            {
               this.checkBoxCardReader.Enabled = false;
               this.panelCacCard.Enabled = false;
               _cardReaderWorker.RunWorkerAsync();
            }
         }
      }

      private void checkBoxCardReader_CheckedChanged(object sender, EventArgs e)
      {
         this.buttonLogin.Enabled = false;
         Info = string.Empty;
         UpdateUI();

         if (checkBoxCardReader.Checked == false)
         {
            Credentials_Changed(sender, e);
         }
      }
#if LEADTOOLS_V19_OR_LATER
      private void ReadSmartCardsThread()
      {
         _cardReaderArray.Clear();

         List<string> cardUserList  = UserManager.GetCardReaderNames();

         for(int index = 0; index < cardUserList.Count; index++)
         {
            string cardUserName = cardUserList[index];
            CardUserInfo cardUserInfo = new CardUserInfo(index, cardUserName);
            _cardReaderArray.Add(cardUserInfo);
         }
      }
#endif

      private int _refreshCounter = 0;
      private void buttonRefresh_Click(object sender, EventArgs e)
      {
         _refreshCounter++;
         UpdateUI();
      }


      private static int _doubleClicksSequence = 0;

      private void labelSelectCard_DoubleClick(object sender, EventArgs e)
      {
         if (_refreshCounter != 3)
            return;
         _doubleClicksSequence = 1;
      }

      private void labelPinNumber_DoubleClick(object sender, EventArgs e)
      {
         if (_refreshCounter != 3)
            return;
         if (_doubleClicksSequence == 1)
         {
            _doubleClicksSequence = 2;
         }
         else
         {
            _doubleClicksSequence = 0;
         }
      }

      private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         if (_refreshCounter != 3)
            return;
         if (_doubleClicksSequence == 2)
         {
            checkBoxCardReader.Visible = true;
         }
         _doubleClicksSequence = 0;
      }

   }

   public enum LoginDialogOptions
   {
      Login = 1,
      AddUser = 2,
   }

   public class CardUserInfo
   {
      private int _cardUserIndex = -1;
      private string _friendlyName = string.Empty;
      private string _ediNumber = string.Empty;

      public CardUserInfo(int cardUserIndex, string cardUserName)
      {
         CardUserIndex = cardUserIndex;
         FriendlyName = cardUserName;
      }

      public int CardUserIndex
      {
         get { return _cardUserIndex; }
         set { _cardUserIndex = value; }
      }

      public string FriendlyName
      {
         get { return _friendlyName; }
         set { _friendlyName = value; }
      }

      public string EdiNumber
      {
         get { return _ediNumber; }
         set { _ediNumber = value; }
      }

      public override string ToString()
      {
         return FriendlyName;
      }
   }

}
