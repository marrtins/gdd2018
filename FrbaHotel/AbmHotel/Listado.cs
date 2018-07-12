using FrbaHotel.AbmHotel.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class Listado : ModelBoundForm
    {
        BindingList<Hotel> hoteles = new BindingList<Hotel>();

        public DialogResult Resultado { get; set; } //utilizado en seleccion
        public Hotel ObjetoResultado { get; set; }

        public Listado(bool seleccionar)
            : base(new HotelFiltros())
        {
            InitializeComponent();

            this.hotelesGridView.AutoGenerateColumns = false;

            this.hotelesGridView.DataSource = hoteles;

            RegistrarInputs();
        }

        public Listado()
            : this(false)
        {

        }

        private void RegistrarInputs()
        {
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));

            ciudadInput.DataBindings.Add(new TextBinding(this.Model, "Ciudad"));

            cantidadEstrellasInput.DataBindings.Add(new Binding("Value", this.Model, "CantidadEstrellas"));

            paisCombo.DataSource = Paises.GetAllWithDefault();

            paisCombo.DataBindings.Add(new Binding("SelectedValue", this.Model, "idPais"));
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            InsertarModificar ins = new InsertarModificar(LoginData.IdUsuario);
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshData();
        }

        private void RefreshData()
        {
            var filtros = (HotelFiltros)this.Model;
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = filtros.Nombre ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Ciudad", SqlDbType.NVarChar).Value = filtros.Ciudad ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@idPais", SqlDbType.Int).Value = filtros.idPais; // filtros.Pais != null ? filtros.Pais.Nombre : Convert.DBNull;
                    cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = filtros.CantidadEstrellas != 0 ? filtros.CantidadEstrellas : Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaHoteles = dr.MapToList<Hotel>();

                    hoteles.Clear();

                    if(listaHoteles != null)
                        listaHoteles.ForEach(lh => hoteles.Add(lh)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void buscarBtn_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void hotelesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //toco los headers
                return;

            var targetHotel = this.hotelesGridView.Rows[e.RowIndex].DataBoundItem as Hotel;

            if (e.ColumnIndex == this.hotelesGridView.Columns["SeleccionarCol"].DisplayIndex)
            {
                AbrirModificar(targetHotel);
            }

            if (e.ColumnIndex == this.hotelesGridView.Columns["BajaCol"].DisplayIndex)
            {
                AbrirBaja(targetHotel);
            }
        }

        private void AbrirBaja(Hotel targetHotel)
        {
            Baja ins = new Baja(targetHotel.IdHotel);
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshData();
        }

        private void AbrirModificar(Hotel hotel)
        {
            InsertarModificar ins = new InsertarModificar(1,ObjectCloner.DeepCopy(hotel));
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshData();
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this.filtrosGroup);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            this.Close();
        }

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            var hasObj = this.hotelesGridView.SelectedRows.Count > 0;

            if (hasObj) {
                this.DialogResult = DialogResult.OK;    
                this.ObjetoResultado = (Hotel)this.hotelesGridView.SelectedRows[0].DataBoundItem;

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un hotel con el selector");
            }

        }
    }
}
