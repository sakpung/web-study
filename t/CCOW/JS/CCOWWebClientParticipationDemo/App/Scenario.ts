// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {

   export class ActiveScenario {
      public Scenario: Scenario;

      static deserialize(input: ActiveScenario): ActiveScenario {
         var activeScenario = new ActiveScenario();
         activeScenario.Scenario = Scenario.deserialize(input.Scenario);
         return activeScenario;
      }

      static load(url: string): ActiveScenario {
         var xmlhttp = new XMLHttpRequest();
         xmlhttp.open("GET", url, false);
         xmlhttp.setRequestHeader("Access-Control-Allow-Origin", "*");
         xmlhttp.send();
         var xmlDoc = xmlhttp.responseXML;

         return this.deserialize(<ActiveScenario>this.deserializeXml(xmlDoc));
      }

      private static isContentArray(xml: Node): boolean {
         for (var i = 0; i < xml.childNodes.length; i++) {
            var item = xml.childNodes.item(i);
            if (item.nodeType == Node.TEXT_NODE)
               continue;

            for (var j = i + 1; j < xml.childNodes.length; j++) {
               var item2 = xml.childNodes.item(j);
               if (item2.nodeType == Node.TEXT_NODE)
                  continue;

               if (item.nodeName == item2.nodeName) {
                  return true;
               }
            }
         }

         return false;
      }

      private static deserializeXml(xml: Node): Object {
         var obj = {};
         if (xml.hasChildNodes()) {
            var parentNodeName = xml.nodeName;
            for (var i = 0; i < xml.childNodes.length; i++) {
               var item = xml.childNodes.item(i);
               if (item.nodeType == Node.TEXT_NODE)
                  continue;

               var isContetArray = this.isContentArray(item);
               var nodeName = item.nodeName;

               if (obj[nodeName] == undefined) {
                  if (item.childNodes.length == 1) {
                     obj[nodeName] = item.firstChild.textContent;
                  }
                  else {
                     if (isContetArray) {
                        obj[nodeName] = [];
                        for (var j = 0; j < item.childNodes.length; j++) {
                           var childItem = item.childNodes.item(j);
                           if (childItem.nodeType == 3)
                              continue;
                           obj[nodeName].push(this.deserializeXml(childItem));
                        }
                     }
                     else {
                        obj[nodeName] = this.deserializeXml(item);
                     }
                  }
               }
            }
         }
         return obj;
      }
   }

   export class Scenario {
      public Description: string;
      public MasterUserIndex: MasterUser[];
      public MasterPatientIndex: MasterPatient[];
      public Applications: CCOWApplication[];

      public toString(): string {
         if (this.Description.length > 0)
            return this.Description;

         return "No Description Provided";
      }

      static deserialize(input: Scenario): Scenario {
         var scenario = new Scenario();
         scenario.Description = input.Description.toString();
         scenario.MasterUserIndex = [];
         for (var i = 0; i < input.MasterUserIndex.length; i++) {
            var masterUser = MasterUser.deserialize(input.MasterUserIndex[i]);
            scenario.MasterUserIndex.push(masterUser);
         }
         scenario.MasterPatientIndex = [];
         for (var i = 0; i < input.MasterPatientIndex.length; i++) {
            var masterPatient: MasterPatient = MasterPatient.deserialize(input.MasterPatientIndex[i]);
            scenario.MasterPatientIndex.push(masterPatient);
         }
         scenario.Applications = [];
         for (var i = 0; i < input.Applications.length; i++) {
            var application: CCOWApplication = CCOWApplication.deserialize(input.Applications[i]);
            scenario.Applications.push(application);
         }
         return scenario;
      }
   }

   export class User {
      public Name: string;
      public Username: string;
      public Password: string;
      public DomainLogin: boolean;
      public Domain: string;

      public User() {
         this.DomainLogin = false;
      }

      public toString(): string {
         if (this.Username.length > 0)
            return this.Username;

         return "";
      }

      static deserialize(input: User): User {
         var user = new User();
         user.Name = input.Name;
         user.Username = input.Username;
         user.Password = input.Password;
         user.DomainLogin = input.DomainLogin.toString() == "true";
         user.Domain = input.Domain;
         return user;
      }
   }

   export class MasterUser extends User {
      public ApplicationUsers: ApplicationUser[];

      public toString(): string {
         if (this.Username.length > 0)
            return this.Username;

         return "";
      }

      static deserialize(input: MasterUser): MasterUser {
         var masterUser = new MasterUser();
         masterUser.Name = input.Name;
         masterUser.Username = input.Username;
         masterUser.Password = input.Password;
         masterUser.DomainLogin = input.DomainLogin;
         masterUser.Domain = input.Domain;
         masterUser.ApplicationUsers = [];
         for (var i = 0; i < input.ApplicationUsers.length; i++) {
            var appUser = ApplicationUser.deserialize(input.ApplicationUsers[i]);
            masterUser.ApplicationUsers.push(appUser);
         }
         return masterUser;
      }
   }


   export class ApplicationUser {
      public LogonName: string;
      public ApplicationName: string;

      static deserialize(input: ApplicationUser): ApplicationUser {
         var appUser = new ApplicationUser();
         appUser.LogonName = input.LogonName;
         appUser.ApplicationName = input.ApplicationName;
         return appUser;
      }
   }

   export class Patient {
      public Id: string;
      public Name: string;
      public BirthDate: string;
      public Sex: string;

      public toString(): string {
         return this.Name;
      }

      static deserialize(input: Patient) {
         var patient = new Patient();
         patient.Id = input.Id;
         patient.Name = input.Name;
         patient.BirthDate = input.BirthDate;
         patient.Sex = input.Sex;
         return patient;
      }
   }

   export class MasterPatient extends Patient {
      public ApplicationPatients: ApplicationPatient[];

      static deserialize(input: MasterPatient): MasterPatient {
         var masterPatient = new MasterPatient();
         masterPatient.Id = input.Id;
         masterPatient.Name = input.Name;
         masterPatient.BirthDate = input.BirthDate;
         masterPatient.Sex = input.Sex;
         masterPatient.ApplicationPatients = [];
         for (var i = 0; i < input.ApplicationPatients.length; i++) {
            var appUser = ApplicationPatient.deserialize(input.ApplicationPatients[i]);
            masterPatient.ApplicationPatients.push(appUser);
         }
         return masterPatient;
      }
   }

   export class ApplicationPatient {
      public ApplicationName: string;
      public PatientId: string;

      static deserialize(input: ApplicationPatient): ApplicationPatient {
         var applicationPatient = new ApplicationPatient();
         applicationPatient.ApplicationName = input.ApplicationName;
         applicationPatient.PatientId = input.PatientId;
         return applicationPatient;
      }
   }

   export class CCOWApplication {
      public Name: string;
      public Suffix: string;
      public Users: User[];
      public Patients: Patient[];

      static deserialize(input: CCOWApplication): CCOWApplication {
         var app = new CCOWApplication();
         app.Name = input.Name;
         app.Suffix = input.Suffix;
         app.Users = [];
         for (var i = 0; i < input.Users.length; i++) {
            var user = User.deserialize(input.Users[i]);
            app.Users.push(user);
         }
         app.Patients = [];
         for (var i = 0; i < input.Patients.length; i++) {
            var patient = Patient.deserialize(input.Patients[i]);
            app.Patients.push(patient);
         }
         return app;
      }
   }

}