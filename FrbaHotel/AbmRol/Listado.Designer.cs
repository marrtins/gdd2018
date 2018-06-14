namespace FrbaHotel.AbmRol
{
    partial class Listado
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
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rolesGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionalidadesGrid = new System.Windows.Forms.DataGridView();
            this.FuncNombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolesGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(610, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Alta";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rolesGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 334);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // rolesGridView
            // 
            this.rolesGridView.AllowUserToAddRows = false;
            this.rolesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rolesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rolesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCol,
            this.ActivoCol});
            this.rolesGridView.Location = new System.Drawing.Point(7, 20);
            this.rolesGridView.Name = "rolesGridView";
            this.rolesGridView.ReadOnly = true;
            this.rolesGridView.Size = new System.Drawing.Size(344, 308);
            this.rolesGridView.TabIndex = 0;
            this.rolesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rolesGridView_CellClick);
            this.rolesGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rolesGridView_RowHeaderMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.funcionalidadesGrid);
            this.groupBox2.Location = new System.Drawing.Point(404, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 334);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funcionalidades de rol";
            // 
            // NombreCol
            // 
            this.NombreCol.DataPropertyName = "Nombre";
            this.NombreCol.HeaderText = "Nombre";
            this.NombreCol.Name = "NombreCol";
            this.NombreCol.ReadOnly = true;
            // 
            // ActivoCol
            // 
            this.ActivoCol.DataPropertyName = "Activo";
            this.ActivoCol.HeaderText = "Activo";
            this.ActivoCol.Name = "ActivoCol";
            this.ActivoCol.ReadOnly = true;
            // 
            // funcionalidadesGrid
            // 
            this.funcionalidadesGrid.AllowUserToAddRows = false;
            this.funcionalidadesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.funcionalidadesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionalidadesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FuncNombreCol});
            this.funcionalidadesGrid.Location = new System.Drawing.Point(7, 20);
            this.funcionalidadesGrid.Name = "funcionalidadesGrid";
            this.funcionalidadesGrid.ReadOnly = true;
            this.funcionalidadesGrid.Size = new System.Drawing.Size(240, 308);
            this.funcionalidadesGrid.TabIndex = 0;
            // 
            // FuncNombreCol
            // 
            this.FuncNombreCol.DataPropertyName = "Descripcion";
            this.FuncNombreCol.HeaderText = "Descripcion";
            this.FuncNombreCol.Name = "FuncNombreCol";
            this.FuncNombreCol.ReadOnly = true;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Name = "Listado";
            this.Text = "Listado";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rolesGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView rolesGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivoCol;
        private System.Windows.Forms.DataGridView funcionalidadesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuncNombreCol;
    }
}