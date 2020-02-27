// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
namespace Leadtools.Medical.AeManagement.DataAccessLayer
{
   public interface IAeManagementDataAccessAgent
   {
      AeInfoExtended[] GetAeTitles();
      AeInfoExtended[] GetRelatedAeTitles(string aetitle);
      AeInfoExtended[] GetRelatedAeTitles(string aetitle, int relation);
      AeInfoExtended GetAeTitle(string aetitle);

      bool Add(AeInfoExtended ae);
      void Remove(string aetitle);
      void Update(string aetitle, AeInfoExtended ae);
      bool AddReleation(string aetitle, string aerelation, int relation);
      bool RemoveRelation(string aetitle, string aerelation, int relation);
   }

#if (LEADTOOLS_V20_OR_LATER)
   public interface IAeManagementDataAccessAgent2 : IAeManagementDataAccessAgent
   {
      int GetAeTitlesCount();

      AeInfoExtended[] GetAeTitles(AeInfoExtended searchParams, Medical.DataAccessLayer.QueryPageInfo queryPageInfo);
   }
#endif 
}
