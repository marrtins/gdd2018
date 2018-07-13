using FrbaHotel.AbmHotel.Model;
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

namespace FrbaHotel.AbmHotel
{
    public partial class Baja : ModelBoundForm
    {
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }

        readonly int idHotel;

        public Baja(int idHotel)
            :base(new HotelBaja())
        {
            this.idHotel = idHotel;
            InitializeComponent();

            RegistrarInputs();
        }

        private void RegistrarInputs()
        {
            fechaInicioDtp.DataBindings.Add(new Binding("Text", this.Model, "FechaDesde"));
            Register(ErrorLabel.For(fechaInicioDtp, Alignment.Bottom, 2));

            fechaFinDtp.DataBindings.Add(new Binding("Text", this.Model, "FechaHasta"));
            Register(ErrorLabel.For(fechaFinDtp, Alignment.Bottom, 2));

            motivoInput.DataBindings.Add(new TextBinding(this.Model, "Motivo"));
            Register(ErrorLabel.For(motivoInput, Alignment.Bottom, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
            var baja = (HotelBaja)this.Model;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HotelDarBaja", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idHotel", SqlDbType.VarChar).Value = idHotel;
                    cmd.Parameters.AddWithValue("@FechaInicio", SqlDbType.DateTime).Value = baja.FechaDesde;
                    cmd.Parameters.AddWithValue("@FechaFin", SqlDbType.DateTime).Value = baja.FechaHasta;
                    cmd.Parameters.AddWithValue("@Motivo", SqlDbType.VarChar).Value = baja.Motivo;

                    con.Open();
                    var dr = cmd.ExecuteReader();

                    var res = 0;

                    if (dr.HasRows)
                    {
                        dr.Read();

                        res = int.Parse(dr["Resultado"].ToString()); //si res = -1 es fallido

                        if(res == -1)
                        {
                            MessageBox.Show("No se puede realizar la baja ya que existen fechas de reserva superpuestas");
                        }
                        else
                        {
                            MessageBox.Show("Baja registrada exitosamente");

                            this.DialogResult = DialogResult.OK;

                            this.Close();
                        }

                    }
                }
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            this.Close();
        }
    }
}
