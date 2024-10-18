namespace silo_connect
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnConnect = new Button();
            btnClose = new Button();
            txtStatus = new TextBox();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pageSetupDialog1 = new PageSetupDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnDisconnect = new Button();
            cmbServerIP = new ComboBox();
            cmbSocks5Port = new ComboBox();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.PaleGreen;
            btnConnect.FlatStyle = FlatStyle.Popup;
            btnConnect.Location = new Point(167, 119);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(134, 34);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(167, 447);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 5;
            btnClose.Text = "Exit";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.GhostWhite;
            txtStatus.Location = new Point(168, 215);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(588, 209);
            txtStatus.TabIndex = 7;
            txtStatus.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.GradientInactiveCaption;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(794, 33);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(78, 29);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 66);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 10;
            label1.Text = "SSH Server:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(482, 66);
            label2.Name = "label2";
            label2.Size = new Size(163, 25);
            label2.TabIndex = 11;
            label2.Text = "SOCKS Port (Local):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 180);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 12;
            label3.Text = "Connection results:";
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.Red;
            btnDisconnect.FlatStyle = FlatStyle.Popup;
            btnDisconnect.ForeColor = SystemColors.ControlLightLight;
            btnDisconnect.Location = new Point(325, 119);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(134, 34);
            btnDisconnect.TabIndex = 4;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // cmbServerIP
            // 
            cmbServerIP.FormattingEnabled = true;
            cmbServerIP.Location = new Point(275, 64);
            cmbServerIP.MaxLength = 15;
            cmbServerIP.Name = "cmbServerIP";
            cmbServerIP.Size = new Size(184, 33);
            cmbServerIP.TabIndex = 1;
            // 
            // cmbSocks5Port
            // 
            cmbSocks5Port.FormattingEnabled = true;
            cmbSocks5Port.Location = new Point(651, 63);
            cmbSocks5Port.MaxLength = 5;
            cmbSocks5Port.Name = "cmbSocks5Port";
            cmbSocks5Port.Size = new Size(105, 33);
            cmbSocks5Port.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(20, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 510);
            Controls.Add(pictureBox1);
            Controls.Add(cmbSocks5Port);
            Controls.Add(cmbServerIP);
            Controls.Add(btnDisconnect);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStatus);
            Controls.Add(btnClose);
            Controls.Add(btnConnect);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "SSH SocksV5 Proxy Connect";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnConnect;
        private Button btnClose;
        private TextBox txtStatus;
        private MenuStrip menuStrip1;
        private PageSetupDialog pageSetupDialog1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnDisconnect;
        private ComboBox cmbServerIP;
        private ComboBox cmbSocks5Port;
        private PictureBox pictureBox1;
    }
}
