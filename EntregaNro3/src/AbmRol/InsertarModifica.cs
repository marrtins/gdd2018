using FrbaHotel.AbmRol.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
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
    public partial class InsertarModificar : ModelBoundForm
    {
        public DialogResult Result { get; set; }

        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        private Action accion;


        private Rol Rol
        {
            get
            {
                return this.Model as Rol;
            }
        }

        private bool tieneFuncionalidades
        {
            get
            {
                return funcionalidades.Count > 0;
            }
        }

        public InsertarModificar()
            : base(new Rol())
        {
            InitializeComponent();
            this.Text = "Insertar";

            RegistrarInputs();

            accion = Insertar;
        }

        public InsertarModificar(Rol rol)
            : base(rol)
        {
            InitializeComponent();
            this.Text = "Modificar";

            RegistrarInputs();

            accion = Modificar;
        }

        public void RegistrarInputs()
        {
            RefreshFuncionalidadesData();

            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));
            Register(ErrorLabel.For(nombreInput, Alignment.Bottom, 2));

            this.funcionalidadesCombo.DataSource = funcionalidades;

            funcionalidadesGrid.AutoGenerateColumns = false;
            funcionalidadesGrid.DataSource = Rol.Funcionalidades;

        }

        private void RefreshFuncionalidadesData()
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.[FuncionalidadesListar]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = filtros.Nombre ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaFuncs = dr.MapToList<Funcionalidad>();

                    funcionalidades.Clear();

                    if (listaFuncs != null)
                        listaFuncs.ForEach(lh => funcionalidades.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }


        public void Afectar(string procedureName)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            var rol = this.Model as Rol;

            rol.Activo = activoCheck.Checked ? "S" : "N";

            var funcionalidadesTable = new DataTable();
            funcionalidadesTable.Columns.Add("Id", typeof(int));
            rol.Funcionalidades.ToList().ForEach(f => funcionalidadesTable.Rows.Add(f.idFuncionalidad));


            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    if(rol.idRol != 0) //estoy modificando
                        cmd.Parameters.AddWithValue("@idRol", SqlDbType.Int).Value = rol.idRol;

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = rol.Nombre;
                    var pList = new SqlParameter("@funcionalidades_ids", SqlDbType.Structured);
                    pList.TypeName = "MMEL.IdList";
                    pList.Value = funcionalidadesTable;
                    cmd.Parameters.Add(pList);
                    cmd.Parameters.AddWithValue("@Activo", SqlDbType.VarChar).Value = rol.Activo;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    //TODO con ese reader hay que almacenar el ID
                }
            }
        }

        public void Insertar()
        {
            Afectar("MMEL.RolCrear");
        }
        public void Modificar()
        {
            Afectar("MMEL.RolModificar");
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            Rol.Funcionalidades.Add(funcionalidadesCombo.SelectedItem as Funcionalidad);

            this.agregarBtn.Enabled = false;
            this.quitarBtn.Enabled = true;

        }

        private void funcionalidadesCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            var tieneFunc = Rol.Funcionalidades.Any(f => f.idFuncionalidad == (funcionalidadesCombo.SelectedItem as Funcionalidad).idFuncionalidad);

            this.agregarBtn.Enabled = !tieneFunc;
            this.quitarBtn.Enabled = tieneFunc;
        }

        private void quitarBtn_Click(object sender, EventArgs e)
        {
            var indexOf = Rol.Funcionalidades.IndexOf(Rol.Funcionalidades.First(f => f.idFuncionalidad == (funcionalidadesCombo.SelectedItem as Funcionalidad).idFuncionalidad));

            Rol.Funcionalidades.RemoveAt(indexOf);

            this.quitarBtn.Enabled = false;
            this.agregarBtn.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.accion();

            this.Result = DialogResult.OK;

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.None;

            this.Close();
        }

        private void funcionalidadesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var selectedItem = this.funcionalidadesGrid.Rows[e.RowIndex].DataBoundItem as Funcionalidad;


            funcionalidadesCombo.SelectedValue = selectedItem.idFuncionalidad;
        }
    }
}
