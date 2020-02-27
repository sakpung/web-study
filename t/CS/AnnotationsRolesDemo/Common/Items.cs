// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Annotations.Engine;

namespace AnnotationsRolesDemo
{
   public sealed class CustomRoles
   {
      private CustomRoles() { }

      public const string RulersOnly = "Rulers Only";
   }

   public class CheckRoleItem
   {
      public CheckRoleItem(string role)
      {
         _role = role;
      }

      private string _role;

      public string Role
      {
         get { return _role; }
      }

      public override string ToString()
      {
         string role;
         switch (_role)
         {
            case AnnRoles.View:
               role = "View";
               break;

            case AnnRoles.ViewAll:
               role = "View All";
               break;

            case AnnRoles.Edit:
               role = "Edit";
               break;

            case AnnRoles.EditAll:
               role = "Edit All";
               break;

            case CustomRoles.RulersOnly:
               role = "Rulers Only";
               break;

            default:
               role = "Full Control";
               break;
         }
         return role;//return base.ToString();
      }
   }

   public class UserItem
   {
      public UserItem(string name)
      {
         _userName = name;
      }
      string _userName;

      public string Name
      {
         get { return _userName; }
      }

      AnnRoles _roles = new AnnRoles();
      public AnnRoles Roles
      {
         get
         {
            return _roles;
         }
      }

      public override string ToString()
      {
         return _userName;
      }
   }

   public class GroupItem
   {
      AnnRoles _roles = null;
      public GroupItem(string name)
      {
         _groupName = name;
         _roles = new AnnRoles();
      }

      public GroupItem(string name, AnnRoles roles)
      {
         _groupName = name;
         _roles = roles;
      }

      string _groupName;

      public string Name
      {
         get { return _groupName; }
      }

      
      public AnnRoles Roles
      {
         get
         {
            return _roles;
         }
      }

      public override string ToString()
      {
         return _groupName;
      }
   }
}
