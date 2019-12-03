namespace QuanLyDeThiTracNghiem
{
    partial class Ketqua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ketqua));
            this.label1 = new System.Windows.Forms.Label();
            this.monhocLB = new System.Windows.Forms.Label();
            this.ngaythiLB = new System.Windows.Forms.Label();
            this.lanthiLB = new System.Windows.Forms.Label();
            this.hotenLB = new System.Windows.Forms.Label();
            this.lopLB = new System.Windows.Forms.Label();
            this.diemLB = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẠN ĐÃ HOÀN THÀNH BÀI THI";
            // 
            // monhocLB
            // 
            this.monhocLB.AutoSize = true;
            this.monhocLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monhocLB.Location = new System.Drawing.Point(13, 185);
            this.monhocLB.Name = "monhocLB";
            this.monhocLB.Size = new System.Drawing.Size(87, 25);
            this.monhocLB.TabIndex = 1;
            this.monhocLB.Text = "Môn thi :";
            // 
            // ngaythiLB
            // 
            this.ngaythiLB.AutoSize = true;
            this.ngaythiLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaythiLB.Location = new System.Drawing.Point(396, 89);
            this.ngaythiLB.Name = "ngaythiLB";
            this.ngaythiLB.Size = new System.Drawing.Size(94, 25);
            this.ngaythiLB.TabIndex = 3;
            this.ngaythiLB.Text = "Ngày thi :";
            // 
            // lanthiLB
            // 
            this.lanthiLB.AutoSize = true;
            this.lanthiLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthiLB.Location = new System.Drawing.Point(396, 136);
            this.lanthiLB.Name = "lanthiLB";
            this.lanthiLB.Size = new System.Drawing.Size(81, 25);
            this.lanthiLB.TabIndex = 5;
            this.lanthiLB.Text = "Lần thi :";
            // 
            // hotenLB
            // 
            this.hotenLB.AutoSize = true;
            this.hotenLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotenLB.Location = new System.Drawing.Point(13, 89);
            this.hotenLB.Name = "hotenLB";
            this.hotenLB.Size = new System.Drawing.Size(80, 25);
            this.hotenLB.TabIndex = 8;
            this.hotenLB.Text = "Họ tên :";
            // 
            // lopLB
            // 
            this.lopLB.AutoSize = true;
            this.lopLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lopLB.Location = new System.Drawing.Point(13, 136);
            this.lopLB.Name = "lopLB";
            this.lopLB.Size = new System.Drawing.Size(56, 25);
            this.lopLB.TabIndex = 10;
            this.lopLB.Text = "Lớp :";
            // 
            // diemLB
            // 
            this.diemLB.AutoSize = true;
            this.diemLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diemLB.Location = new System.Drawing.Point(396, 185);
            this.diemLB.Name = "diemLB";
            this.diemLB.Size = new System.Drawing.Size(93, 25);
            this.diemLB.TabIndex = 12;
            this.diemLB.Text = "Điểm thi :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(649, 276);
            this.dataGridView1.TabIndex = 14;
            // 
            // Ketqua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(683, 552);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.diemLB);
            this.Controls.Add(this.lopLB);
            this.Controls.Add(this.hotenLB);
            this.Controls.Add(this.lanthiLB);
            this.Controls.Add(this.ngaythiLB);
            this.Controls.Add(this.monhocLB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ketqua";
            this.Text = "Kết quả thi";
            this.Load += new System.EventHandler(this.Ketqua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label monhocLB;
        private System.Windows.Forms.Label ngaythiLB;
        private System.Windows.Forms.Label lanthiLB;
        private System.Windows.Forms.Label hotenLB;
        private System.Windows.Forms.Label lopLB;
        private System.Windows.Forms.Label diemLB;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}