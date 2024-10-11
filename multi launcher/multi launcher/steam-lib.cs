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
    public class steam_lib 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns a list of things the first is the location of steam and any subsequent are libraries>
        public static string SteamLocator()
        {
            string[] l;
            string[] ll;
            string steamloc;
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i<drives.Length;i++)
            {

                l = Directory.GetDirectories(drives[i].Name, "*(x86)");
                
                for (int j = 0; j < l.Length; j++)
                {
                    Debug.WriteLine(l[j]);
                    ll = Directory.GetDirectories(l[j], "steam");
                    for (int k = 0; k < ll.Length; k++)
                    {
                        Debug.WriteLine(ll[k]);
                        steamloc = ll[k];
                        return steamloc;
                    }
                }
                
            }
            return null;
        }
        public static string[] GameLister()
        {
            string[] gamelist;
            gamelist =Directory.GetFiles(Directory.GetDirectories(SteamLocator(), "steamapps")[0]);
            for (int i = 0; i < gamelist.Count(); i++)
            {
                Debug.WriteLine("manifest = " + gamelist[i]);
                Debug.WriteLine("manifest = " + Gamenamer(gamelist[i],"name"));
            }
            return gamelist;
        }
        public static string Gamenamer(string file, string info)
        {
            string? Name = File.ReadAllLines(file).FirstOrDefault(line => line.Contains("\"" + info + "\""));
            string? gamename = Name?.Replace("\"" + info + "\"", string.Empty)?.Trim()?.Trim('"');
            return gamename ?? "Unkown";
        }
        public static string imagefinder(string id,string type)
        {
            string sl = SteamLocator();
            string? image = Directory.GetFiles(sl + '/' + "appcache/librarycache", id+'*'+type+'*').FirstOrDefault();
            return image ?? ".\\shit_yourself.png";
        }
    }
}
