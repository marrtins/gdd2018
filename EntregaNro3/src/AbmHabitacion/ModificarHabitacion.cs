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
        private string hotel;
        private string vista;
        private int tipo;
        private int idHotel;
        private string descripcion;
        private string habilitado;
        Form frt;
        public ModificarHabitacion(Form frt,int idHotel,int id,int numero,int piso,string hotel,string vista, int tipo,string descripcion,string habilitado)
        {
            this.frt = frt;
            this.idHotel = idHotel;
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
            cboTipo.Enabled = false;
            hotelInput.Enabled = false;

        }

        private void llenarTextBox()
        {
            this.numHabInput.Text = this.numero.ToString();
            this.pisoInput.Text = this.piso.ToString();
            this.hotelInput.Text = this.hotel;
            
            this.cboTipo.Text = getTipo();
            this.descripcionInput.Text = this.descripcion;
            //this.habilitadoInput.Text = this.habilitado;
            if (habilitado == "S")
            {
                habilitadoInput.Checked = true;
            }else
                habilitadoInput.Checked = false;
            if (vista == "S")
                optSi.Checked = true;
            else
                optNo.Checked = true;

        }
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

            this.hotel = null;
        }
        private string getTipo()
        {
            if (tipo == 1001)
                return "Base Simple";
            if (tipo == 1002)
                return "Base Doble";
            if (tipo == 1003)
                return "Base Triple";
            if (tipo == 1004)
                return "Base Cuadruple";
            else
                return "King";
        }
        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (hotelInput.Text == "") { MessageBox.Show("Falta completar el hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            
            if (descripcionInput.Text == "") { MessageBox.Show("Falta completar la descripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int i;
            if (pisoInput.Text == "" || !int.TryParse(pisoInput.Text, out i)) { MessageBox.Show("Error en el campo de piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numHabInput.Text == "" || !int.TryParse(numHabInput.Text, out i)) { MessageBox.Show("Error en el campo de numero de habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesModificar", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = tipo;
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = numHabInput.Text;
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = idHotel;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = pisoInput.Text;
                    
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Char).Value = descripcionInput.Text;
                    cmd.Parameters.AddWithValue("@IdHabitacion", SqlDbType.Int).Value = this.idHabitacion;

                    if (optSi.Checked)
                    {
                        cmd.Parameters.Add("@VistaAlExterior", SqlDbType.Char, 1).Value = 'S';
                    }
                    else
                    {
                        cmd.Parameters.Add("@VistaAlExterior", SqlDbType.Char, 1).Value = 'N';

                    }

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
                        this.Close();
                        frt.Show();
                    }
                    else
                    {
                        MessageBox.Show("La habitacion no se puede modificar");
                        //this.Hide();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void seleccionarHotelBtn_Click(object sender, EventArgs e)
        {
            var abmHotel = new AbmHotel.Listado(true);

            abmHotel.ShowDialog();

            if (abmHotel.DialogResult == DialogResult.OK)
            {
                var hotelObj = abmHotel.ObjetoResultado;

                this.idHotel = hotelObj.IdHotel;
                this.hotelInput.Text = hotelObj.Nombre;
            }
        }
    }
}
