using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System;

public class Ubisoft_Lib
{
    private string ubisoftManifestPath;

    public Ubisoft_Lib()
    {
        ubisoftManifestPath = LocateUbisoftManifestPath();
    }

    private string LocateUbisoftManifestPath()
    {
        // Check common paths for Ubisoft manifest files
        string[] commonPaths = new string[]
        {
            @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\games",
            @"C:\Program Files\Ubisoft\Ubisoft Game Launcher\games",
            @"C:\ProgramData\Ubisoft\Ubisoft Game Launcher\games",
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Ubisoft Game Launcher\games"
        };

        foreach (string path in commonPaths)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Found Ubisoft manifest folder: {path}");
                return path;
            }
        }

        // Prompt the user if no common paths are found
        //MessageBox.Show("Ubisoft manifest folder not found. Please select the correct directory.", "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
        {
            folderBrowser.Description = "Please locate your Ubisoft Game Launcher folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                return folderBrowser.SelectedPath;
            }
        }

        return string.Empty;
    }

    /*public List<GameInfo> LoadInstalledGames()
    {
        List<GameInfo> installedGames = new List<GameInfo>();

        if (string.IsNullOrEmpty(ubisoftManifestPath) || !Directory.Exists(ubisoftManifestPath))
        {
            //MessageBox.Show("Ubisoft manifest folder not found. Please make sure Ubisoft Connect is installed properly.", "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return installedGames;
        }

        string[] manifestFiles = Directory.GetFiles(ubisoftManifestPath, "*.json");

        if (manifestFiles.Length == 0)
        {
            //MessageBox.Show("No installed games found", "No Games Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return installedGames;
        }

        foreach (var manifestFile in manifestFiles)
        {
            try
            {
                Console.WriteLine($"Reading manifest file: {manifestFile}");
                string manifestContent = System.IO.File.ReadAllText(manifestFile);
                var manifestJson = JsonDocument.Parse(manifestContent);

                if (manifestJson.RootElement.TryGetProperty("name", out var gameName) &&
                    manifestJson.RootElement.TryGetProperty("install_dir", out var installDir))
                {
                    string gameNameStr = gameName.GetString();
                    string installDirStr = installDir.GetString();

                    if (!string.IsNullOrEmpty(installDirStr) && Directory.Exists(installDirStr))
                    {
                        //installedGames.Add(new GameInfo { Name = gameNameStr, InstallDir = installDirStr });

                    }
                    else
                    {
                        Console.WriteLine($"Install directory does not exist for game: {gameNameStr}");
                    }
                }
                else
                {
                    Console.WriteLine("Required properties not found in manifest file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading manifest file: {manifestFile}. Details: {ex.Message}");
            }
        }

        return installedGames;
    }*/
}