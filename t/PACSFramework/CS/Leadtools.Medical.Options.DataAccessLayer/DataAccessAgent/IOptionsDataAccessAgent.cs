// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

namespace Leadtools.Medical.OptionsDataAccessLayer
{
    public interface IOptionsDataAccessAgent
    {
        T Get<T>(string key, T defaultValue, params Type[] otherTypes);
        bool OptionExits(string key);
        void Set<T>(string key, T value, params Type[] otherTypes);
        void DeleteOption(string key);
        Dictionary<string, string> GetDefaultOptions();
        void SaveDefaultOptions(Dictionary<string, string> options);
        Dictionary<string, string> GetUserOptions(string userName);
        void SetUserOptions(string userName, Dictionary<string, string> options);

        Dictionary<string, string> GetRoleOptions(string role);       
        string GetRoleOption(string role, string optionName);
        void SaveRoleOptions(string role, Dictionary<string, string> options);
        void DeleteUserOptions(string userName);
   }
}
