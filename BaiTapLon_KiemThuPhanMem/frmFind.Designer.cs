namespace BaiTapLon_KiemThuPhanMem
{
    partial class frmFind
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
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.groupBoxTK = new System.Windows.Forms.GroupBox();
            this.txtNgayDat = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lbNgayDat = new System.Windows.Forms.Label();
            this.lbMaNV = new System.Windows.Forms.Label();
            this.btnTK = new System.Windows.Forms.Button();
            this.maDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.groupBoxTK.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDH,
            this.maKH,
            this.maNV,
            this.ngayDat});
            this.dgvKetQua.Location = new System.Drawing.Point(13, 183);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.Size = new System.Drawing.Size(443, 283);
            this.dgvKetQua.TabIndex = 0;
            // 
            // groupBoxTK
            // 
            this.groupBoxTK.Controls.Add(this.txtNgayDat);
            this.groupBoxTK.Controls.Add(this.txtMaNV);
            this.groupBoxTK.Controls.Add(this.lbNgayDat);
            this.groupBoxTK.Controls.Add(this.lbMaNV);
            this.groupBoxTK.Controls.Add(this.btnTK);
            this.groupBoxTK.Location = new System.Drawing.Point(13, 12);
            this.groupBoxTK.Name = "groupBoxTK";
            this.groupBoxTK.Size = new System.Drawing.Size(443, 165);
            this.groupBoxTK.TabIndex = 1;
            this.groupBoxTK.TabStop = false;
            this.groupBoxTK.Text = "Thông tin tìm kiếm:";
            // 
            // txtNgayDat
            // 
            this.txtNgayDat.Location = new System.Drawing.Point(110, 84);
            this.txtNgayDat.Name = "txtNgayDat";
            this.txtNgayDat.Size = new System.Drawing.Size(204, 22);
            this.txtNgayDat.TabIndex = 4;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(110, 37);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(204, 22);
            this.txtMaNV.TabIndex = 3;
            // 
            // lbNgayDat
            // 
            this.lbNgayDat.AutoSize = true;
            this.lbNgayDat.Location = new System.Drawing.Point(10, 89);
            this.lbNgayDat.Name = "lbNgayDat";
            this.lbNgayDat.Size = new System.Drawing.Size(69, 17);
            this.lbNgayDat.TabIndex = 2;
            this.lbNgayDat.Text = "Ngày đặt:";
            // 
            // lbMaNV
            // 
            this.lbMaNV.AutoSize = true;
            this.lbMaNV.Location = new System.Drawing.Point(10, 37);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(54, 17);
            this.lbMaNV.TabIndex = 1;
            this.lbMaNV.Text = "Mã NV:";
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(308, 120);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(129, 39);
            this.btnTK.TabIndex = 0;
            this.btnTK.Text = "Nhấn để tìm";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // maDH
            // 
            this.maDH.DataPropertyName = "maDH";
            this.maDH.HeaderText = "Mã ĐH";
            this.maDH.Name = "maDH";
            // 
            // maKH
            // 
            this.maKH.DataPropertyName = "maKH";
            this.maKH.HeaderText = "Mã KH";
            this.maKH.Name = "maKH";
            // 
            // maNV
            // 
            this.maNV.DataPropertyName = "maNV";
            this.maNV.HeaderText = "Mã NV";
            this.maNV.Name = "maNV";
            // 
            // ngayDat
            // 
            this.ngayDat.DataPropertyName = "ngayDat";
            this.ngayDat.HeaderText = "Ngày đặt";
            this.ngayDat.Name = "ngayDat";
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 474);
            this.Controls.Add(this.groupBoxTK);
            this.Controls.Add(this.dgvKetQua);
            this.Name = "frmFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFind";
            this.Load += new System.EventHandler(this.frmFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.groupBoxTK.ResumeLayout(false);
            this.groupBoxTK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox groupBoxTK;
        private System.Windows.Forms.TextBox txtNgayDat;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lbNgayDat;
        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayDat;
    }
}