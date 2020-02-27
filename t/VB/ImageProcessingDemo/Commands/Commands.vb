' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO

Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Utilities
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.SpecialEffects
Imports Leadtools.ImageProcessing.Color

#If Not LEADTOOLS_V20_OR_LATER Then
Imports VignetteCommand = Leadtools.ImageProcessing.SpecialEffects.VignnetCommand
#End If

Namespace ImageProcessingDemo
   Public Class FrequencyFilterMask : Inherits FastFourierTransformCommand
      Public Overrides Function ToString() As String
         Return "Frequency Filter Mask"
      End Function
   End Class

   Public Class PerimeterLength : Inherits AgingCommand
      Public Overrides Function ToString() As String
         Return "Perimeter Length"
      End Function
   End Class

   Public Class FeretsDiameter : Inherits AgingCommand
      Public Overrides Function ToString() As String
         Return "Ferets Diameter"
      End Function
   End Class

   Public Class IsRegistrationMark : Inherits AgingCommand
      Public Overrides Function ToString() As String
         Return "Is Registration Mark"
      End Function
   End Class

   Public Enum CommandImage
      None
      ImageProcessingDemo__Image1_jpg
      ImageProcessingDemo__Image2_jpg
      ImageProcessingDemo__Image3_jpg
      ImageProcessingDemo__Image4_tif
      ImageProcessingDemo__Fruits_jpg
      Eye_gif
      IMAGE2_dcm
      Forms__MasterForm____Sets__OCR__FFC___107_tif
      ImageProcessingDemo__NaturalFruits_jpg
      ImageProcessingDemo__GrayFruit_cmp
      ImageProcessingDemo__Ulay3_Bmp
      ImageProcessingDemo__Beauty16_jpg
      RGSRef_cmp
      RGSTest_cmp
      ImageProcessingDemo__AlmostBlank_tif
      ImageProcessingDemo__AutoCropExample_jpg
      ImageProcessingDemo__Ani_gif
      ImageProcessingDemo__FadeMask_bmp
      ImageProcessingDemo__FourierTransform_jpg
      clean_tif
      ImageProcessingDemo__FreqFilterMask_jpg
      IMAGE3_dcm
      Slice_tif
      redeye_cmp
   End Enum

   Public Structure CommandProperties
      Private _type As Type
      Private _beforeImage As CommandImage
      Private _afterImage As CommandImage
      Private _hasdialog As Boolean

      Public Shared ReadOnly Property Empty() As CommandProperties
         Get
            Return New CommandProperties(Nothing, CommandImage.None, CommandImage.None, False)
         End Get
      End Property

      Public Sub New(ByVal t As Type, ByVal beforeImage_Renamed As CommandImage, ByVal afterImage_Renamed As CommandImage, ByVal Hasdialog_Renamed As Boolean)
         _type = t
         _beforeImage = beforeImage_Renamed
         _afterImage = afterImage_Renamed
         _hasdialog = Hasdialog_Renamed
         _imagesFolder = Nothing
      End Sub

      Public ReadOnly Property Type() As Type
         Get
            Return _type
         End Get
      End Property

      Public ReadOnly Property BeforeImage() As CommandImage
         Get
            Return _beforeImage
         End Get
      End Property

      Public ReadOnly Property AfterImage() As CommandImage
         Get
            Return _afterImage
         End Get
      End Property

      Public ReadOnly Property HasDialog() As Boolean
         Get
            Return _hasdialog
         End Get
      End Property

      Public Overrides Function ToString() As String
         If Type.Name = "String" Then 'Add Border
            Return "Add border"
         End If

         Dim command As RasterCommand = TryCast(Activator.CreateInstance(Type), RasterCommand)
         Return command.ToString()
      End Function

      Private Shared _imagesFolder As String

      'Get the image file name for this command
      Public Shared Function GetImageNameFileName(ByVal cmdImage As CommandImage) As String
         If cmdImage <> CommandImage.None Then
            If _imagesFolder Is Nothing Then
               _imagesFolder = DemosGlobal.ImagesFolder
            End If

            If (cmdImage = CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif) Then
               cmdImage = CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif
            End If

            Dim name As String = cmdImage.ToString().Replace("____", " ")
            Dim name2 As String = name.Replace("___", "-")
            Dim name3 As String = name2.Replace("__", "\")
            Dim name4 As String = name3.Replace("_", ".")
            Dim fullPath As String = Path.Combine(_imagesFolder, "")
            fullPath = Path.Combine(fullPath, name4)

            Return fullPath
         Else
            Return String.Empty
         End If
      End Function

      Private Shared _baseCommands() As CommandProperties = _
         { _
         New CommandProperties(GetType(ChangeViewPerspectiveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(ClearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
         New CommandProperties(GetType(CloneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.None, False), _
         New CommandProperties(GetType(ColorResolutionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(CombineFastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg, False), _
         New CommandProperties(GetType(CombineWarpCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg, False), _
         New CommandProperties(GetType(CopyDataCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg, False), _
         New CommandProperties(GetType(CopyRectangleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
         New CommandProperties(GetType(CropCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(FillCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(FlipCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
         New CommandProperties(GetType(GrayscaleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(ResizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image3_jpg, True), _
         New CommandProperties(GetType(RotateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
         New CommandProperties(GetType(ShearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
         New CommandProperties(GetType(SizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True) _
         }

      Private Shared _effectsCommands() As CommandProperties = _
      { _
      New CommandProperties(GetType(AgingCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(AddCommand), CommandImage.ImageProcessingDemo__Image4_tif, CommandImage.None, False), _
      New CommandProperties(GetType(AddNoiseCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(PerimeterLength), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(IsRegistrationMark), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FeretsDiameter), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(AverageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(DeskewCommand), CommandImage.clean_tif, CommandImage.clean_tif, True), _
      New CommandProperties(GetType(DespeckleCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(EmbossCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(MedianCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(MosaicCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(SharpenCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(AutoCropRectangleCommand), CommandImage.ImageProcessingDemo__AutoCropExample_jpg, CommandImage.ImageProcessingDemo__AutoCropExample_jpg, False), _
      New CommandProperties(GetType(OilifyCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(MinimumCommand), CommandImage.clean_tif, CommandImage.clean_tif, True), _
      New CommandProperties(GetType(MaximumCommand), CommandImage.clean_tif, CommandImage.clean_tif, True), _
      New CommandProperties(GetType(PicturizeSingleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PicturizeListCommand), CommandImage.Eye_gif, CommandImage.Eye_gif, False), _
      New CommandProperties(GetType(ContourFilterCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(WindCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RadialWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FreeHandShearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FreeHandWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ImpressionistCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(SphereCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SigmaCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(TissueEqualizeCommand), CommandImage.IMAGE2_dcm, CommandImage.IMAGE2_dcm, False), _
      New CommandProperties(GetType(RakeRemoveCommand), CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif, CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif, False), _
      New CommandProperties(GetType(AutoSegmentCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, False), _
      New CommandProperties(GetType(AnisotropicDiffusionCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, False), _
      New CommandProperties(GetType(ObjectCounterCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(MeanShiftCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, False), _
      New CommandProperties(GetType(CylinderCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(BendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PunchCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PolarCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PixelateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RadialBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RippleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SwirlCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ZoomBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DeinterlaceCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(RegionHolesRemovalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(CubismCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(GlassEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(LensFlareCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(BumpMapCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(GlowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(EdgeDetectStatisticalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(SmoothEdgesCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(PlaneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PlaneBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(TunnelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FreeRadialBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FreePlaneBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(OceanCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(LightCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DrawStarCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FunctionalLightCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DiceEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PuzzleEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RingEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SelectDataCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(AddMessageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ExtractMessageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(WaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ZoomWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(EdgeDetectEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(GaussianCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(UnsharpMaskCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ResizeRegionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(FeatherAlphaBlendCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, True), _
      New CommandProperties(GetType(AlphaBlendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, True), _
      New CommandProperties(GetType(CombineCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(AntiAliasingCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(EdgeDetectorCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(MotionBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(HalfToneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(TextureAlphaBlendCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(AddWeightedCommand), CommandImage.Eye_gif, CommandImage.None, False), _
      New CommandProperties(GetType(FastFourierTransformCommand), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg, True), _
      New CommandProperties(GetType(DiscreteFourierTransformCommand), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg, True), _
      New CommandProperties(GetType(SkeletonCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(CorrelationCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(CorrelationListCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(ObjectInformationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(StatisticsInformationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(UserFilterCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DirectionEdgeStatisticalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RevEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ShadowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SubtractBackgroundCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SegmentCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SpatialFilterCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(BinaryFilterCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(ShiftDataCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(ApplyTransformationParametersCommand), CommandImage.RGSTest_cmp, CommandImage.RGSTest_cmp, False), _
      New CommandProperties(GetType(AutoCropCommand), CommandImage.ImageProcessingDemo__AutoCropExample_jpg, CommandImage.ImageProcessingDemo__AutoCropExample_jpg, True), _
      New CommandProperties(GetType(FrequencyFilterMask), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg, False), _
      New CommandProperties(GetType(SmoothCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(LineRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(BorderRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(InvertedTextCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(DotRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(HolePunchRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif, False), _
      New CommandProperties(GetType(OffsetCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(BricksTextureCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(CanvasCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(CloudsCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(RomanMosaicCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(MosaicTilesCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(FragmentCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(VignetteCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(PerspectiveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ColoredBallsCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PointillistCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(HalfTonePatternCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ColorHalftoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ZigZagCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(HighPassCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DiffuseGlowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(DisplacementCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PerlinCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ColoredPencilCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(MaskConvolutionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(KaufmannRegionCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, False), _
      New CommandProperties(GetType(SliceCommand), CommandImage.Slice_tif, CommandImage.Slice_tif, False), _
      New CommandProperties(GetType(ResizeInterpolateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(PlasmaCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(FadedMaskCommand), CommandImage.ImageProcessingDemo__Image2_jpg, CommandImage.ImageProcessingDemo__Image2_jpg, False), _
      New CommandProperties(GetType(BlankPageDetectorCommand), CommandImage.ImageProcessingDemo__AlmostBlank_tif, CommandImage.ImageProcessingDemo__AlmostBlank_tif, True) _
      }

      Private Shared _colorCommands() As CommandProperties = _
      { _
      New CommandProperties(GetType(ColorMergeCommand), CommandImage.ImageProcessingDemo__Ani_gif, CommandImage.None, False), _
      New CommandProperties(GetType(ColorSeparateCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(ColorIntensityBalanceCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(DesaturateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SampleTargetCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(BalanceColorsCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(AdaptiveContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ChangeHueCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ChangeIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ChangeSaturationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(GammaCorrectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(HistogramContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(HistogramEqualizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(IntensityDetectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(InvertCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(PosterizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RemapIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(StretchIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(SolarizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(WindowLevelCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg, True), _
      New CommandProperties(GetType(LightControlCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(AutoBinaryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ChannelMixerCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(MultiscaleEnhancementCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ColorizeGrayCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(DigitalSubtractCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg, False), _
      New CommandProperties(GetType(ContrastBrightnessIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ApplyMathematicalLogicCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(LocalHistogramEqualizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(DynamicBinaryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RemapHueCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(GrayScaleExtendedCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(SwapColorsCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ConvertToColoredGrayCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(RemoveRedEyeCommand), CommandImage.redeye_cmp, CommandImage.redeye_cmp, True), _
      New CommandProperties(GetType(MultiplyCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, True), _
      New CommandProperties(GetType(GrayScaleToDuotoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(GrayScaleToMultitoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ColorLevelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(AutoColorLevelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(SelectiveColorCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(ColorReplaceCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ChangeHueSaturationIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(MathematicalFunctionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False), _
      New CommandProperties(GetType(ColorThresholdCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg, False), _
      New CommandProperties(GetType(ChangeContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(ConvertUnsignedToSignedCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg, True), _
      New CommandProperties(GetType(ColorCountCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg, False), _
      New CommandProperties(GetType(MinMaxBitsCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(MinMaxValuesCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None, False), _
      New CommandProperties(GetType(GammaCorrectExtendedCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, True), _
      New CommandProperties(GetType(AdjustTintCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, False) _
      }

      Public Shared ReadOnly Property BaseCommands() As CommandProperties()
         Get
            Return _baseCommands
         End Get
      End Property

      Public Shared ReadOnly Property EffectsCommands() As CommandProperties()
         Get
            Return _effectsCommands
         End Get
      End Property

      Public Shared ReadOnly Property ColorCommands() As CommandProperties()
         Get
            Return _colorCommands
         End Get
      End Property
   End Structure

   Public Structure CommandNamespace
      Private _name As String
      Private _properties As CommandProperties()

      Public Sub New(ByVal name As String, ByVal properties_Renamed As CommandProperties())
         _name = name
         _properties = properties_Renamed
      End Sub

      Public ReadOnly Property Properties() As CommandProperties()
         Get
            Return _properties
         End Get
      End Property

      Public Overrides Function ToString() As String
         Return _name
      End Function

      Public Shared ReadOnly Property Namespaces() As CommandNamespace()
         Get
            Return _namespaces
         End Get
      End Property

      Public Shared ReadOnly _namespaces() As CommandNamespace = _
      { _
         New CommandNamespace("Base", CommandProperties.BaseCommands), _
         New CommandNamespace("Effects", CommandProperties.EffectsCommands), _
         New CommandNamespace("Color", CommandProperties.ColorCommands) _
      }
   End Structure
   
End Namespace
