namespace FrbaHotel.RegistrarConsumible
{
    partial class SeleccionarEstadia
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
            this.estadiasGridView = new System.Windows.Forms.DataGridView();
            this.gpoFiltros = new System.Windows.Forms.GroupBox();
            this.cboRegimen = new System.Windows.Forms.ComboBox();
            this.codigoReservaInput = new System.Windows.Forms.TextBox();
            this.lblCodigoReserva = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTipoRegimen = new System.Windows.Forms.Label();
            this.PisoInput = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.NroHabitacionInput = new System.Windows.Forms.TextBox();
            this.lblNroHabitacion = new System.Windows.Forms.Label();
            this.CodigoReservaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroHabitacionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegimenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.estadiasGridView)).BeginInit();
            this.gpoFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // estadiasGridView
            // 
            this.estadiasGridView.AllowUserToAddRows = false;
            this.estadiasGridView.AllowUserToDeleteRows = false;
            this.estadiasGridView.AllowUserToOrderColumns = true;
            this.estadiasGridView.AllowUserToResizeRows = false;
            this.estadiasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estadiasGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoReservaCol,
            this.NroHabitacionCol,
            this.PisoCol,
            this.RegimenCol,
            this.SeleccionarCol});
            this.estadiasGridView.Location = new System.Drawing.Point(12, 188);
            this.estadiasGridView.Name = "estadiasGridView";
            this.estadiasGridView.ReadOnly = true;
            this.estadiasGridView.RowHeadersWidth = 40;
            this.estadiasGridView.Size = new System.Drawing.Size(546, 290);
            this.estadiasGridView.TabIndex = 5;
            // 
            // gpoFiltros
            // 
            this.gpoFiltros.Controls.Add(this.cboRegimen);
            this.gpoFiltros.Controls.Add(this.codigoReservaInput);
            this.gpoFiltros.Controls.Add(this.lblCodigoReserva);
            this.gpoFiltros.Controls.Add(this.btnLimpiar);
            this.gpoFiltros.Controls.Add(this.btnBuscar);
            this.gpoFiltros.Controls.Add(this.lblTipoRegimen);
            this.gpoFiltros.Controls.Add(this.PisoInput);
            this.gpoFiltros.Controls.Add(this.lblPiso);
            this.gpoFiltros.Controls.Add(this.NroHabitacionInput);
            this.gpoFiltros.Controls.Add(this.lblNroHabitacion);
            this.gpoFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gpoFiltros.Location = new System.Drawing.Point(14, 12);
            this.gpoFiltros.Name = "gpoFiltros";
            this.gpoFiltros.Size = new System.Drawing.Size(544, 160);
            this.gpoFiltros.TabIndex = 6;
            this.gpoFiltros.TabStop = false;
            this.gpoFiltros.Text = "Filtros de busqueda";
            // 
            // cboRegimen
            // 
            this.cboRegimen.FormattingEnabled = true;
            this.cboRegimen.Location = new System.Drawing.Point(137, 68);
            this.cboRegimen.Name = "cboRegimen";
            this.cboRegimen.Size = new System.Drawing.Size(107, 24);
            this.cboRegimen.TabIndex = 15;
            this.cboRegimen.Text = "Seleccionar";
            // 
            // codigoReservaInput
            // 
            this.codigoReservaInput.Location = new System.Drawing.Point(137, 30);
            this.codigoReservaInput.Name = "codigoReservaInput";
            this.codigoReservaInput.Size = new System.Drawing.Size(107, 23);
            this.codigoReservaInput.TabIndex = 13;
            // 
            // lblCodigoReserva
            // 
            this.lblCodigoReserva.AutoSize = true;
            this.lblCodigoReserva.Location = new System.Drawing.Point(17, 33);
            this.lblCodigoReserva.Name = "lblCodigoReserva";
            this.lblCodigoReserva.Size = new System.Drawing.Size(109, 17);
            this.lblCodigoReserva.TabIndex = 12;
            this.lblCodigoReserva.Text = "Codigo Reserva";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(119, 109);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 35);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(400, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 35);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblTipoRegimen
            // 
            this.lblTipoRegimen.AutoSize = true;
            this.lblTipoRegimen.Location = new System.Drawing.Point(17, 71);
            this.lblTipoRegimen.Name = "lblTipoRegimen";
            this.lblTipoRegimen.Size = new System.Drawing.Size(116, 17);
            this.lblTipoRegimen.TabIndex = 8;
            this.lblTipoRegimen.Text = "Tipo de Regimen";
            // 
            // PisoInput
            // 
            this.PisoInput.Location = new System.Drawing.Point(418, 68);
            this.PisoInput.Name = "PisoInput";
            this.PisoInput.Size = new System.Drawing.Size(107, 23);
            this.PisoInput.TabIndex = 3;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(280, 71);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(35, 17);
            this.lblPiso.TabIndex = 2;
            this.lblPiso.Text = "Piso";
            // 
            // NroHabitacionInput
            // 
            this.NroHabitacionInput.Location = new System.Drawing.Point(418, 31);
            this.NroHabitacionInput.Name = "NroHabitacionInput";
            this.NroHabitacionInput.Size = new System.Drawing.Size(107, 23);
            this.NroHabitacionInput.TabIndex = 1;
            // 
            // lblNroHabitacion
            // 
            this.lblNroHabitacion.AutoSize = true;
            this.lblNroHabitacion.Location = new System.Drawing.Point(280, 33);
            this.lblNroHabitacion.Name = "lblNroHabitacion";
            this.lblNroHabitacion.Size = new System.Drawing.Size(129, 17);
            this.lblNroHabitacion.TabIndex = 0;
            this.lblNroHabitacion.Text = "Numero Habitacion";
            // 
            // CodigoReservaCol
            // 
            this.CodigoReservaCol.DataPropertyName = "CodigoReserva";
            this.CodigoReservaCol.HeaderText = "Codigo Reserva";
            this.CodigoReservaCol.Name = "CodigoReservaCol";
            this.CodigoReservaCol.ReadOnly = true;
            // 
            // NroHabitacionCol
            // 
            this.NroHabitacionCol.DataPropertyName = "NroHabitacion";
            this.NroHabitacionCol.HeaderText = "Numero Habitacion";
            this.NroHabitacionCol.Name = "NroHabitacionCol";
            this.NroHabitacionCol.ReadOnly = true;
            // 
            // PisoCol
            // 
            this.PisoCol.DataPropertyName = "Piso";
            this.PisoCol.HeaderText = "Piso";
            this.PisoCol.Name = "PisoCol";
            this.PisoCol.ReadOnly = true;
            // 
            // RegimenCol
            // 
            this.RegimenCol.DataPropertyName = "Regimen";
            this.RegimenCol.HeaderText = "Regimen";
            this.RegimenCol.Name = "RegimenCol";
            this.RegimenCol.ReadOnly = true;
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "Seleccionar";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
            this.SeleccionarCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeleccionarCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SeleccionarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 491);
            this.Controls.Add(this.gpoFiltros);
            this.Controls.Add(this.estadiasGridView);
            this.Name = "SeleccionarEstadia";
            this.Text = "Seleccion de Estadia";
            ((System.ComponentModel.ISupportInitialize)(this.estadiasGridView)).EndInit();
            this.gpoFiltros.ResumeLayout(false);
            this.gpoFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView estadiasGridView;
        private System.Windows.Forms.GroupBox gpoFiltros;
        private System.Windows.Forms.ComboBox cboRegimen;
        private System.Windows.Forms.TextBox codigoReservaInput;
        private System.Windows.Forms.Label lblCodigoReserva;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTipoRegimen;
        private System.Windows.Forms.TextBox PisoInput;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox NroHabitacionInput;
        private System.Windows.Forms.Label lblNroHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoReservaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroHabitacionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegimenCol;
        private System.Windows.Forms.DataGridViewButtonColumn SeleccionarCol;
    }
}