using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rubberduck.Winforms;
using FrbaHotel.AbmHabitacion.Model;
using System.Data.SqlClient;
using FrbaHotel.Utilities;
using FrbaHotel.AbmHotel.Model;
using System.Configuration;

namespace FrbaHotel.AbmHabitacion
{
    public partial class ModificarHabitacion : Form
    {
        private int idHabitacion;
        private int numero;
        private int piso;
        private int hotel;
        private string vista;
        private int tipo;
        private string descripcion;
        private string habilitado;
        public ModificarHabitacion(int id,int numero,int piso,int hotel,string vista, int tipo,string descripcion,string habilitado)
        {
            this.idHabitacion = id;
            this.numero = numero;
            this.piso = piso;
            this.hotel = hotel;
            this.vista = vista;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.habilitado = habilitado;
            InitializeComponent();
            llenarTextBox();


        }

        private void llenarTextBox()
        {
            this.numHabInput.Text = this.numero.ToString();
            this.pisoInput.Text = this.piso.ToString();
            this.hotelInput.Text = this.hotel.ToString();
            this.visExtInput.Text = this.vista;
            this.tipoHabInput.Text = this.tipo.ToString();
            this.descripcionInput.Text = this.descripcion;
            this.habilitadoInput.Text = this.habilitado;

        }
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }
        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (numHabInput.Text == "") { MessageBox.Show("Falta completar la habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return ; }
            if (pisoInput.Text == "") { MessageBox.Show("Falta completar el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (hotelInput.Text == "") { MessageBox.Show("Falta completar el hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (visExtInput.Text == "") { MessageBox.Show("Falta completar la vista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (tipoHabInput.Text == "") { MessageBox.Show("Falta completar el tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (descripcionInput.Text == "") { MessageBox.Show("Falta completar la descripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
           


            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesModificar", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = tipoHabInput.Text;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = numHabInput.Text;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = hotelInput.Text;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = pisoInput.Text;
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = visExtInput.Text;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Char).Value = descripcionInput.Text;
                    cmd.Parameters.AddWithValue("@IdHabitacion", SqlDbType.Int).Value = this.idHabitacion;
                   
                    if (habilitadoInput.Checked)
                    {
                        cmd.Parameters.Add("@Habilitado", SqlDbType.Char, 1).Value = 'S';
                    }
                    else
                    {
                        cmd.Parameters.Add("@Habilitado", SqlDbType.Char, 1).Value = 'N';

                    }
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                      
                        
                        
                 
                            MessageBox.Show("La habitacion se pudo modificar con exito");
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("La habitacion no se puede modificar");
                        this.Hide();
                    }


                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioHabitacion f = new InicioHabitacion();
            f.Show();
        }
    }
}
