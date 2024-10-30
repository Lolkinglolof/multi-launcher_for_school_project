using System.Text.Json;
namespace multi_launcher
{

    public class Epic
    {
        // Stedet hvor Epic Games manifesterne ligger
        private static readonly string EpicGamesManifestPath = @"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests";

        //private ListBox listBoxGames;
        private string[] ManiFiles()
        {
            // Tjekker om manifest-mappen eksisterer
            if (!Directory.Exists(@"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests"))
            {
                //MessageBox.Show("Epic Games manifest folder not found.");
                return null;
            }
            // Henter alle .item filer fra manifest
            string[] manifestFiles = Directory.GetFiles(@"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests", "*.item");

            if (manifestFiles.Length == 0)
            {
                //MessageBox.Show("No installed games found");
                return null;
            }
            return manifestFiles;
        }
        private string GameName(string file)
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
                //listBoxGames.Items.Add(gameNameStr);

                // Opretter en genvej til spillet
                // denne linje åbner manifesten op, fix det.
                //CreateShortcut(gameNameStr, manifestJson);
            }
            return null;

        }
        private string GamePath(string gameName, JsonDocument manifestJson)
        {
            if (manifestJson.RootElement.TryGetProperty("LaunchExecutable", out var executablePath))
            {
                string targetPath = executablePath.GetString();
                return targetPath;
            }
            return null;
        }
    }



}


