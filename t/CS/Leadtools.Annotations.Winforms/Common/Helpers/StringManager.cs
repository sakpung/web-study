// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Resources;

namespace Leadtools.Annotations.WinForms
{
   public class StringManager
   {
      public enum Id
      {
         // Exceptions
         InvalidFormatException,

         // General
         Error,
         OK,
         Cancel,
         Apply,
         AlphaLabel,
         BrowseButton,

         // Fill Mode
         AlternateFillMode,
         WindingFillMode,

         // Hatch Style
         BackwardDiagonalHatchStyle,
         CrossHatchStyle,
         DarkDownwardDiagonalHatchStyle,
         DarkHorizontalHatchStyle,
         DarkUpwardDiagonalHatchStyle,
         DarkVerticalHatchStyle,
         DashedDownwardDiagonalHatchStyle,
         DashedHorizontalHatchStyle,
         DashedUpwardDiagonalHatchStyle,
         DashedVerticalHatchStyle,
         DiagonalBrickHatchStyle,
         DiagonalCrossHatchStyle,
         DivotHatchStyle,
         DottedDiamondHatchStyle,
         DottedGridHatchStyle,
         ForwardDiagonalHatchStyle,
         HorizontalHatchStyle,
         HorizontalBrickHatchStyle,
         LargeCheckerBoardHatchStyle,
         LargeConfettiHatchStyle,
         LargeGridHatchStyle,
         LightDownwardDiagonalHatchStyle,
         LightHorizontalHatchStyle,
         LightUpwardDiagonalHatchStyle,
         LightVerticalHatchStyle,
         MaxHatchStyle,
         MinHatchStyle,
         NarrowHorizontalHatchStyle,
         NarrowVerticalHatchStyle,
         OutlinedDiamondHatchStyle,
         Percent05HatchStyle,
         Percent10HatchStyle,
         Percent20HatchStyle,
         Percent25HatchStyle,
         Percent30HatchStyle,
         Percent40HatchStyle,
         Percent50HatchStyle,
         Percent60HatchStyle,
         Percent70HatchStyle,
         Percent75HatchStyle,
         Percent80HatchStyle,
         Percent90HatchStyle,
         PlaidHatchStyle,
         ShingleHatchStyle,
         SmallCheckerBoardHatchStyle,
         SmallConfettiHatchStyle,
         SmallGridHatchStyle,
         SolidDiamondHatchStyle,
         SphereHatchStyle,
         TrellisHatchStyle,
         VerticalHatchStyle,
         WaveHatchStyle,
         WeaveHatchStyle,
         WideDownwardDiagonalHatchStyle,
         WideUpwardDiagonalHatchStyle,
         ZigZagHatchStyle,

         // String Alignment
         NearStringAlignment,
         CenterStringAlignment,
         FarStringAlignment,

         // Dash Style
         SolidDashStyle,
         DotDashStyle,
         DashDashStyle,
         DashDotDashStyle,
         DashDotDotDashStyle,
         CustomDashStyle,

         // AnnTextRotate
         TextRotate0,
         TextRotate90,
         TextRotate180,
         TextRotate270,

         // Unit
         DisplayUnit,
         DocumentUnit,
         SmartEnglishUnit,
         SmartMetricUnit,
         InchUnit,
         MillimeterUnit,
         PixelUnit,
         PointUnit,
         FeetUnit,
         YardUnit,
         MicrometerUnit,
         CentimeterUnit,
         MeterUnit,
         TwipUnit,

         // UnitAbbreviation
         DisplayUnitAbbreviation,
         DocumentUnitAbbreviation,
         SmartEnglishUnitAbbreviation,
         SmartMetricUnitAbbreviation,
         InchUnitAbbreviation,
         MillimeterUnitAbbreviation,
         PixelUnitAbbreviation,
         PointUnitAbbreviation,
         FeetUnitAbbreviation,
         YardUnitAbbreviation,
         MicrometerUnitAbbreviation,
         CentimeterUnitAbbreviation,
         MeterUnitAbbreviation,
         TwipUnitAbbreviation,

         // AngularUnit
         RadianAngularUnit,
         DegreeAngularUnit,

         // AngularUnitAbbreviation
         RadianAngularUnitAbbreviation,
         DegreeAngularUnitAbbreviation,

         // DrawDesigner
         TextPointerDrawDesignerDefaultText,
         TextDrawDesignerDefaultText,

