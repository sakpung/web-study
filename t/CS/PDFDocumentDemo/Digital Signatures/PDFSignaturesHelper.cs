// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Pdf;

namespace PDFDocumentDemo
{
   public class PDFSignaturesHelper
   {
      public static string GetSignedByString(string subject)
      {
         if (string.IsNullOrEmpty(subject))
            return "";

         string subjcetInfo = subject;
         if (!subject.EndsWith("/"))
            subjcetInfo += "/";

         string CN = GetSubstring(subjcetInfo, "/CN=", "/");

         string emailAddress = GetSubstring(subjcetInfo, "/emailAddress=", "/");

         string signedBy = CN + " <" + emailAddress + ">";

         return signedBy;
      }

      public static string GetSubjcetOrIssure(string descriptionInfo)
      {
         if (string.IsNullOrEmpty(descriptionInfo))
            return "";

         descriptionInfo += "/";

         string CN = "CN= " + GetSubstring(descriptionInfo, "/CN=", "/") + System.Environment.NewLine;
         string emailAddress = "emailAddress= " + GetSubstring(descriptionInfo, "/emailAddress=", "/") + System.Environment.NewLine;
         string OU = "OU= " + GetSubstring(descriptionInfo, "/OU=", "/") + System.Environment.NewLine;
         string O = "O= " + GetSubstring(descriptionInfo, "/O=", "/") + System.Environment.NewLine;
         string C = "C= " + GetSubstring(descriptionInfo, "/C=", "/");

         descriptionInfo = CN + emailAddress + OU + O + C;

         return descriptionInfo;
      }

      public static string GetKeyUsageString(int KeyUsage)
      {
         string keyUsageString = "";
         string dataSeparator = ", ";

         if ((KeyUsage & PDFSignature.KeyUsageCRLSign) == PDFSignature.KeyUsageCRLSign)
            keyUsageString += "CRL Sign" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageDataEncipherment) == PDFSignature.KeyUsageDataEncipherment)
            keyUsageString += "Data Encipherment" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageDecipherOnly) == PDFSignature.KeyUsageDecipherOnly)
            keyUsageString += "Decipher Only" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageDigitalSignature) == PDFSignature.KeyUsageDigitalSignature)
            keyUsageString += "Digital Signature" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageEncipherOnly) == PDFSignature.KeyUsageEncipherOnly)
            keyUsageString += "Encipher Only" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageKeyAgreement) == PDFSignature.KeyUsageKeyAgreement)
            keyUsageString += "Key Agreement" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageKeyCertSign) == PDFSignature.KeyUsageKeyCertSign)
            keyUsageString += "Key Certificate Sign" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageKeyEncipherment) == PDFSignature.KeyUsageKeyEncipherment)
            keyUsageString += "Key Encipherment" + dataSeparator;

         if ((KeyUsage & PDFSignature.KeyUsageNonRepudiation) == PDFSignature.KeyUsageNonRepudiation)
            keyUsageString += "Non Repudiation";

         return keyUsageString;
      }

      public static string GetSubstring(string original, string start, string end)
      {
         if (string.IsNullOrEmpty(original))
            return "";

         string substring = "";

         int startPos = 0;
         int length = 0;

         startPos = original.LastIndexOf(start) + start.Length;
         length = original.IndexOf(end, startPos) - startPos;
         if (length > 0)
         {
            substring = original.Substring(startPos, length);
         }
         else
         {
            substring = original.Substring(startPos);
         }

         return substring;
      }

      public static string InsertWhiteSpaceToString(string serialNumber)
      {
         if (string.IsNullOrEmpty(serialNumber))
            return "";

         int count = (serialNumber.Length / 2 - 1);

         for (int i = 0; i < count; i++)
         {
            int index = (2 * i) + (2 + i);
            serialNumber = serialNumber.Insert(index, " ");
         }

         return serialNumber;
      }

      public static string GetState(int state)
      {
         switch (state)
         {
            case PDFSignature.StateInvalid:
               return "INVALID";
            case PDFSignature.StateValid:
               return "VALID";
            default:
               return "UNKNOWN";
         }
      }
   }
}
