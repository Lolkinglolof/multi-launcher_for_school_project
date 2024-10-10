using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;

namespace multi_launcher
{

    public partial class the_window : Form
    {
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
            // a little temporary safeguard, since some folders does't have the same name as the game. they often missed a space or the alike
            List<string> fails = new List<string> { "Fallout 76", "World of Talesworth: Idle MMO Simulator" };
            List<string> corrects = new List<string> { "fallout76", "World of Talesworth" };
            // catching the game manifests
            string[] games = steam_lib.GameLister();
            for (int i = 0; i < games.Length; i++)
            {

                //catching name and id of the steam games
                string name = steam_lib.Gamenamer(games[i], "name");
                string id = steam_lib.Gamenamer(games[i], "appid");


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
                gamename.Size = new System.Drawing.Size(360, 30);
                gamename.Font = new Font(TextBox.DefaultFont.FontFamily, 20);
                gamename.Location = new Point(213, 5);
                //
                //creation of the play button
                //
                Button button = new Button();
                button.Text = "start game";
                // temporary fix for names that doesn't match the game folder
                for (int u = 0; u < fails.Count; u++)
                {
                    if (name == fails[u])
                    {
                        button.Name = corrects[u];
                        break;
                    }
                    else
                    {
                        button.Name = name;
                        break;
                    }
                }

                button.Location = new Point(213, 50);
                panel.Controls.Add(button);
                button.Size = new System.Drawing.Size(120, 40);

                button.BackColor = System.Drawing.Color.Green;



                gamelist.Add(name);

                panel1.Invoke(() =>
                {
                    panel1.Size = new System.Drawing.Size(955, 106 * gamelist.Count);

                    //MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                });
            }
        }
        private EventHandler button_Click(object sender, EventArgs e, string file)
        {
            /*Process p = new Process();
            string Dir;
            if (Directory.GetDirectories(steam_lib.SteamLocator() + "/steamapps/common/",file[0]+ "*").Length ==1)
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
            MessageBox.Show(file + " button clicked");
            return null;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Maximum = panel1.Size.Height - panel7.Size.Height;
            vScrollBar1.Minimum = 0;
            scroll = vScrollBar1.Value;
            panel1.Location = new Point(0, 0 - scroll);
        }
    }
}
