namespace multi_launcher
{

    public partial class the_window : Form
    {
        private System.Drawing.Drawing2D.GraphicsPath mousePath;


        int scroll;
        List<string> gamelist = new List<string>();

        public the_window()
        {
            InitializeComponent();
            general.ReloadGames(panel1);
            this.MinimumSize = new Size(1160, 300);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            general.ReloadGames(panel1);
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            scroll = vScrollBar1.Value;
            vScrollBar1.Value = -panel1.Location.Y;
            panel1.Location = new Point(0, 0 - scroll);

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
    }
}

