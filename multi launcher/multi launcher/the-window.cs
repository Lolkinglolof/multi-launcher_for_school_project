using System.Diagnostics;

namespace multi_launcher
{

    public partial class the_window : Form
    {
        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        string steam = steam_lib.SteamLocator();

        int scroll;
        List<string> gamelist = new List<string>();

        public the_window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clears the board for game panels, and makes it ready for new ones
            this.panel1.Controls.Clear();
            gamelist.Clear();
            // catching the game manifests
            string[] games = steam_lib.GameLister();
            for (int i = 0; i < games.Length; i++)
            {

                //catching name, installdir and id of the steam games
                string name = steam_lib.Gamenamer(games[i], "name");
                string installdir = steam_lib.Gamenamer(games[i], "installdir");
                string id = steam_lib.Gamenamer(games[i], "appid");
                // filters non game apps out
                if (name == "Steamworks Common Redistributables")
                {
                    continue;
                }
                if (name.Contains("Soundtrack"))
                {
                    continue;
                }
                // makes a definition for the game folder
                string appdir = steam + "/steamapps/common/" + installdir;

                // defines the specific file to use
                string exefile = general.FileSorter(general.FileFinder(appdir));

                // makes the panel for the game
                general.gamepanel(gamelist.Count, id, name, exefile, panel1);

                // adds the game to the list of allready placed games
                gamelist.Add(name);



                vScrollBar1.Maximum = panel1.Size.Height - panel7.Size.Height;
                vScrollBar1.Minimum = 0;

                break;
            }
            panel1.Invoke(() =>
                {
                    panel1.Size = new System.Drawing.Size(955, 106 * gamelist.Count);

                    //MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                });

        }


        public static void button_Click(object? sender, EventArgs e)
        {
            var btn = (Button)sender;
            string game = (string)btn.Tag;
            Process p = new Process();
            p.StartInfo.FileName = game;
            p.Start();
        }



        /*if (Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/",file[0]+ "*").Length ==1)
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir,  "*.exe")[0];
        }
        else if(Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/",file[0]+file[1]+"*").Length ==1)
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir,"*.exe")[0];
        }
        else if (Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/",file[0] + file[1] + file[2]+ "*").Length ==1)
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir," *.exe")[0];
        }
        else if (Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + file[3]+"*").Length ==1)
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + file[3] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir, "*.exe")[0];
        }
        else if (Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + file[3] + file[4]+"*").Length ==1)
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + file[3] + file[4] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir, " *.exe")[0];
        }
        else
        {
            Dir = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/", file[0] + file[1] + file[2] + file[3] + file[4] + file[5] + "*")[0];
            p.StartInfo.FileName = Directory.GetFiles(Dir," *.exe")[0];
        }*/

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Maximum = panel1.Size.Height - panel7.Size.Height;
            vScrollBar1.Minimum = 0;
            scroll = vScrollBar1.Value;
            vScrollBar1.Value = -panel1.Location.Y;
            panel1.Location = new Point(0, 0 - scroll);

        }

        private void MouseWheeling(object? sender, MouseEventArgs e)
        {
            int linemove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int pixmove = linemove * 20;
            panel1.Location = new Point(0, panel1.Location.Y + pixmove);
            if (panel1.Location.Y > 0)
            {
                panel1.Location = new Point(0, 0);
            }
            if (panel1.Location.Y < -panel1.Height + panel7.Height)
            {
                panel1.Location = new Point(0, -panel1.Height + panel7.Height);
            }
            vScrollBar1.Value = -panel1.Location.Y;
        }
    }
}

