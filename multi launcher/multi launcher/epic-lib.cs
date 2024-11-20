using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;


namespace multi_launcher
{

    public class Epic
    {
        // Stedet hvor Epic Games manifesterne ligger
        public static readonly string EpicGamesManifestPath = @"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests";
        public static string EpicLocator()
        {
            string[] l;
            string[] ll;
            string Epicloc;
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {

                l = Directory.GetDirectories(drives[i].Name, "*(x86)");

                for (int j = 0; j < l.Length; j++)
                {
                    Debug.WriteLine(l[j]);
                    ll = Directory.GetDirectories(l[j], "Epic*");

                    for (int k = 0; k < ll.Length; k++)
                    {
                        Debug.WriteLine(ll[k]);
                        Epicloc = ll[k];
                        return Epicloc;
                    }
                }
                if (Directory.GetDirectories(drives[i].Name, "Epic*").Length == 1)
                {
                    for (int j = 0; j < Directory.GetDirectories(drives[i].Name, "Epic*").Length; j++)
                    {
                        Epicloc = Directory.GetDirectories(drives[i].Name, "Epic*")[1];
                        return Epicloc;
                    }
                }
                // possibly take another popular place later

            }
            return null;
        }
        //public ListBox listBoxGames;
        public static string[] ManiFiles()
        {
            //List<string> manifestFiles = ["idk?"];
            // Tjekker om manifest-mappen eksisterer
            if (!Directory.Exists(@"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests"))
            {
                //MessageBox.Show("Epic Games manifest folder not found.");
                return null;
            }
            // Henter alle .item filer fra manifest
            //manifestFiles.Clear();
            string[] manifestFiles = Directory.GetFiles(@"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests", "*.item");
            /*foreach (string file in files)
            {
                manifestFiles.Add(file);
            }*/
            

            if (manifestFiles.Length == 0)
            {
                //MessageBox.Show("No installed games found");
                return null;
            }
            return manifestFiles;
        }
        public static string GameName(string file)
        {
            // Læser indholdet af manifestfilen
            string manifestContent = System.IO.File.ReadAllText(file);

            // Parser manifestfilen for at få spildetaljer ved hjælp af JSON
            var manifestJson = JsonDocument.Parse(manifestContent);

            // Indsamler spillets navn
            if (manifestJson.RootElement.TryGetProperty("DisplayName", out var gameName))
            {
                string gameNameStr = gameName.GetString();
                return gameNameStr;
            }
            return null;

        }
        public static string GamePath(string file) 
        {
            // Læser indholdet af manifestfilen
            string manifestContent = File.ReadAllText(file);

            // Parser manifestfilen for at få spildetaljer ved hjælp af JSON
            var manifestJson = JsonDocument.Parse(manifestContent);

            // Indsamler spillets navn
            if (manifestJson.RootElement.TryGetProperty("LaunchExecutable", out var gameName))
            {
                string gameNameStr = gameName.GetString();
                return gameNameStr;
            }
            return null;
        }
        public static string imagefinder(string name) // nyt
        {
            string? image = null;

      
            string el = EpicLocator();
            Debug.WriteLine(el + "\\Launcher\\Portal\\SysFiles");
            image = Directory.GetFiles(el + "\\Launcher\\Portal\\SysFiles","*"+name + "*" + ".png").FirstOrDefault();
            return image ?? ".\\shit_yourself.png";
            
        
        }

    }
}


