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
            this.altaBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rolesGridView = new System.Windows.Forms.DataGridView();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.funcionalidadesGrid = new System.Windows.Forms.DataGridView();
            this.FuncNombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.seleccionarBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolesGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // altaBtn
            // 
            this.altaBtn.Location = new System.Drawing.Point(610, 12);
            this.altaBtn.Name = "altaBtn";
            this.altaBtn.Size = new System.Drawing.Size(75, 23);
            this.altaBtn.TabIndex = 8;
            this.altaBtn.Text = "Alta";
            this.altaBtn.UseVisualStyleBackColor = true;
            this.altaBtn.Click += new System.EventHandler(this.altaBtn_Click);
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
            this.ActivoCol,
            this.SeleccionarCol});
            this.rolesGridView.Location = new System.Drawing.Point(7, 20);
            this.rolesGridView.Name = "rolesGridView";
            this.rolesGridView.ReadOnly = true;
            this.rolesGridView.Size = new System.Drawing.Size(344, 308);
            this.rolesGridView.TabIndex = 0;
            this.rolesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rolesGridView_CellClick);
            this.rolesGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rolesGridView_RowHeaderMouseClick);
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
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 21);
            this.button1.TabIndex = 11;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // seleccionarBtn
            // 
            this.seleccionarBtn.Location = new System.Drawing.Point(562, 406);
            this.seleccionarBtn.Name = "seleccionarBtn";
            this.seleccionarBtn.Size = new System.Drawing.Size(89, 21);
            this.seleccionarBtn.TabIndex = 12;
            this.seleccionarBtn.Text = "Seleccionar";
            this.seleccionarBtn.UseVisualStyleBackColor = true;
            this.seleccionarBtn.Click += new System.EventHandler(this.seleccionarBtn_Click);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 433);
            this.Controls.Add(this.seleccionarBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.altaBtn);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Shown += new System.EventHandler(this.Listado_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rolesGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button altaBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView rolesGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView funcionalidadesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuncNombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeleccionarCol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button seleccionarBtn;
    }
}