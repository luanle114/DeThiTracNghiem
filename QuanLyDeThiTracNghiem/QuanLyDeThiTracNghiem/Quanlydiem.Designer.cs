namespace QuanLyDeThiTracNghiem
{
    partial class Quanlydiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quanlydiem));
            this.label1 = new System.Windows.Forms.Label();
            this.findTxT = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.bangdiemDVG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bangdiemDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm thông tin sinh viên :";
            // 
            // findTxT
            // 
            this.findTxT.Location = new System.Drawing.Point(287, 32);
            this.findTxT.Multiline = true;
            this.findTxT.Name = "findTxT";
            this.findTxT.Size = new System.Drawing.Size(304, 34);
            this.findTxT.TabIndex = 1;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(640, 32);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(93, 36);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "Tìm kiếm";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // bangdiemDVG
            // 
            this.bangdiemDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bangdiemDVG.Location = new System.Drawing.Point(12, 103);
            this.bangdiemDVG.Name = "bangdiemDVG";
            this.bangdiemDVG.RowHeadersWidth = 51;
            this.bangdiemDVG.RowTemplate.Height = 24;
            this.bangdiemDVG.Size = new System.Drawing.Size(776, 335);
            this.bangdiemDVG.TabIndex = 3;
            // 
            // Quanlydiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bangdiemDVG);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.findTxT);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quanlydiem";
            this.Text = "Quản lý điểm";
            this.Load += new System.EventHandler(this.Quanlydiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangdiemDVG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findTxT;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.DataGridView bangdiemDVG;
    }
}