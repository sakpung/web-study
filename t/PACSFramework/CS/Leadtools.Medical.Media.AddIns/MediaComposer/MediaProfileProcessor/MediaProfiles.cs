// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Media.AddIns.Composing
{
   public class MediaProfiles
   {
      public static MediaProfiles  GeneralPurposeCDInterchange        = new MediaProfiles ( Constatns.GENCD , "General Purpose CD-R" ) ;
      public static MediaProfiles  GeneralPurposeDVDInterchange       = new MediaProfiles ( Constatns.GENDVD, "General Purpose DVD-RAM" ) ;
      public static MediaProfiles  GeneralPurposeSecureCDInterchange  = new MediaProfiles ( Constatns.GENSECCD, "General Purpose Secure CD-R" ) ;
      public static MediaProfiles  GeneralPurposeSecureDVDInterchange = new MediaProfiles ( Constatns.GENSECDVD, "General Purpose Secure DVD-RAM" ) ;
      
      public MediaProfiles ( string name ) 
      : this ( name, string.Empty ) 
      {
         
      }
      
      public static MediaProfiles Parse ( string name ) 
      {
         switch ( name ) 
         {
            case Constatns.GENCD:
            {
               return GeneralPurposeCDInterchange ;
            }
            
            case Constatns.GENDVD:
            {
               return GeneralPurposeDVDInterchange ;
            }
            
            case Constatns.GENSECCD:
            {
               return GeneralPurposeSecureCDInterchange ;
            }
            
            case Constatns.GENSECDVD:
            {
               return GeneralPurposeSecureDVDInterchange ;
            }
            
            default:
            {
               return null ;
            }
         }
      }
      public MediaProfiles ( string name, string description ) 
      {
         Name = name ;
         Description = description ;
      }
      
      public string Name
      {
         get ;
         private set ;
      }
      
      public string Description
      {
         get ;
         set ;
      }
      
      private class Constatns
      {
         public const string GENCD     = "STD-GEN-CD" ;
         public const string GENDVD    = "STD-GEN-DVD-RAM" ;
         public const string GENSECCD  = "STD-GEN-SEC-CD" ;
         public const string GENSECDVD = "STD-GEN-SEC-DVD-RAM" ;
      }
   }
}
