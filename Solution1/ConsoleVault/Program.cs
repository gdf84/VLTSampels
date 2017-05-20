using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VLTPlugin.Interface;

namespace ConsoleVault
{
    class Program
    {
        //static IVault vaultManager;
        static void Main(string[] args)
        {
            //Error = "";
            bool result = true;
            IWebServiceCredentials cred = null;

            ServerIdentities servIdent = new ServerIdentities();
            servIdent.DataServer = "Vault02";
            servIdent.FileServer = "Vault02";

            cred = new UserPasswordCredentials(servIdent,
                "Внедрение Vault", "_BIM_менеджер", "тест"); 

            var webman = new WebServiceManager(cred);

            //vaultManager.Initialize(webman);

            //vaultManager.CreateFolderInRoot($"Hi {Guid.NewGuid()}");
        }
    }
}
