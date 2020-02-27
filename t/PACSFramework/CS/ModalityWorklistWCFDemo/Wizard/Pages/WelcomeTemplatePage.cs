// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Wizard.Pages
{
    public partial class WelcomeTemplatePage : FirstPage
    {
        #region Public

        #region Methods

        public WelcomeTemplatePage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        #endregion

        #region Properties

        public static Image BannerImage
        {
            get
            {
                return _bannerIcon;
            }

            set
            {
                _bannerIcon = value;
            }
        }

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            try
            {
                base.OnSetActive(sender, e);


                if (!e.Cancel)
                {                    
                    if (null == RightBannerPictureBox.Image)
                    {
                        if (null != BannerImage)
                        {
                            RightBannerPictureBox.Image = BannerImage;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }


        #endregion

        #region Events

        #endregion

        #region Data Types Definition

        #endregion

        #region Callbacks

        #endregion

        #endregion

        #region Protected

        #region Methods

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Members

        #endregion

        #region Data Types Definition

        #endregion

        #endregion

        #region Private

        #region Methods

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Members

        public static Image _bannerIcon;

        #endregion

        #region Data Types Definition

        #endregion

        #endregion

        #region internal

        #region Methods

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Types Definition

        #endregion

        #region Callbacks

        #endregion

        #endregion
    }
}