         // Object names
         DefaultObjectName,
         GroupObjectName,
         SelectObjectName,
         LineObjectName,
         RectangleObjectName,
         EllipseObjectName,
         PolylineObjectName,
         PolygonObjectName,
         CurveObjectName,
         ClosedCurveObjectName,
         PointerObjectName,
         FreehandObjectName,
         HiliteObjectName,
         TextObjectName,
         TextRollupObjectName,
         TextPointerObjectName,
         NoteObjectName,
         StampObjectName,
         RubberStampObjectName,
         HotspotObjectName,
         FreehandHotspotObjectName,
         ButtonObjectName,
         PointObjectName,
         RulerObjectName,
         PolyRulerObjectName,
         ProtractorObjectName,
         CrossProductObjectName,
         RedactionObjectName,
         EncryptObjectName,
         AudioObjectName,

         // ContextMenus
         CutContextMenu,
         CopyContextMenu,
         DeleteContextMenu,
         BringToFrontContextMenu,
         SendToBackContextMenu,
         BringToFirstContextMenu,
         SendToLastContextMenu,
         FlipContextMenu,
         ReverseContextMenu,
         LockContextMenu,
         UnlockContextMenu,
         ResetRotatePointsContextMenu,
         PropertiesContextMenu,
         GroupContextMenu,
         UngroupContextMenu,
         PlayContextMenu,
         UndoContextMenu,
         RedoContextMenu,
         PasteContextMenu,
         SelectAllContextMenu,
         UseRotateControlPointsContextMenu,
         DefaultPropertiesContextMenu,
         ApplyEncryptorContextMenu,
         ApplyDecryptorContextMenu,
         FixedPointerContextMenu,
         RealizeContextMenu,
         RestoreContextMenu,
         ExpandedContextMenu,
         DeleteControlPointContextMenu,
         AddControlPointContextMenu,
         CalibrateContextMenu,

         // RubberStamp names
         ApprovedRubberStamp,
         AssignedRubberStamp,
         CheckedRubberStamp,
         ClientRubberStamp,
         CopyRubberStamp,
         DraftRubberStamp,
         ExtendedRubberStamp,
         FaxRubberStamp,
         FaxedRubberStamp,
         ImportantRubberStamp,
         InvoiceRubberStamp,
         NoticeRubberStamp,
         OfficialRubberStamp,
         OnFileRubberStamp,
         PaidRubberStamp,
         PassedRubberStamp,
         PendingRubberStamp,
         ProcessedRubberStamp,
         ReceivedRubberStamp,
         RejectedRubberStamp,
         ReleaseRubberStamp,
         SentRubberStamp,
         ShippedRubberStamp,
         TopSecretRubberStamp,
         UrgentRubberStamp,
         VoidRubberStamp,

         // Password Dialog
         PasswordDialogLockCaption,
         PasswordDialogUnlockCaption,
         PasswordDialogPasswordLabel,

         // PictureBox
         PictureBoxTransparentLabel,
         PictureBoxColorLabel,
         PictureBoxTransparentModeNone,
         PictureBoxTransparentModeUseColor,
         PictureBoxTransparentModeTopLeftPixel,
         PictureBoxNoImage,
         PictureBoxOpenFileDialogFilter,
         PictureBoxOpenFileDialogErrorMessage,
         PictureBoxBrowseButtonToolTip,
         PictureBoxNoImageButtonToolTip,
         PictureBoxDefaultButtonToolTip,

         // ColorPickerDialog
         ColorPickerDialogCaption,
         ColorPickerDialogCustom,
         ColorPickerDialogWeb,
         ColorPickerDialogSystem,

         // Properties Dialog
         PropertiesDialogCaption,

         // Hyperlink Tab Page
         HyperlinkTabCaption,
         HyperlinkTabHyperlinkLabel,

         // Polygon Tab Page
         PolygonTabCaption,
         PolygonTabClosedCheckBox,
         PolygonTabFillModeLabel,

         // Brush Tab Page
         BrushTabCaption,
         BrushTabUseBrushCheckBox,
         BrushTabTypeLabel,
         BrushTabForeColorLabel,
         BrushTabBackColorLabel,
         BrushTabHatchStyleLabel,
         BrushTabTypeSolid,
         BrushTabTypeHatch,
         BrushTabTypeCustom,

         // Font Tab
         FontTabCaption,
         FontTabFontLabel,
         FontTabChangeButton,
         FontTabSampleGroupBox,
         FontTabSampleText,

