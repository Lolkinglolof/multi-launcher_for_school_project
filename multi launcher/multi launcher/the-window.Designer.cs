//
//
// dette er ikke ting som uforstående skal pille i
//
//
namespace multi_launcher
{
    partial class the_window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(the_window));
            reloadbutton = new Button();
            label1 = new Label();
            imageList1 = new ImageList(components);
            panel1 = new Panel();
            panel4 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            label2 = new Label();
            button2 = new Button();
            panel3 = new Panel();
            vScrollBar1 = new VScrollBar();
            panel7 = new Panel();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // reloadbutton
            // 
            reloadbutton.Location = new Point(118, 4);
            reloadbutton.Margin = new Padding(3, 2, 3, 2);
            reloadbutton.Name = "reloadbutton";
            reloadbutton.Size = new Size(118, 22);
            reloadbutton.TabIndex = 0;
            reloadbutton.Text = "Check for games";
            reloadbutton.UseVisualStyleBackColor = true;
            reloadbutton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 68);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "SP.E.T.";
            label1.Click += label1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "41530da57b50b445c8b914f829826947.png");
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 109);
            panel1.TabIndex = 2;
            MouseWheel += MouseWheeling;
            // 
            // panel4
            // 
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 100);
            panel4.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 100);
            panel6.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 100);
            panel5.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(100, 53);
            panel3.TabIndex = 3;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Location = new Point(981, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 567);
            vScrollBar1.TabIndex = 1;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel7.Controls.Add(panel1);
            panel7.Location = new Point(118, 31);
            panel7.Name = "panel7";
            panel7.Size = new Size(850, 530);
            panel7.TabIndex = 4;
            // 
            // the_window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 567);
            Controls.Add(panel7);
            Controls.Add(vScrollBar1);
            Controls.Add(panel3);
            Controls.Add(label1);
            Controls.Add(reloadbutton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "the_window";
            Text = "the_window";
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button reloadbutton;
        private Label label1;
        private ImageList imageList1;
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private Button button2;
        private VScrollBar vScrollBar1;
        private Panel panel7;
        private Label label2;
    }
}