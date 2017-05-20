using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;
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

        public static void AddEnt(object sender, CommandItemEventArgs e)
        {
            var wm = Main.VaultManager.WebMan;
                       
            /// вызов диалога
            /// полечение результатов
            var entIds = e.Context.CurrentSelectionSet
                .Where(i => i.TypeId.EntityClassId == "CUSTENT")
                .Select(i=>i.Id);


            var pds = wm.PropertyService
                .GetPropertyDefinitionsByEntityClassId("CUSTENT");

            var pd = pds.First(p => p.SysName == "Name");

            //wm.PropertyService.GetProperties("CUSTENT", new long[] { 2 }, )

            PropInstParam pip = new PropInstParam() {
                PropDefId = pd.Id,
                Val = "333",
            };

            PropInstParamArray pipa = new PropInstParamArray();
            pipa.Items = new PropInstParam[] { pip };

            Main.VaultManager.WebMan.CustomEntityService
                .UpdateCustomEntityProperties(entIds.ToArray(), 
                    new PropInstParamArray[] { pipa });            
        }
    }
}
