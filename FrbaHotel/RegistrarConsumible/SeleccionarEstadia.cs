using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class SeleccionarEstadia : Form
    {
        BindingList<Estadia> estadias = new BindingList<Estadia>();

        public SeleccionarEstadia()
            :base(new Estadia())
        {
            InitializeComponent();

            this.estadiasGridView.AutoGenerateColumns = false;

            this.estadiasGridView.DataSource = estadias;

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            codigoReservaInput.DataBindings.Add(new TextBinding(this.Model, "CodigoReserva"));
            
            nroHabitacionInput.DataBindings.Add(new TextBinding(this.Model, "NroHabitacion"));

            pisoInput.DataBindings.Add(new TextBinding(this.Model, "Piso"));

            cboRegimen.DataSource = Regimen.GetAll();

            cboRegimen.DataBindings.Add(new Binding("SelectedValue", this.Model, "idTipoRegimen"));

        }

        private void RefreshData()
        {
            var filtros = (EstadiaFiltros)this.Model;
            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.EstadiaListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoReserva", SqlDbType.NVarChar).Value = filtros.CodigoReserva ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@NroHabitacion", SqlDbType.NVarChar).Value = filtros.NroHabitacion ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.NVarChar).Value = filtros.Piso ?? Convert.DBNull;
                    cmd.Parameters.AddWithValue("@IdTipoRegimen", SqlDbType.int).Value = filtros.IdTipoRegimen ?? Convert.DBNull;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var listaEstadias = dr.MapToList<Usuario>();

                    estadias.Clear();

                    if(listaEstadias != null)
                        listaEstadias.ForEach(es => estadias.Add(es)); // lo hago asi para que no se pierda el binding
                }
            }
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void estadiasGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //toco los headers
                return;

            var targetEstadia = this.estadiasGridView.Rows[e.RowIndex].DataBoundItem as Estadia;

            if (e.ColumnIndex == this.estadiasGridView.Columns["SeleccionarCol"].DisplayIndex)
            {
                AbrirListarConsumibles(targetEstadia);
            } 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this.filtrosGroup);
        }
    }
}
