using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class SeleccionUsuario : Form
    {
        private DataGridView dgCustomer;
        private GroupBox gboFiltros;
        private Button btnLimpiar;
        private Button btnBuscar;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtNroId;
        private Label lblNroId;
        private ComboBox cboTipoId;
        private Label lblTipo;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private ComboBox comboBox2;
        private Label lblUsername;
        private Label lblNombre;
    
        public SeleccionUsuario()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgCustomer = new System.Windows.Forms.DataGridView();
            this.gboFiltros = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNroId = new System.Windows.Forms.TextBox();
            this.lblNroId = new System.Windows.Forms.Label();
            this.cboTipoId = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.gboFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCustomer
            // 
            this.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomer.Location = new System.Drawing.Point(35, 250);
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.Size = new System.Drawing.Size(650, 200);
            this.dgCustomer.TabIndex = 3;
            // 
            // gboFiltros
            // 
            this.gboFiltros.Controls.Add(this.comboBox2);
            this.gboFiltros.Controls.Add(this.lblUsername);
            this.gboFiltros.Controls.Add(this.btnLimpiar);
            this.gboFiltros.Controls.Add(this.btnBuscar);
            this.gboFiltros.Controls.Add(this.txtEmail);
            this.gboFiltros.Controls.Add(this.lblEmail);
            this.gboFiltros.Controls.Add(this.txtNroId);
            this.gboFiltros.Controls.Add(this.lblNroId);
            this.gboFiltros.Controls.Add(this.cboTipoId);
            this.gboFiltros.Controls.Add(this.lblTipo);
            this.gboFiltros.Controls.Add(this.txtApellido);
            this.gboFiltros.Controls.Add(this.lblApellido);
            this.gboFiltros.Controls.Add(this.txtNombre);
            this.gboFiltros.Controls.Add(this.lblNombre);
            this.gboFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gboFiltros.Location = new System.Drawing.Point(35, 30);
            this.gboFiltros.Name = "gboFiltros";
            this.gboFiltros.Size = new System.Drawing.Size(650, 200);
            this.gboFiltros.TabIndex = 2;
            this.gboFiltros.TabStop = false;
            this.gboFiltros.Text = "Filtros de búsqueda";
            this.gboFiltros.Enter += new System.EventHandler(this.gboFiltros_Enter);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(420, 90);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(125, 24);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.Text = "Seleccionar";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(270, 90);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(92, 17);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Rol Asignado";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(100, 135);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 50);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(380, 135);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(150, 50);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(125, 23);
            this.txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(35, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // txtNroId
            // 
            this.txtNroId.Location = new System.Drawing.Point(420, 60);
            this.txtNroId.Name = "txtNroId";
            this.txtNroId.Size = new System.Drawing.Size(125, 23);
            this.txtNroId.TabIndex = 7;
            // 
            // lblNroId
            // 
            this.lblNroId.AutoSize = true;
            this.lblNroId.Location = new System.Drawing.Point(270, 60);
            this.lblNroId.Name = "lblNroId";
            this.lblNroId.Size = new System.Drawing.Size(141, 17);
            this.lblNroId.TabIndex = 6;
            this.lblNroId.Text = "Nro. de Identificación";
            this.lblNroId.Click += new System.EventHandler(this.lblNro_Click);
            // 
            // cboTipoId
            // 
            this.cboTipoId.FormattingEnabled = true;
            this.cboTipoId.Location = new System.Drawing.Point(420, 30);
            this.cboTipoId.Name = "cboTipoId";
            this.cboTipoId.Size = new System.Drawing.Size(125, 24);
            this.cboTipoId.TabIndex = 5;
            this.cboTipoId.Text = "Seleccionar";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(270, 30);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(142, 17);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo de Identificación";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(115, 60);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(125, 23);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(35, 60);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(115, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(125, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(35, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // SeleccionUsuario
            // 
            this.ClientSize = new System.Drawing.Size(734, 486);
            this.Controls.Add(this.dgCustomer);
            this.Controls.Add(this.gboFiltros);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Name = "SeleccionUsuario";
            this.Text = "Seleccionar Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.gboFiltros.ResumeLayout(false);
            this.gboFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        private void gboFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void lblNro_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
