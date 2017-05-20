using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Connectivity.WebServices;

namespace VLTPlugin.Interface.Entities
{
    public class MyFolder
    {
        public long ID { get; set; }

        public MyFolder() { }

        public MyFolder(Folder fldr)
        {
            ID = fldr.Id;
        }
    }
}
