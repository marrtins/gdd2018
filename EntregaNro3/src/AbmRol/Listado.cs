using FrbaHotel.AbmRol.Model;
using FrbaHotel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class Listado : Form
    {
        BindingList<Rol> roles = new BindingList<Rol>();
        BindingList<Funcionalidad> funcionalidades = new BindingList<Funcionalidad>();

        public Rol ObjetoResultado { get; private set; }


        public Listado(bool seleccionar)
        {
            InitializeComponent();

            this.rolesGridView.AutoGenerateColumns = false;
            this.funcionalidadesGrid.AutoGenerateColumns = false;

            this.rolesGridView.DataSource = roles;
            this.funcionalidadesGrid.DataSource = funcionalidades;

            RefreshRolesData();

            this.rolesGridView.MultiSelect = false;

            this.seleccionarBtn.Visible = seleccionar;
        }

        public Listado()
            : this(false)
        {

        }

        private void RefreshRolesData()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.RolesListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaRoles = dr.MapToList<Rol>();

                    roles.Clear();

                    if (listaRoles != null)
                        listaRoles.ForEach(lh => roles.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void RefreshFuncionalidadesData(int idRol)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.FuncionalidadesDeRol", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = idRol;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaF = dr.MapToList<Funcionalidad>();

                    funcionalidades.Clear();

                    if (listaF != null)
                        listaF.ForEach(lh => funcionalidades.Add(lh)); // lo hago asi para que no se pierda el binding                  
                }
            }
        }
        private void rolesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //toco los headers
                return;

            var selectedItem = this.rolesGridView.Rows[e.RowIndex].DataBoundItem as Rol;


            if (e.ColumnIndex == this.rolesGridView.Columns["SeleccionarCol"].DisplayIndex)
            {
                AbrirModificar(selectedItem);
            } else
            {
                RefreshFuncionalidadesData(selectedItem.idRol);

                selectedItem.Funcionalidades = funcionalidades;
            }

        }

        private void AbrirModificar(Rol selectedItem)
        {
            InsertarModificar ins = new InsertarModificar(ObjectCloner.DeepCopy(selectedItem));
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshRolesData();
        }

        private void rolesGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedItem = this.rolesGridView.Rows[e.RowIndex].DataBoundItem as Rol;

            RefreshFuncionalidadesData(selectedItem.idRol);
        }

        private void altaBtn_Click(object sender, EventArgs e)
        {
            var ins = new InsertarModificar();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshRolesData();
        }

        private void Listado_Shown(object sender, EventArgs e)
        {
            var selectedItem = this.rolesGridView.Rows[0].DataBoundItem as Rol; //el primero

            RefreshFuncionalidadesData(selectedItem.idRol);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            var hasObj = this.rolesGridView.SelectedRows.Count > 0;

            if (hasObj)
            {
                
                this.ObjetoResultado = (Rol)this.rolesGridView.SelectedRows[0].DataBoundItem;

                if (ObjetoResultado.Nombre.ToLower() == "guest")
                    MessageBox.Show("Por favor seleccione un rol distinto de guest");
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un rol con el selector");
            }

        }
    }
}
