using System.Diagnostics;

namespace multi_launcher
{
    public class Steam
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns a list of things the first is the location of Steam and any subsequent are libraries>
        public static string SteamLocator()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                string[] l = Directory.GetDirectories(drives[i].Name, "*(x86)");
                for (int j = 0; j < l.Length; j++)
                {
                    Debug.WriteLine(l[j]);
                    string[] ll = Directory.GetDirectories(l[j], "steam");
                    for (int k = 0; k < ll.Length; k++)
                    {
                        Debug.WriteLine(ll[k]);
                        return ll[k];
                    }
                }
                if (Directory.GetDirectories(drives[i].Name, "steam").Length == 1)
                {
                    for (int j = 0; j < Directory.GetDirectories(drives[i].Name, "steam").Length; j++)
                    {
                        return Directory.GetDirectories(drives[i].Name, "steam")[1];                        
                    }
                }
                // possibly take another popular place later
            }
            return null;
        }
        public static string SteamLibraryLocator()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (Directory.GetDirectories(drives[i].Name, "SteamLibrary").Length == 1)
                {
                    for (int j = 0; j < Directory.GetDirectories(drives[i].Name, "SteamLibrary").Length; j++)
                    {
                        return Directory.GetDirectories(drives[i].Name, "SteamLibrary")[0];
                    }
                }
            }
            return null;
        }
        public static string[] GameLister()
        {
            string[] gamelist = Directory.GetFiles(Directory.GetDirectories(SteamLocator(), "steamapps")[0], "*mani*").Where(file => !file.EndsWith(".tmp")).ToArray();
            if (SteamLibraryLocator() != null)
                gamelist = gamelist.Concat(Directory.GetFiles(Directory.GetDirectories(SteamLibraryLocator(), "steamapps")[0], "*mani*").Where(file => !file.EndsWith(".tmp")).ToArray()).ToArray();
            for (int i = 0; i < gamelist.Count(); i++)
            {
                Debug.WriteLine("manifest = " + gamelist[i]);
                Debug.WriteLine("manifest = " + Gamenamer(gamelist[i], "name"));
            }
            return gamelist;
        }
        public static string Gamenamer(string file, string info)
        {
            string? Name = File.ReadAllLines(file).FirstOrDefault(line => line.Contains("\"" + info + "\""));
            string? gamename = Name?.Replace("\"" + info + "\"", string.Empty)?.Trim()?.Trim('"');
            return gamename ?? "Unkown";
        }
        public static string imagefinder(string id, string type)
        {
            Debug.WriteLine(SteamLocator() + "/appcache/librarycache");
            string? image = Directory.GetFiles(SteamLocator() + '/' + "appcache/librarycache", id + '*' + type + '*').FirstOrDefault();
            return image ?? ".\\shit_yourself.png";
        }
    }
}
