namespace multi_launcher
{
    internal class general
    {
        public static List<string> FileFinder(string path)
        {
            // setting up variables
            string[] dirs;
            string[] files;
            List<string> fileslist1 = new List<string>();
            List<string> fileslist2 = new List<string>();

            // making some checks to see how deep the folder is, and what files ther are
            dirs = Directory.GetDirectories(path);
            files = Directory.GetFiles(path, "*.exe");

            // if ther are other folders
            if (dirs.Length > 0)
            {
                // in every folder
                for (int i = 0; i < dirs.Length; i++)
                {
                    // reapeat this process, and add the files to the list
                    for (int j = 0; j < FileFinder(dirs[i]).Count; j++)
                        fileslist2.Add(FileFinder(dirs[i])[j]);
                }

            }
            // if there are files in this folder
            if (files.Length > 0)
            {
                // add all files to the list
                for (int i = 0; i < files.Length; i++)
                {
                    fileslist1.Add(files[i]);
                }
            }
            // and for every other file found, add it to the list
            for (int i = 0; i < fileslist2.Count; i++)
            {
                fileslist1.Add(fileslist2[i]);
            }
            // and give the list back
            return fileslist1;
        }
        public static string FileSorter(List<string> files)
        {
            string file = "";
            
            //begins the filtering of all unnessecery .exe files
            for (int c = 0; c < files.Count; c++)
            {
                if (files.Count == 1)
                {
                    file = files[c];
                    break;
                }
                if (files[c].Contains("Installer"))
                {
                    continue;
                }
                if (files[c].Contains("Crash"))
                {
                    continue;
                }
                if (files[c].Contains("Renderer"))
                {
                    continue;
                }
                if (files[c].Contains("Server"))
                {
                    continue;
                }
                if (files[c].Contains("server"))
                {
                    continue;
                }
                if (files[c].Contains("java"))
                {
                    continue;
                }
                if (files[c].Contains("launcher"))
                {
                    continue;
                }
                if (files[c].Contains("Reporter"))
                {
                    continue;
                }
                if (files[c].Contains("keytool"))
                {
                    continue;
                }
                if (files[c].Contains("Browser"))
                {
                    continue;
                }
                if (files[c].Contains("SETUP"))
                {
                    continue;
                }
                if (files[c].Contains("WebHelper"))
                {
                    continue;
                }
                if (files[c].Contains("Shipping"))
                {
                    continue;
                }
                if (files[c].Contains("tracetcp.exe"))
                {
                    continue;
                }
                if (files[c].Contains("dotNet"))
                {
                    continue;
                }
                if (files[c].Contains("dowser"))
                {
                    continue;
                }
                if (files[c].Contains("Editor"))
                {
                    continue;
                }
                if (files[c].Contains("zip"))
                {
                    continue;
                }
                if (files[c].Contains("redist"))
                {
                    continue;
                }
                if (files[c].Contains("Redist"))
                {
                    continue;
                }
                if (files[c].Contains("captioncompiler"))
                {
                    continue;
                }
                if (files[c].Contains("NativeWrapper"))
                {
                    continue;
                }
                else
                {
                    file = files[c];
                    break;
                }
            }
            // if no .exe file is found, do not include game
            if (file == "")
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        public static void gamepanel(int amountbefore, string id, string name, string file, Control parent)
        {
            //
            //the panel where all game relevant things should be on
            //
            Panel panel = new Panel();
            panel.Name = "1panel" + id;
            parent.Controls.Add(panel);
            panel.Size = new System.Drawing.Size(950, 106);
            panel.Location = new Point(0, 106 * amountbefore);
            panel.BackColor = System.Drawing.Color.Gray;
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
            gamename.ReadOnly = true;
            //
            //creation of the play button
            //
            Button button = new Button();
            button.Text = "start game";
            button.Location = new Point(213, 50);
            panel.Controls.Add(button);
            button.Size = new System.Drawing.Size(120, 40);
            button.Name = name;
            button.Tag = file;
            button.Location = new Point(213, 50);
            button.BackColor = System.Drawing.Color.Green;
            button.MouseClick += the_window.button_Click;
        }
    }
}