         // Name Tab
         NameTabCaption,
         NameTabShowNameCheckBox,
         NameTabNameLabel,
         NameTabXOffsetLabel,
         NameTabYOffsetLabel,
         NameTabNameRestrictCheckBox,
         NameTabFontLabel,
         NameTabChangeButton,
         NameTabSampleGroupBox,
         NameTabSampleText,
         NameTabForeColorLabel,
         NameTabBackColorLabel,

         // Audio Tab
         AudioTabCaption,
         AudioTabFileNameLabel,
         AudioTabPlayButton,
         AudioTabOpenFileDialogFilter,

         // Text Tab
         TextTabCaption,
         TextTabTextLabel,
         TextTabHorizontalAlignmentLabel,
         TextTabVerticalAlignmentLabel,
         TextTabColorLabel,
         TextTabEdgeMarginLabel,
         TextTabRotateLabel,
         TextTabFixedPointerCheckBox,
         TextTabExpandedCheckBox,

         // Pen Tab
         PenTabCaption,
         PenTabUsePenCheckBox,
         PenTabWidthLabel,
         PenTabColorLabel,
         PenTabDashStyleLabel,

         // Rubber Stamp Tab
         RubberStampTabCaption,
         RubberStampTabTypeLabel,

         // Pictures Tab
         PicturesTabCaption,
         PicturesTabPrimaryLabel,
         PicturesTabSecondaryLabel,

         // Encrypt Tab
         EncryptTabCaption,
         EncryptTabKeyGroupBox,
         EncryptTabTypeGroupBox,
         EncryptTabLocationGroupBox,
         EncryptTabLeftLabel,
         EncryptTabTopLabel,
         EncryptTabRightLabel,
         EncryptTabBottomLabel,
         EncryptTabEncryptor,
         EncryptTabDecryptor,

         // Picture Tab
         PictureTabCaption,

         // Protractor Tab
         ProtractorTabCaption,
         ProtractorTabAcuteCheckBox,
         ProtractorTabAngularUnitLabel,
         ProtractorTabAbbreviationLabel,
         ProtractorTabPrecisionLabel,
         ProtractorTabArcRadiusLabel,

         // Ruler Tab
         RulerTabCaption,
         RulerTabShowLengthCheckBox,
         RulerTabUnitLabel,
         RulerTabAbbreviationLabel,
         RulerTabPrecisionLabel,
         RulerTabShowGaugeCheckBox,
         RulerTabGaugeLengthLabel,
         RulerTabShowTickMarksCheckBox,
         RulerTabShowTickValueCheckBox,
         RulerTabTickMarksLengthLabel,
         RulerTabRestrictLengthCheckBox,

         // Point Tab
         PointTabCaption,
         PointTabShowPictureCheckBox,
         PointTabRadiusLabel,

         // Hilight Tab
         HiliteTabCaption,
         HiliteTabColorLabel,

         // ControlPoints Tab
         ControlPointsTabCaption,
         ControlPointsTabShowCheckBox,
         ControlPointsTabGapLabel,

         // Curve Tab
         CurveTabCaption,
         CurveTabTensionLabel,

         // Ruler Tab ( more above) 
         RulerTabCalibrateButton,

         // Calibrate Ruler Dialog
         CalibrateDialogCaption,
         CalibrateDialogHelpGroupBox,
         CalibrateDialogHelpLabel,
         CalibrateDialogLengthLabel,
         CalibrateDialogAdvancedOptionsGroupBox,
         CalibrateDialogXDpiLabel,
         CalibrateDialogYDpiLabel,
         CalibrateDialogCurrentDpiLabel,
         CalibrateDialogDpiRatioLabel,
         CalibrateDialogDpiRatioSepLabel,
         CalibrateDialogApplyNewCheckBox,
         CalibrateDialogApplyExistingCheckBox,

         // Fixed Tab
         FixedTabCaption,
         FixedTabFixedCheckBox,
         FixedTabAdjustCheckBox,
         FixedTabFixedLabel,
         FixedTabAdjustLabel,
         FixedTabHelpLabel,

         CalibrateDialogReplaceExistingRadioButton,
         CalibrateDialogAddToExistingRadioButton,
         BrushTabUseAsTextBackground,

         RichTextObjectName,
         RichTextDrawDesignerDefaultText,

