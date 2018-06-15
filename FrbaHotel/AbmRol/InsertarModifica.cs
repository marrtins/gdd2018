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
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));
            Register(ErrorLabel.For(nombreInput, Alignment.Bottom, 2));           
        }

        public void Afectar(string procedureName)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            var rol = this.Model as Rol;

            rol.Activo = activoCheck.Checked ? "S" : "N";

            var funcionalidadesTable = new DataTable();
            funcionalidadesTable.Columns.Add("Id", typeof(int));
            funcionalidades.ForEach(f => funcionalidadesTable.Rows.Add(f.idFuncionalidad));


            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = rol.Nombre;
                    var pList = new SqlParameter("@IdsFuncionalidades", SqlDbType.Structured);
                    pList.TypeName = "MMEL.IdList";
                    pList.Value = funcionalidadesTable;
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

    }
}
