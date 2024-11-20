using System.Diagnostics;

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
                    string id = Epic.GamePath(epicgames[i]);

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
                p.StartInfo.FileName = id;
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
            panel.BackColor = Color.DarkBlue;
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
            gamename.BackColor = Color.DarkBlue;
            gamename.BorderStyle = BorderStyle.None;
            gamename.ForeColor = Color.White;
            gamename.Size = new Size(1000, 30);
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
        }
    }
}

