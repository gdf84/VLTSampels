using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Connectivity.WebServicesTools;
using VLTPlugin.Interface;
using VLTPlugin.Interface.Entities;

namespace VLTPlugin
{
    public class VaultManager : IVault
    {
        public WebServiceManager webMan;

        public WebServiceManager WebMan { get { return webMan; } set { } }

        public MyFolder CreateFolderInRoot(string Name)
        {
            var root = webMan.DocumentService.GetFolderRoot();
            var newFolder = webMan.DocumentService.AddFolder(Name, root.Id, false);
            
            var cats = webMan.CategoryService.GetCategoriesByEntityClassId("FLDR", false);


            //newFolder.LfCyc.LfCycStateId;
            var someId = 123123123L;

            webMan.DocumentServiceExtensions.UpdateFolderLifeCycleStates(
                new[] { newFolder.Id}, new[] { someId }, "comment");

            return new MyFolder(newFolder);
        }

        
        public void Initialize(WebServiceManager webMan)
        {
            this.webMan = webMan;
        }
    }
}
