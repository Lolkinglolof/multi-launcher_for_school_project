using System.Diagnostics;
using System.Timers;

namespace multi_launcher
{

    public partial class the_window : Form
    {
        private System.Drawing.Drawing2D.GraphicsPath mousePath;
        public static void steamupdate(object sender, EventArgs e)
        {


        }

        int scroll;
        List<string> gamelist = new List<string>();

        public void maintenence(object? sender, ElapsedEventArgs e)
        {
            panel1.Invoke(() =>
            {
                panel1.Size = new System.Drawing.Size(955, 106 * gamelist.Count);
                //MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            });


        }
        public the_window()
        {
            InitializeComponent();



        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            gamelist.Clear();
            // catching the game manifests
            string[] games = steam_lib.GameLister();
            for (int i = 0; i < games.Length; i++)
            {

                //catching name and id of the steam games
                string name = steam_lib.Gamenamer(games[i], "name");
                string installdir = steam_lib.Gamenamer(games[i], "installdir");
                string id = steam_lib.Gamenamer(games[i], "appid");
                if (name == "Steamworks Common Redistributables")
                {
                    continue;
                }
                if (name.Contains("Soundtrack"))
                {
                    continue;
                }
                Process p = new Process();
                string game = "";

                List<string> filelist = new List<string>();
                string[] f = Directory.GetFiles(steam_lib.SteamLocator() + "/steamapps/common/" + installdir, "*.exe");
                string[] ff;
                string[] fff;
                string[] ffff;
                string[] l = Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/" + installdir);
                //debugging
                if (f.Length > 0)
                {
                    //MessageBox.Show(f[0]);
                }
                // checks all directory in game folder
                for (int a = 0; a < l.Length; a++)
                {
                    //checking code
                    string[] ll = Directory.GetDirectories(l[a]);
                    // and checks those directories
                    for (int b = 0; b < ll.Length; b++)
                    {
                        string[] lll = Directory.GetDirectories(ll[b]);
                        for (int d = 0; d < lll.Length; d++)
                        {
                            //gets all the files in the last directory
                            ffff = Directory.GetFiles(lll[d], "*.exe");
                            for (int c = 0; c < ffff.Length; c++)
                            {
                                // adds them to a list
                                filelist.Add(ffff[c]);
                            }
                        }
                        //gets all the files in the last directory
                        fff = Directory.GetFiles(ll[b], "*.exe");
                        for (int c = 0; c < fff.Length; c++)
                        {
                            // adds them to a list
                            filelist.Add(fff[c]);
                        }
                    }
                    // gets all files in the second directory
                    ff = Directory.GetFiles(l[a], "*.exe");
                    for (int c = 0; c < ff.Length; c++)
                    {
                        // adds those to a list
                        filelist.Add(ff[c]);
                    }
                }
                for (int c = 0; c < f.Length; c++)
                {
                    filelist.Add(f[c]);
                }
                Debug.WriteLine(filelist);
                for (int c = 0; c < filelist.Count; c++)
                {
                    if (filelist.Count == 1)
                    {
                        game = filelist[c];
                        break;
                    }
                    if (filelist[c].Contains("Installer"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Crash"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Renderer"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Server"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("server"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("java"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("launcher"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Reporter"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("keytool"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Browser"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("SETUP"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("WebHelper"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Shipping"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("tracetcp.exe"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("dotNet"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("dowser"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Editor"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("zip"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("redist"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("Redist"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("captioncompiler"))
                    {
                        continue;
                    }
                    if (filelist[c].Contains("NativeWrapper"))
                    {
                        continue;
                    }
                    else
                    {
                        game = filelist[c];
                        break;
                    }
                }
                //debugging
                //MessageBox.Show(game);
                if (game == "")
                {
                    continue;
                }
                // debugging until buttons work
                if (game != null)
                {
                    p.StartInfo.FileName = game;
                    p.Start();
                }
                //
                //the panel where all game relevant things should be on
                //
                Panel panel = new Panel();
                panel.Name = "1panel" + id;
                panel1.Controls.Add(panel);
                panel.Size = new System.Drawing.Size(950, 106);
                panel.Location = new Point(0, 106 * gamelist.Count);
                panel.BackColor = System.Drawing.Color.Gray;

                /*gamelist.Add(name);
                Panel panel2 = new Panel();
                panel2.Name = "2panel" + id;
                panel.Controls.Add(panel2 );
                panel2.Size = new System.Drawing.Size(950, 106);
                panel2.Location = new Point(207, 53);
                panel2.BackColor = System.Drawing.Color.Gray;*/

                /*Panel panel3 = new Panel();
                panel3.Name = "3panel" + id;
                panel.Controls.Add(panel3);
                panel3.Size = new System.Drawing.Size(950, 53);
                panel3.Location = new Point(207, 0);
                panel3.BackgroundImage = Image.FromFile(steam_lib.imagefinder(id, "header"));
                panel3.BackgroundImageLayout = ImageLayout.Zoom;*/
                //
                //creation of the picture on the game banner
                //
                PictureBox icon = new PictureBox();
                icon.Name = "iconpanel" + id;
                panel.Controls.Add(icon);
                icon.Size = new System.Drawing.Size(206, 106);
                icon.Location = new Point(0, 0);
                icon.SizeMode = PictureBoxSizeMode.Zoom;
                icon.Image = Image.FromFile(steam_lib.imagefinder(id, "header"));
                //
                //creation of the text for the game name
                //
                TextBox gamename = new TextBox();
                gamename.Text = name;
                panel.Controls.Add(gamename);
                gamename.BackColor = System.Drawing.Color.Gray;
                gamename.BorderStyle = BorderStyle.None;
                gamename.ForeColor = System.Drawing.Color.White;
                gamename.Size = new System.Drawing.Size(1000, 30);
                gamename.Font = new Font(TextBox.DefaultFont.FontFamily, 20);
                gamename.Location = new Point(213, 5);
                //
                //creation of the play button
                //
                Button button = new Button();
                button.Text = "start game";
                button.Location = new Point(213, 50);
                panel.Controls.Add(button);
                button.Size = new System.Drawing.Size(120, 40);
                button.Name = name;
                button.Location = new Point(213, 50);
                button.BackColor = System.Drawing.Color.Green;
                button.MouseClick += Button_MouseClick;

                gamelist.Add(name);

                vScrollBar1.Maximum = panel1.Size.Height - panel7.Size.Height;
                vScrollBar1.Minimum = 0;


            }
            panel1.Invoke(() =>
            {
                panel1.Size = new System.Drawing.Size(955, 106 * gamelist.Count);

                //MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            });


        }

        private void Button_MouseClick(object? sender, MouseEventArgs e)
        {
            
        }

        private void button_Click(string file, object? sender, EventArgs e)
        {

            MessageBox.Show("start game");
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
            int pixmove =linemove * 20;
            panel1.Location = new Point(0,panel1.Location.Y+pixmove);
            if (panel1.Location.Y > 0)
            {
                panel1.Location = new Point(0, 0);
            }
            if (panel1.Location.Y < -panel1.Height+panel7.Height)
            {
                panel1.Location = new Point(0,-panel1.Height+panel7.Height);
            }
            vScrollBar1.Value = -panel1.Location.Y;
        }
    }
}

