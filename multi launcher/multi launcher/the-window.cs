namespace multi_launcher
{

    public partial class the_window : Form
    {
        private System.Drawing.Drawing2D.GraphicsPath mousePath;


        int scroll;
        List<string> gamelist = new List<string>();

        public the_window()
        {
            this.BackColor = ColorTranslator.FromHtml("#242940");
            // do not move the functions under this comment
            InitializeComponent();
            general.ReloadGames(panel1, null);
            scrollbaradjust(this.vScrollBar1, panel1, panel7);
            // from here on ignore the last comment

            this.MinimumSize = new Size(1160, 300);
        }
        private void the_window_resize(object sender, EventArgs e)
        {
            Control panel1;
            Control control = (Control)sender;
            foreach (Control con in control.Controls)
            {
                if (con.Name == "panel7")
                {
                    foreach (Control con1 in con.Controls)
                    {
                        if (con1.Name == "panel1")
                        {
                            panel1 = con1;
                            if (panel1.Bottom < control.Height)
                            {
                                if (panel1.Size.Height > panel7.Size.Height)
                                    panel1.Location = new Point(panel1.Location.X, -panel1.Height + panel7.Height);
                                scrollbaradjust(vScrollBar1, panel1, panel7);
                                break;
                            }
                        }
                    }
                }

            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            Control con = (Control)sender;
            string filter = null;
            if (con.Text != null)
            {
                filter = con.Text;
            }

            general.ReloadGames(panel1, filter.ToLower());
            scrollbaradjust(this.vScrollBar1, panel1, panel7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control panel7 = null;
            Control panel1 = null;
            Control send = (Control)sender;
            var col = send.Parent.BackColor;
            var colhold = send.Parent.BackColor;
            if (col == ColorTranslator.FromHtml("#242940"))
                col = Color.Beige;
            else if (col == Color.Beige)
                col = ColorTranslator.FromHtml("#242940");
            send.Parent.BackColor = col;
            foreach (Control control in send.Parent.Controls)
            {
                if (control.Name == "panel7")
                {
                    panel7 = control;
                }
            }
            if (panel7 != null)
                foreach (Control control in panel7.Controls)
                {
                    if (control.Name == "panel1")
                    {
                        panel1 = control;
                    }
                }
            if (panel1 != null)
                foreach (Control control in panel1.Controls)
                {
                    control.BackColor = send.Parent.BackColor;
                    foreach (Control textbox in control.Controls)
                    {
                        if (textbox is TextBox)
                        {
                            textbox.BackColor = send.Parent.BackColor;
                            textbox.ForeColor = colhold;
                        }

                    }
                }


        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            scroll = vScrollBar1.Value;
            vScrollBar1.Value = -panel1.Location.Y;
            panel1.Location = new Point(0, 0 - scroll);

        }
        public static void scrollbaradjust(VScrollBar scrollbar, Control panel1, Control panel7)
        {
            if (panel1.Height - panel7.Height <= 0)
            {
                scrollbar.Maximum = panel1.Size.Height - 106;
            }
            else
            {
                scrollbar.Maximum = panel1.Size.Height - panel7.Size.Height;
            }
            if (panel1.Size.Height > panel7.Size.Height)
                scrollbar.Value = -panel1.Location.Y;
            return;
        }

        private void MouseWheeling(object? sender, MouseEventArgs e)
        {
            // fix crash on scroll, check math before applying
            int linemove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int pixmove = linemove * 20;
            if (panel1.Height - panel7.Height <= 0)
            {
                vScrollBar1.Maximum = panel1.Size.Height - 106;
            }
            else
            {
                vScrollBar1.Maximum = panel1.Size.Height - panel7.Size.Height;
            }

            vScrollBar1.Minimum = 0;

            if (-panel1.Location.Y - pixmove <= vScrollBar1.Minimum)
            {
                panel1.Location = new Point(0, -vScrollBar1.Minimum);
                vScrollBar1.Value = -panel1.Location.Y;
            }
            else if (-panel1.Location.Y - pixmove >= vScrollBar1.Maximum)
            {
                panel1.Location = new Point(0, -vScrollBar1.Maximum);
                vScrollBar1.Value = -panel1.Location.Y;
            }
            else
            {
                if (panel1.Height - panel7.Height < 0)
                {
                    panel1.Location = new Point(0, 0);
                    vScrollBar1.Value = -panel1.Location.Y;
                }
                else
                {
                    panel1.Location = new Point(0, panel1.Location.Y + pixmove);
                    vScrollBar1.Value = -panel1.Location.Y;
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.Text.Contains("type here to search"))
            {
                if (control.Text.Length >= 20)
                {
                    control.Text = control.Text.Remove(control.Text.Length - 19);
                }
            }
            if (control.Text == "type here to search")
            {

            }
            else if (control.Text != string.Empty)
            {
                
                button1_Click(sender,e);
            }
            else if (control.Text == string.Empty)
            {
                control.Text = "type here to search";
            }
        }
    }
}

