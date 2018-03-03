namespace SuperDev
{
    partial class frmEmployee
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
            this.gridEmployee = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupervisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEmployee
            // 
            this.gridEmployee.AllowUserToAddRows = false;
            this.gridEmployee.AllowUserToDeleteRows = false;
            this.gridEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEmployee.AutoGenerateColumns = false;
            this.gridEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCode,
            this.colName,
            this.colDepartmentName,
            this.colSupervisorName,
            this.colEnd});
            this.gridEmployee.DataSource = this.bindingSource1;
            this.gridEmployee.Location = new System.Drawing.Point(12, 50);
            this.gridEmployee.Name = "gridEmployee";
            this.gridEmployee.ReadOnly = true;
            this.gridEmployee.RowTemplate.Height = 24;
            this.gridEmployee.Size = new System.Drawing.Size(928, 498);
            this.gridEmployee.TabIndex = 0;
            this.gridEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmployee_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "#";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Mã NV";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Tên NV";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.HeaderText = "Tên PB";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.ReadOnly = true;
            // 
            // colSupervisorName
            // 
            this.colSupervisorName.DataPropertyName = "SupervisorName";
            this.colSupervisorName.HeaderText = "Người HD";
            this.colSupervisorName.Name = "colSupervisorName";
            this.colSupervisorName.ReadOnly = true;
            // 
            // colEnd
            // 
            this.colEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEnd.HeaderText = "";
            this.colEnd.Name = "colEnd";
            this.colEnd.ReadOnly = true;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 560);
            this.Controls.Add(this.gridEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployee";
            this.Text = "frmEmployeeList";
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupervisorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}