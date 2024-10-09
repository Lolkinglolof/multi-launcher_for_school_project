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
        int scroll;
        List<string> gamelist = new List<string>();
        
        public void maintenence(object? sender, ElapsedEventArgs e)
        {
            panel1.Invoke(() =>
            {
                panel1.Size = new System.Drawing.Size(850, 83 * gamelist.Count);
                //MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            });

            
        }
        public the_window()
        {
            gamelist.Add("i'm telling god");
            InitializeComponent();
            var t = new System.Timers.Timer();
            t.Interval = 10000;
            t.Elapsed += maintenence;
            t.Start();

                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(steam_lib.placeholdername());
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("reloading games");
            MessageBox.Show("reloading games");

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scroll = vScrollBar1.Value;
            panel1.Location = new Point(0, 0-scroll);
        }
    }
}
