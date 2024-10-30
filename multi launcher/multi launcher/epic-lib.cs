using System.Diagnostics;
using System.Text.Json;
namespace multi_launcher
{

    public class Epic
    {
        // Stedet hvor Epic Games manifesterne ligger
        private static readonly string EpicGamesManifestPath = @"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests";

        //private ListBox listBoxGames;
        private string[] ManifestFiles()
        {
            return Directory.GetFiles(@"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests", "*.item");
    }
        private string Games()
        {
            // Tjekker om manifest-mappen eksisterer
            if (!Directory.Exists(EpicGamesManifestPath))
            {
                //MessageBox.Show("Epic Games manifest folder not found.");
                return null;
            }
            // Henter alle .item filer fra manifest
            string[] manifestFiles = Directory.GetFiles(EpicGamesManifestPath, "*.item");

            if (manifestFiles.Length == 0)
            {
                //MessageBox.Show("No installed games found");
                return null;
            }
        }
        private string GameInfo(string file)
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
                
}
                

        private void CreateShortcut(string gameName, JsonDocument manifestJson)
{
    try
    {
        if (manifestJson.RootElement.TryGetProperty("LaunchExecutable", out var executablePath))
        {
            string targetPath = executablePath.GetString();

                // Bestemmer hvor genvejen skal placeres (f.eks. i launcher spilmappen)
                /*string shortcutLocation = Path.Combine(Application.StartupPath, "Shortcuts", gameName + ".lnk");

                // Brug WshShell til at oprette genvejen
                WshShell shell = new WshShell();

                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.Description = "Shortcut for " + gameName;
                shortcut.TargetPath = targetPath;
                shortcut.Save();*/
                Process game = new Process();
                game.StartInfo.FileName = targetPath;
                game.StartInfo.UseShellExecute = true;
                game.Start();

            }
        }
    catch (Exception ex)
    {
        MessageBox.Show($"Error creating shortcut for {gameName}. Details: {ex.Message}");
    }
}

    }
}


