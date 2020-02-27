// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;

using Leadtools.Demos;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Utilities;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.SpecialEffects;
using Leadtools.ImageProcessing.Color;

#if !LEADTOOLS_V20_OR_LATER
using VignetteCommand = Leadtools.ImageProcessing.SpecialEffects.VignnetCommand;
#endif

namespace ImageProcessingDemo
{
   public class FrequencyFilterMask : FastFourierTransformCommand
   {
      public override string ToString( )
      {
         return "Frequency Filter Mask";
      }
   }

   public class PerimeterLength : AgingCommand
   {
      public override string ToString( )
      {
         return "Perimeter Length";
      }
   }

   public class FeretsDiameter : AgingCommand
   {
      public override string ToString( )
      {
         return "Ferets Diameter";
      }
   }

   public class IsRegistrationMark : AgingCommand
   {
      public override string ToString( )
      {
         return "Is Registration Mark";
      }
   }

   public enum CommandImage
   {
      None,
      ImageProcessingDemo__Image1_jpg,
      ImageProcessingDemo__Image2_jpg,
      ImageProcessingDemo__Image3_jpg,
      ImageProcessingDemo__Image4_tif,
      ImageProcessingDemo__Fruits_jpg,
      Eye_gif,
      IMAGE2_dcm,
      Forms__MasterForm____Sets__OCR__FFC___107_tif,
      ImageProcessingDemo__NaturalFruits_jpg,
      ImageProcessingDemo__GrayFruit_cmp,
      ImageProcessingDemo__Ulay3_Bmp,
      ImageProcessingDemo__Beauty16_jpg,
      RGSRef_cmp,
      RGSTest_cmp,
       ImageProcessingDemo__AlmostBlank_tif,
      ImageProcessingDemo__AutoCropExample_jpg,
      ImageProcessingDemo__Ani_gif,
      ImageProcessingDemo__FadeMask_bmp,
      ImageProcessingDemo__FourierTransform_jpg,
      clean_tif,
      ImageProcessingDemo__FreqFilterMask_jpg,
      IMAGE3_dcm,
      Slice_tif,
      redeye_cmp,
   }

   public struct CommandProperties
   {
      private Type _type;
      private CommandImage _beforeImage;
      private CommandImage _afterImage;
      private bool _hasdialog;

      public static CommandProperties Empty
      {
         get
         {
            return new CommandProperties(null, CommandImage.None, CommandImage.None,false);
         }
      }

      public CommandProperties(Type t, CommandImage beforeImage, CommandImage afterImage, bool Hasdialog)
      {
         _type = t;
         _beforeImage = beforeImage;
         _afterImage = afterImage;
         _hasdialog = Hasdialog;
      }

      public Type Type
      {
         get
         {
            return _type;
         }
      }

      public CommandImage BeforeImage
      {
         get
         {
            return _beforeImage;
         }
      }

      public CommandImage AfterImage
      {
         get
         {
            return _afterImage;
         }
      }

      public bool HasDialog
      {
         get
         {
            return _hasdialog;
         }
      }

      public override string ToString( )
      {
         if (Type.Name == "String")//Add Border
            return "Add border";          
         
         RasterCommand command = Activator.CreateInstance(Type) as RasterCommand;
#if !LEADTOOLS_V17_OR_LATER
         if (command is DeskewCheckCommand)
            return "Deskew Check";
#endif         
         return command.ToString();
      }

      private static string _imagesFolder = null;

      //Get the image file name for this command
      public static string GetImageNameFileName(CommandImage cmdImage)
      {
         if(cmdImage != CommandImage.None)
         {
            if(_imagesFolder == null)
               _imagesFolder = DemosGlobal.ImagesFolder;


            string name = cmdImage.ToString().Replace("____", " ");
            string name2 = name.Replace("___", "-");
            string name3 = name2.Replace("__", "\\");
            string name4 = name3.Replace("_", ".");
            string fullPath = Path.Combine(_imagesFolder, "");
            fullPath = Path.Combine(fullPath, name4);

            return fullPath;
         }
         else
            return string.Empty;
      }

      public static CommandProperties[] BaseCommands
      {
         get
         {
            return _baseCommands;
         }
      }

