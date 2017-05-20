using Autodesk.Connectivity.WebServicesTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTPlugin.Interface.Entities;

namespace VLTPlugin.Interface
{
    public interface IVault
    {
        WebServiceManager WebMan { get; set; }

        void Initialize(WebServiceManager webMan);
        MyFolder CreateFolderInRoot(string Name);

        //object GetElementBySysNID()
    }
}
