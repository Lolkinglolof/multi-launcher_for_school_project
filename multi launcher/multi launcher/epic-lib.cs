using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace CustomGameLauncher
{
    public partial class MainForm : Form
    {
        // Stedet hvor Epic Games manifesterne ligger
        private static readonly string EpicGamesManifestPath = @"C:\ProgramData\Epic\EpicGamesLauncher\Data\Manifests";

        private ListBox listBoxGames;

        public MainForm()
        {

            InitializeCustomComponents();
            LoadInstalledGames();
        }

        private void InitializeCustomComponents()
        {
            // Initialiserer listBoxGames
            listBoxGames = new ListBox
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(listBoxGames);
        }
        private void LoadInstalledGames()
        {
            // Tjekker om manifest-mappen eksisterer
            if (!Directory.Exists(EpicGamesManifestPath))
            {
                MessageBox.Show("Epic Games manifest folder not found.");
                return;
            }
            // Henter alle .item filer fra manifest
            string[] manifestFiles = Directory.GetFiles(EpicGamesManifestPath, "*.item");

            if (manifestFiles.Length == 0)
            {
                MessageBox.Show("No installed games found");
                return;
            }

            // Gentager hver manifestfil
            foreach (var manifestFile in manifestFiles)
            {
                try
                {
                    // Læser indholdet af manifestfilen
                    string manifestContent = System.IO.File.ReadAllText(manifestFile);

                    // Parser manifestfilen for at få spildetaljer ved hjælp af JSON
                    var manifestJson = JsonDocument.Parse(manifestContent);

                    // Indsamler spillets navn
                    if (manifestJson.RootElement.TryGetProperty("DisplayName", out var gameName))
                    {
                        string gameNameStr = gameName.GetString();
                        listBoxGames.Items.Add(gameNameStr);

                        // Opretter en genvej til spillet
                        CreateShortcut(gameNameStr, manifestJson);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading manifest file: {manifestFile}. Details: {ex.Message}");
                }
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
                    string shortcutLocation = Path.Combine(Application.StartupPath, "Shortcuts", gameName +
".lnk");

                    // Brug WshShell til at oprette genvejen
                    WshShell shell = new WshShell();

                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    shortcut.Description = "Shortcut for " + gameName;
                    shortcut.TargetPath = targetPath;
                    shortcut.Save();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating shortcut for {gameName}. Details: {ex.Message}");
            }
        }
    }
}