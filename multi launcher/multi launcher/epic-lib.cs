using System.Reflection.Metadata.Ecma335;
using System.Text.Json;


namespace multi_launcher
{

    public class Epic
    {
        // Stedet hvor Epic Games manifesterne ligger
        public static readonly string EpicGamesManifestPath = @"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests";

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
        
    }
}


