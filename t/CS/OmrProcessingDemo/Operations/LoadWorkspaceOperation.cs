using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OmrProcessingDemo.Operations
{
   class LoadWorkspaceOperation : BusyOperation
   {
      private string filename;
      private Workspace workspace;

      public Workspace LoadedWorkspace { get { return workspace; } }

      public LoadWorkspaceOperation(string filename)
      {
         this.filename = filename;
      }

      protected override void Run()
      {
         Progress(101, "Loading workspace file...");

         BinaryFormatter bf = new BinaryFormatter();

         using (FileStream fs = File.OpenRead(filename))
         {
            workspace = (Workspace)bf.Deserialize(fs);
         }

         Progress(101, "Unpacking...");
         workspace.Unpack();

         base.Run();
      }
   }
}