      private readonly static CommandProperties[] _baseCommands =
      {
         new CommandProperties(typeof(ChangeViewPerspectiveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ClearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(CloneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.None,false),
         new CommandProperties(typeof(ColorResolutionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(CombineFastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg,false),
         new CommandProperties(typeof(CombineWarpCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg,false),
         new CommandProperties(typeof(CopyDataCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image2_jpg,false),
         new CommandProperties(typeof(CopyRectangleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(CropCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(FillCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(FlipCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(GrayscaleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ResizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image3_jpg,true),
         new CommandProperties(typeof(RotateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ShearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
      };

      public static CommandProperties[] EffectsCommands
      {
         get
         {
            return _effectsCommands;
         }
      }

      private readonly static CommandProperties[] _effectsCommands =
      {
         new CommandProperties(typeof(AgingCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(AddCommand), CommandImage.ImageProcessingDemo__Image4_tif, CommandImage.None,false),
         new CommandProperties(typeof(AddNoiseCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(PerimeterLength), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(IsRegistrationMark), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FeretsDiameter), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(AverageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(DeskewCommand), CommandImage.clean_tif, CommandImage.clean_tif,true),
         new CommandProperties(typeof(DespeckleCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(EmbossCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(MedianCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(MosaicCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(SharpenCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(AutoCropRectangleCommand), CommandImage.ImageProcessingDemo__AutoCropExample_jpg, CommandImage.ImageProcessingDemo__AutoCropExample_jpg,false),
         new CommandProperties(typeof(OilifyCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(MinimumCommand), CommandImage.clean_tif, CommandImage.clean_tif,true),
         new CommandProperties(typeof(MaximumCommand), CommandImage.clean_tif, CommandImage.clean_tif,true),
         new CommandProperties(typeof(PicturizeSingleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PicturizeListCommand), CommandImage.Eye_gif, CommandImage.Eye_gif,false),
         new CommandProperties(typeof(ContourFilterCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(WindCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RadialWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FreeHandShearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FreeHandWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ImpressionistCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(SphereCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(CylinderCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(BendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PunchCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PolarCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PixelateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RadialBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RippleCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SwirlCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ZoomBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DeinterlaceCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(RegionHolesRemovalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(CubismCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(GlassEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(LensFlareCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(BumpMapCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(GlowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(EdgeDetectStatisticalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(SmoothEdgesCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(PlaneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PlaneBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(TunnelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FreeRadialBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FreePlaneBendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(OceanCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(LightCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DrawStarCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(FunctionalLightCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DiceEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PuzzleEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RingEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SelectDataCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None,false),
         new CommandProperties(typeof(AddMessageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ExtractMessageCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(WaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ZoomWaveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(EdgeDetectEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(GaussianCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(UnsharpMaskCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ResizeRegionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true) ,
         new CommandProperties(typeof(FeatherAlphaBlendCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,true),
         new CommandProperties(typeof(AlphaBlendCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,true),
         new CommandProperties(typeof(CombineCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(AntiAliasingCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(EdgeDetectorCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(MotionBlurCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(HalfToneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(TextureAlphaBlendCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(AddWeightedCommand), CommandImage.Eye_gif, CommandImage.None,false),
         new CommandProperties(typeof(FastFourierTransformCommand), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg,true),
         new CommandProperties(typeof(DiscreteFourierTransformCommand), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg,true),
         new CommandProperties(typeof(SkeletonCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(CorrelationCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(CorrelationListCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(ObjectInformationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(StatisticsInformationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(UserFilterCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DirectionEdgeStatisticalCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RevEffectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ShadowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SubtractBackgroundCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SegmentCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SpatialFilterCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(BinaryFilterCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(ShiftDataCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None,false),
         new CommandProperties(typeof(ApplyTransformationParametersCommand), CommandImage.RGSTest_cmp, CommandImage.RGSTest_cmp,false),
         new CommandProperties(typeof(AutoCropCommand), CommandImage.ImageProcessingDemo__AutoCropExample_jpg, CommandImage.ImageProcessingDemo__AutoCropExample_jpg,true),
         new CommandProperties(typeof(FrequencyFilterMask), CommandImage.ImageProcessingDemo__FourierTransform_jpg, CommandImage.ImageProcessingDemo__FourierTransform_jpg,false),
         new CommandProperties(typeof(SmoothCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(LineRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(BorderRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(InvertedTextCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(DotRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(HolePunchRemoveCommand), CommandImage.clean_tif, CommandImage.clean_tif,false),
         new CommandProperties(typeof(OffsetCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(BricksTextureCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(CanvasCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(CloudsCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(RomanMosaicCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(MosaicTilesCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(FragmentCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(VignetteCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(PerspectiveCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ColoredBallsCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PointillistCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(HalfTonePatternCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ColorHalftoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ZigZagCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(HighPassCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DiffuseGlowCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(DisplacementCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
#if !LEADTOOLS_V17_OR_LATER
         new CommandProperties(typeof(DeskewExtendedCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true), 
#endif
         //new CommandProperties(typeof(DeskewExtendedCommand), CommandImage.clean_tif, CommandImage.clean_tif,true),
         new CommandProperties(typeof(PerlinCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ColoredPencilCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(MaskConvolutionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(KaufmannRegionCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm,false),
         new CommandProperties(typeof(SliceCommand), CommandImage.Slice_tif, CommandImage.Slice_tif,false),
         new CommandProperties(typeof(ResizeInterpolateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(PlasmaCommand),CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false), 
#if !LEADTOOLS_V17_OR_LATER
         new CommandProperties(typeof(DeskewCheckCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true), 
#endif
#if LEADTOOLS_V17_OR_LATER
                  new CommandProperties(typeof(MeanShiftCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, false),
#endif


         new CommandProperties(typeof(FadedMaskCommand),CommandImage.ImageProcessingDemo__Image2_jpg, CommandImage.ImageProcessingDemo__Image2_jpg,false),
         new CommandProperties(typeof(BlankPageDetectorCommand),CommandImage.ImageProcessingDemo__AlmostBlank_tif,CommandImage.ImageProcessingDemo__AlmostBlank_tif,true),
         #if LEADTOOLS_V16_OR_LATER
         new CommandProperties(typeof(SigmaCommand) ,CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(TissueEqualizeCommand), CommandImage.IMAGE2_dcm, CommandImage.IMAGE2_dcm,false),
         new CommandProperties(typeof(AutoSegmentCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, false),
         new CommandProperties(typeof(AnisotropicDiffusionCommand), CommandImage.IMAGE3_dcm, CommandImage.IMAGE3_dcm, false),
         new CommandProperties(typeof(RakeRemoveCommand), CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif, CommandImage.Forms__MasterForm____Sets__OCR__FFC___107_tif, false),
         new CommandProperties(typeof(ObjectCounterCommand), CommandImage.clean_tif, CommandImage.clean_tif, false),
         #endif
      };

      public static CommandProperties[] ColorCommands
      {
         get
         {
            return _colorCommands;
         }
      }

      private readonly static CommandProperties[] _colorCommands =
      {
         new CommandProperties(typeof(ColorMergeCommand), CommandImage.ImageProcessingDemo__Ani_gif, CommandImage.None,false),
         new CommandProperties(typeof(ColorSeparateCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.None,false),
         new CommandProperties(typeof(ColorIntensityBalanceCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(DesaturateCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SampleTargetCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(BalanceColorsCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(AdaptiveContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ChangeHueCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ChangeIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ChangeSaturationCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(GammaCorrectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(HistogramContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(HistogramEqualizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(IntensityDetectCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(InvertCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(PosterizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RemapIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(StretchIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(SolarizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(WindowLevelCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg,true),
         new CommandProperties(typeof(LightControlCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(AutoBinaryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ChannelMixerCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(MultiscaleEnhancementCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ColorizeGrayCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None,false),
         new CommandProperties(typeof(DigitalSubtractCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg,false),
         new CommandProperties(typeof(ContrastBrightnessIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ApplyMathematicalLogicCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(LocalHistogramEqualizeCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(DynamicBinaryCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RemapHueCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(GrayScaleExtendedCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(SwapColorsCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ConvertToColoredGrayCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(RemoveRedEyeCommand), CommandImage.redeye_cmp, CommandImage.redeye_cmp,true),
         new CommandProperties(typeof(MultiplyCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,true),
         new CommandProperties(typeof(GrayScaleToDuotoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(GrayScaleToMultitoneCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ColorLevelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(AutoColorLevelCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(SelectiveColorCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(ColorReplaceCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ChangeHueSaturationIntensityCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(MathematicalFunctionCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
         new CommandProperties(typeof(ColorThresholdCommand), CommandImage.ImageProcessingDemo__NaturalFruits_jpg, CommandImage.ImageProcessingDemo__NaturalFruits_jpg,false),
         new CommandProperties(typeof(ChangeContrastCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(ConvertUnsignedToSignedCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.ImageProcessingDemo__Beauty16_jpg,true),
         new CommandProperties(typeof(ColorCountCommand), CommandImage.ImageProcessingDemo__Fruits_jpg, CommandImage.ImageProcessingDemo__Fruits_jpg,false),
         new CommandProperties(typeof(MinMaxBitsCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None,false),
         new CommandProperties(typeof(MinMaxValuesCommand), CommandImage.ImageProcessingDemo__Beauty16_jpg, CommandImage.None,false),
         new CommandProperties(typeof(GammaCorrectExtendedCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,true),
         new CommandProperties(typeof(AdjustTintCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg,false),
      };
   }

   public struct CommandNamespace
   {
      private string _name;
      private CommandProperties[] _properties;

      public CommandNamespace(string name, CommandProperties[] properties)
      {
         _name = name;
         _properties = properties;
      }

      public CommandProperties[] Properties
      {
         get
         {
            return _properties;
         }
      }

      public override string ToString( )
      {
         return _name;
      }

      public static CommandNamespace[] Namespaces
      {
         get
         {
            return _namespaces;
         }
      }

      private readonly static CommandNamespace[] _namespaces =
      {
         new CommandNamespace("Base", CommandProperties.BaseCommands),
         new CommandNamespace("Effects", CommandProperties.EffectsCommands),
         new CommandNamespace("Color", CommandProperties.ColorCommands)
      };
   }
}
