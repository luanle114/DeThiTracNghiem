namespace QuanLyDeThiTracNghiem
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.qzBtn = new System.Windows.Forms.Button();
            this.svBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.signBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gvBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýHệThốngToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýHệThốngToolStripMenuItem
            // 
            this.quảnLýHệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.đổiMậtKhẩuToolStripMenuItem});
            this.quảnLýHệThốngToolStripMenuItem.Name = "quảnLýHệThốngToolStripMenuItem";
            this.quảnLýHệThốngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.quảnLýHệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem1.Text = "Đăng xuất";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // qzBtn
            // 
            this.qzBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.qzBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("qzBtn.BackgroundImage")));
            this.qzBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qzBtn.ForeColor = System.Drawing.Color.DarkCyan;
            this.qzBtn.Location = new System.Drawing.Point(45, 52);
            this.qzBtn.Name = "qzBtn";
            this.qzBtn.Size = new System.Drawing.Size(234, 49);
            this.qzBtn.TabIndex = 1;
            this.qzBtn.Text = "Quản lý câu hỏi";
            this.qzBtn.UseVisualStyleBackColor = false;
            this.qzBtn.Click += new System.EventHandler(this.QzBtn_Click);
            // 
            // svBtn
            // 
            this.svBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.svBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("svBtn.BackgroundImage")));
            this.svBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svBtn.ForeColor = System.Drawing.Color.Crimson;
            this.svBtn.Location = new System.Drawing.Point(45, 146);
            this.svBtn.Name = "svBtn";
            this.svBtn.Size = new System.Drawing.Size(234, 48);
            this.svBtn.TabIndex = 2;
            this.svBtn.Text = "Quản lý sinh viên";
            this.svBtn.UseVisualStyleBackColor = false;
            this.svBtn.Click += new System.EventHandler(this.SvBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.testBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("testBtn.BackgroundImage")));
            this.testBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testBtn.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.testBtn.Location = new System.Drawing.Point(45, 329);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(234, 49);
            this.testBtn.TabIndex = 5;
            this.testBtn.Text = "Quản lý môn học";
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // signBtn
            // 
            this.signBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.signBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("signBtn.BackgroundImage")));
            this.signBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.signBtn.Location = new System.Drawing.Point(45, 420);
            this.signBtn.Name = "signBtn";
            this.signBtn.Size = new System.Drawing.Size(234, 49);
            this.signBtn.TabIndex = 7;
            this.signBtn.Text = "Đăng ký lịch thi";
            this.signBtn.UseVisualStyleBackColor = false;
            this.signBtn.Click += new System.EventHandler(this.SignBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyDeThiTracNghiem.Properties.Resources.tdt_logo;
            this.pictureBox1.Location = new System.Drawing.Point(302, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 513);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // gvBtn
            // 
            this.gvBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gvBtn.BackgroundImage")));
            this.gvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvBtn.ForeColor = System.Drawing.Color.Coral;
            this.gvBtn.Location = new System.Drawing.Point(45, 238);
            this.gvBtn.Name = "gvBtn";
            this.gvBtn.Size = new System.Drawing.Size(234, 50);
            this.gvBtn.TabIndex = 3;
            this.gvBtn.Text = "Quản lý giáo viên";
            this.gvBtn.UseVisualStyleBackColor = false;
            this.gvBtn.Click += new System.EventHandler(this.GvBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(872, 600);
            this.Controls.Add(this.signBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.gvBtn);
            this.Controls.Add(this.svBtn);
            this.Controls.Add(this.qzBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Hệ thống thi trắc nghiệm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.Button qzBtn;
        private System.Windows.Forms.Button svBtn;
        private System.Windows.Forms.Button gvBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button signBtn;
    }
}