using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace multi_launcher
{
    internal class general
    {
        public static void ReloadGames(Control parentcontrol)
        {
            List<string> gamelist = new List<string>();
            // clears the board for game panels, and makes it ready for new ones
            parentcontrol.Controls.Clear();
            gamelist.Clear();
            // catching the game manifests
            //string[] games = Enumerable.Concat(Steam.GameLister(), Epic.ManiFiles()).ToArray();
            string[] steamgames = Steam.GameLister();
            string[] epicgames = Epic.ManiFiles();
            if (steamgames != null)
                for (int i = 0; i < steamgames.Length; i++)
                {
                    string id = Steam.Gamenamer(steamgames[i], "appid");
                    string name = Steam.Gamenamer(steamgames[i], "name");
                    if (name == "Steamworks Common Redistributables")
                    {
                        continue;
                    }
                    if (name.Contains("Soundtrack"))
                    {
                        continue;
                    }
                    if (name.Contains("SDK"))
                    {
                        continue;
                    }
                    GamePanelCreator(id, gamelist, parentcontrol, name, Steam.imagefinder(id, "header"), "steam");




                    gamelist.Add(name);
                }
            if (epicgames != null)
                for (int i = 0; i < epicgames.Length; i++)
                {
                    string name = Epic.GameName(epicgames[i]);
                    string id = Epic.GameInfo(epicgames[i], "DisplayName");
                    if (name.ToLower().Contains("unrealengine"))
                        continue;
                    GamePanelCreator(id, gamelist, parentcontrol, name,Epic.imagefinder(name), "epic");
                    gamelist.Add(name);
                }

        }
        private static void button_Click(object? sender, EventArgs e)
        {

            var btn = (Button)sender;
            string launcher = (string)btn.Tag;
            string id = (string)btn.Name;
            
            Process p = new Process();
            if (launcher == "steam")
            {
                p.StartInfo.FileName = "Steam://rungameid/" + id;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            if (launcher == "epic")
            {
                string themanifest = "";
                string[] manifests = Epic.ManiFiles();
                foreach (string manifest in manifests)
                {
                    string? displaynamecheck =File.ReadAllLines(manifest).FirstOrDefault(line => line.Contains("DisplayName"));
                    displaynamecheck = displaynamecheck?.Replace("\"" + "DisplayName" + "\""+":", string.Empty).Replace(",",string.Empty)?.Trim()?.Trim('"');
                    if (displaynamecheck == id)
                    {
                        themanifest=manifest;
                        break;
                    }
                }

                string MainGameCatalogItemId = Epic.GameInfo(themanifest, "MainGameCatalogItemId");
                string MainGameAppName = Epic.GameInfo(themanifest, "MainGameAppName");
                string CatalogNamespace = Epic.GameInfo(themanifest, "CatalogNamespace");
                p.StartInfo.FileName = "com.epicgames.launcher://apps/" + CatalogNamespace + "%3A" + MainGameCatalogItemId + "%3A" + MainGameAppName+ "?action=launch&silent=true";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }


        }
        private static void GamePanelCreator(string id, List<string> gamelist, Control parentcontrol, string name, string? header, string launcher)
        {
            //
            //the panel where all game relevant things should be on
            //
            Panel panel = new Panel();
            panel.Name = "1panel" + id;
            parentcontrol.Controls.Add(panel);
            panel.Size = new Size(950, 106);
            panel.Location = new Point(0, 106 * gamelist.Count);
            panel.BackColor = ColorTranslator.FromHtml("#303030"); ;
            //
            //creation of the picture on the game banner
            //
            PictureBox icon = new PictureBox();
            icon.Name = "iconpanel" + id;
            panel.Controls.Add(icon);
            icon.Size = new Size(206, 106);
            icon.Location = new Point(0, 0);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Image = Image.FromFile(header);
            //
            //creation of the text for the game name
            //
            TextBox gamename = new TextBox();
            gamename.Text = name;
            panel.Controls.Add(gamename);
            gamename.BackColor = ColorTranslator.FromHtml("#303030");
            gamename.BorderStyle = BorderStyle.None;
            gamename.ForeColor = Color.White;
            gamename.Size = new Size(600, 30);
            gamename.Font = new Font(TextBox.DefaultFont.FontFamily, 20);
            gamename.Location = new Point(213, 5);
            gamename.ReadOnly = true;
            //
            //creation of the play button
            //
            Button button = new Button();
            button.Text = "START GAME";
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.Location = new Point(213, 50);
            panel.Controls.Add(button);
            button.Size = new Size(120, 40);
            button.Name = id;
            button.Tag = launcher;
            button.Location = new Point(213, 50);
            button.BackColor = Color.Green;
            button.MouseClick += button_Click;
            //
            //creation of the store icon
            //
            PictureBox storeicon = new PictureBox();
            panel.Controls.Add(storeicon);
            storeicon.Location = new Point(650,30);
            storeicon.Size = new Size(500,40);
            storeicon.SizeMode = PictureBoxSizeMode.Zoom;
            //storeicon.Image = Image.FromFile(".\\"+launcher+"_icon.png");   
        }
    }
}

