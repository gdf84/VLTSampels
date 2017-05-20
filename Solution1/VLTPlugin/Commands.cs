using Autodesk.Connectivity.Explorer.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTPlugin {
    public static class Commands {

        public static void HelloWorld(object sender, CommandItemEventArgs e) {
            System.Windows.Forms.MessageBox.Show("Hello world!!!");
        }

        public static void SomeCommand(object sender, CommandItemEventArgs e) {
            Main.VaultManager.CreateFolderInRoot(Guid.NewGuid().ToString());
        }
    }
}