         RtfCaption,
         RtfFile,
         RtfFileOpen,
         RtfFileSave,
         RtfFilePrint,
         RtfFileExit,
         RtfEdit,
         RtfEditUndo,
         RtfEditCut,
         RtfEditCopy,
         RtfEditPaste,
         RtfEditDelete,
         RtfEditSelectAll,
         RtfEditFind,
         RtfEditReplace,
         RtfFormat,
         RtfFormatFont,
         RtfFormatBackgroundColor,
         RtfFormatTextColor,
         RtfFormatBullets,
         RtfFormatNumbering,
         RtfFormatDecreaseIndent,
         RtfFormatIncreaseIndent,
         RtfFormatLeft,
         RtfFormatCenter,
         RtfFormatRight,

         RtfFilter,
         RtfExtension,
         RtfBoldToolTip,
         RtfItalicToolTip,
         RtfUnderlineToolTip,

         RtfTextColorToolTip,
         RtfBackgroundColorToolTip,

         RtfNumbersToolTip,
         RtfBulletsToolTip,
         RtfIndentRightToolTip,
         RtfIndentLeftToolTip,

         RtfRightToolTip,
         RtfLeftToolTip,
         RtfCenterToolTip,

         VideoObjectName,
         VideoTabCaption,
         VideoTabFileNameLabel,
         VideoTabOpenFileDialogFilter,
         VideoControlBalanceGroupBox,
         VideoControlLeftLabel,
         VideoControlRightLabel,
         VideoControlSpeedGroupBox,
         VideoControlMinimumText,
         VideoControlMaximumText,
         VideoControlVolumeGroupbox,
         VideoDialogCaption,
         FixedTabFixedFontSizeCheckBox,
         FixedTabFixedPenWidthCheckBox,
         FixedTabFixedFontSizeLabel,
         FixedTabFixedPenWidthLabel,

         MultimediaNotPresent,
         Warning,
         RtfTextNotFound,

         SnapToGridCaption,
         SnapToGridContextMenu,
         SnapToGridAppearanceGroupBox,
         SnapToGridShowGridCheckBox,
         SnapToGridGridColorLabel,
         SnapToGridLineStyleLabel,
         SnapToGridGridLengthLabel,
         SnapToGridLineSpacingLabel,
         SnapToGridBehaviorGroupBox,
         SnapToGridChangeOnZoomCheckBox,
         SnapToGridEnableSnapCheckBox,
         SnapToGridPropertiesContextMenu,
         ShowGridContextMenu,

         EnableObjectsAlignmentContextMenu,
         ObjectsAlignmentContextMenu,
         ObjectsAlignmentLeftsContextMenu,
         ObjectsAlignmentCentersContextMenu,
         ObjectsAlignmentRightsContextMenu,
         ObjectsAlignmentTopsContextMenu,
         ObjectsAlignmentMiddlesContextMenu,
         ObjectsAlignmentBottomsContextMenu,
         ObjectsAlignmentSameWidthContextMenu,
         ObjectsAlignmentSameHeightContextMenu,
         ObjectsAlignmentSameSizeContextMenu,
      };

      private static Dictionary<StringManager.Id, string> _dictionary;
      private static StringManager _instance;

      private static Object _lockObject = new Object();

      private StringManager()
      {
         lock (_lockObject)
         {
            if (_dictionary == null)
            {
               _dictionary = new Dictionary<Id, string>();
#if (FOR_JAPANESE)
               var rm = new ResourceManager("Leadtools.Annotations.WinForms.Strings_jpn", typeof(StringManager).Assembly);
#else
               var rm = new ResourceManager("Leadtools.Annotations.WinForms.Strings", typeof(StringManager).Assembly);
#endif
               var ids = Enum.GetValues(typeof(StringManager.Id));
               foreach (StringManager.Id i in ids)
               {
                  var str = rm.GetString(i.ToString());
                  if (str == null)
                     throw new InvalidOperationException();

                  _dictionary.Add(i, str);
               }
            }
         }
      }

      public static string GetString(Id id)
      {
         if (_instance == null)
            _instance = new StringManager();

         if (_dictionary.ContainsKey(id))
            return _dictionary[id];
         else
            return null;
      }

      public static string SetString(Id id, string newValue)
      {
         if (_instance == null)
            _instance = new StringManager();

         string oldValue = null;

         if (_dictionary.ContainsKey(id))
         {
            oldValue = _dictionary[id];
            _dictionary[id] = newValue;
         }
         else
         {
            _dictionary.Add(id, newValue);
         }

         return oldValue;
      }

      public static void Reload()
      {
         _instance = null;
      }
   }
}
