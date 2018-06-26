namespace FrbaHotel.RegistrarConsumible
{
    partial class ListarConsumibles
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NombreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuitarCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregarConsumible = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCol,
            this.CostoCol,
            this.CodigoCol,
            this.QuitarCol});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(438, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // NombreCol
            // 
            this.NombreCol.HeaderText = "Nombre";
            this.NombreCol.Name = "NombreCol";
            // 
            // CostoCol
            // 
            this.CostoCol.HeaderText = "Costo";
            this.CostoCol.Name = "CostoCol";
            // 
            // CodigoCol
            // 
            this.CodigoCol.HeaderText = "Codigo";
            this.CodigoCol.Name = "CodigoCol";
            // 
            // QuitarCol
            // 
            this.QuitarCol.HeaderText = "Quitar";
            this.QuitarCol.Name = "QuitarCol";
            // 
            // btnAgregarConsumible
            // 
            this.btnAgregarConsumible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAgregarConsumible.Location = new System.Drawing.Point(335, 173);
            this.btnAgregarConsumible.Name = "btnAgregarConsumible";
            this.btnAgregarConsumible.Size = new System.Drawing.Size(115, 45);
            this.btnAgregarConsumible.TabIndex = 1;
            this.btnAgregarConsumible.Text = "Agregar Consumible";
            this.btnAgregarConsumible.UseVisualStyleBackColor = true;
            // 
            // ListarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 230);
            this.Controls.Add(this.btnAgregarConsumible);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ListarConsumibles";
            this.Text = "Lista de Consumibles Registrados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCol;
        private System.Windows.Forms.DataGridViewButtonColumn QuitarCol;
        private System.Windows.Forms.Button btnAgregarConsumible;
    }
}