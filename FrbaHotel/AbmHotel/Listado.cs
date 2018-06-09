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

        public Listado()
            :base(new HotelFiltros())
        {
            InitializeComponent();

            this.hotelesGridView.AutoGenerateColumns = false;

            this.hotelesGridView.DataSource = hoteles;

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            nombreInput.DataBindings.Add(new TextBinding(this.Model, "Nombre"));

            ciudadInput.DataBindings.Add(new TextBinding(this.Model, "Ciudad"));

            cantidadEstrellasInput.DataBindings.Add(new Binding("Value", this.Model, "CantidadEstrellas"));
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            InsertarModificar ins = new InsertarModificar(1);
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
                    cmd.Parameters.AddWithValue("@Pais", SqlDbType.NVarChar).Value = Convert.DBNull; // filtros.Pais != null ? filtros.Pais.Nombre : Convert.DBNull;
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
            var targetHotel = this.hotelesGridView.Rows[e.RowIndex].DataBoundItem as Hotel;

            if (e.ColumnIndex == this.hotelesGridView.Columns["SeleccionarCol"].DisplayIndex)
            {
                AbrirModificar(targetHotel);
            } else if (e.ColumnIndex == this.hotelesGridView.Columns["HabilitarCol"].DisplayIndex)
            {
                ToggleHabilitar(targetHotel, (bool)this.hotelesGridView[e.ColumnIndex,e.RowIndex].Value);
            }
        }

        private void AbrirModificar(Hotel hotel)
        {
            InsertarModificar ins = new InsertarModificar(1,hotel);
            this.Hide();

            ins.ShowDialog();

            this.Show();

            if (ins.Result == DialogResult.OK)
                RefreshData();
        }

        private void ToggleHabilitar(Hotel hotel, bool habilitado)
        {
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelHabilitar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.Int).Value = hotel.IdHotel;
                    cmd.Parameters.AddWithValue("@habilitado", SqlDbType.Bit).Value = habilitado;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
