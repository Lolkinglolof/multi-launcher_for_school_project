using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace multi_launcher
{
    class steam_lib 
    {
        public void placeholdername()
        {
            Directory.GetFiles(@"C:\Program Files(x86)\Steam\steamapps\common");
            DriveInfo[] drives = DriveInfo.GetDrives();
            MessageBox.Show(drives[0].Name);
        }
    }
}
