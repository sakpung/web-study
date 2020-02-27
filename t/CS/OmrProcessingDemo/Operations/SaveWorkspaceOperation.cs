using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OmrProcessingDemo.Operations
{
   class SaveWorkspaceOperation : BusyOperation
   {
      private string filename;
      private Workspace workspace;

      public SaveWorkspaceOperation(string filename, Workspace workspace)
      {
         this.filename = filename;
         this.workspace = workspace;
      }

      protected override void Run()
      {
         Progress(101, "Packaging workspace...");

         workspace.Pack(filename);

         Progress(101, "Saving...");
         BinaryFormatter bf = new BinaryFormatter();

         using (FileStream fs = File.OpenWrite(filename))
         {
            bf.Serialize(fs, workspace);
         }

         base.Run();
      }
   }
}
