// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;
using System.IO;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Authentication info
   /// </summary>
   [DataContract]
   [Serializable]
   public class AuthenticationInfo 
   {
      public AuthenticationInfo()
      {
      }
      //optimized serialization
      public void WriteToStream(Stream stream)
      {
         using (var writer = new BinaryWriter(stream))
         {
            writer.Write(string.IsNullOrEmpty(UserName) ? "" : UserName);
            writer.Write(ExpirationTime.ToBinary());
            writer.Write((uint)PermissionsToken);
            writer.Write(string.IsNullOrEmpty(Cookie) ? "" : Cookie);
            writer.Write(string.IsNullOrEmpty(ImpersonatedUserName) ? "" : ImpersonatedUserName); 
         }
      }
      public void ReadFromStream(Stream stream)
      {
         using (var reader = new BinaryReader(stream))
         {
            UserName = reader.ReadString();
            ExpirationTime = DateTime.FromBinary(reader.ReadInt64());
            PermissionsToken = reader.ReadUInt32();
            Cookie = reader.ReadString();
            ImpersonatedUserName = reader.ReadString();
         }
      }

      /// <summary>
      /// The user name
      /// </summary>
      [DataMember]
      public string UserName { get; set; }

      /// <summary>
      /// Cookie expiration time in UTC (Universal time)
      /// </summary>
      [DataMember]
      public DateTime ExpirationTime 
      { 
         get
         {
            return _expirationTime ;
         }

         set
         {
            _expirationTime = value ;
         }
      }
      
      [DataMember]
      public string Expires 
      {
         get
         {
            return _expirationTime.ToString ( ) ;
         }

         set
         {
            _expirationTime = DateTime.Parse ( value ) ;
         }
      }

      private DateTime _expirationTime ;

      [DataMember]
      public UInt32 PermissionsToken
      {
         get
         {
            return _permissionsToken;
         }

         set
         {
            _permissionsToken = value;
         }
      }

      private UInt32 _permissionsToken = 0;

      [DataMember]
      public string Cookie { get; set; }

      /// <summary>
      /// The impersonated user name
      /// </summary>
      [DataMember]
      public string ImpersonatedUserName { get; set; }
   }
}
