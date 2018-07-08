﻿using System;
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
    public partial class AltaHabitacion : Form
    {
        private DialogResult result;

        public DialogResult Result { get { return result; } set { result = value; } }
        private Hotel Hotel { get; set; }


        public AltaHabitacion()
        {
            InitializeComponent();
            cargarTipo();
        }

        private void cargarTipo()
        {
           
                var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

                string consultaBusqueda = String.Format("select distinct * from mmel.TipoHabitacion ");

                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
                con.Open();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = (reader["Descripcion"].ToString());
                    cboTipo.Items.Add(tipo);

                }
                reader.Close();
                con.Close();
            
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {

            if (hotelInput.Text == "") { MessageBox.Show("Falta completar el hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (cboTipo.Text == "") { MessageBox.Show("Falta completar el tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (descripcionInput.Text == "") { MessageBox.Show("Falta completar la descripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int i;
            if (pisoInput.Text == "" || !int.TryParse(pisoInput.Text, out i)) { MessageBox.Show("Error en el campo de piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (numHabInput.Text == "" || !int.TryParse(numHabInput.Text, out i)) { MessageBox.Show("Error en el campo de numero de habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("MMEL.HabitacionesAlta", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", SqlDbType.Int).Value = getTipo();
                    cmd.Parameters.AddWithValue("@NumeroHabitacion", SqlDbType.Int).Value = Int32.Parse(numHabInput.Text);
                    cmd.Parameters.AddWithValue("@IdHotel", SqlDbType.Int).Value = Hotel.IdHotel;
                    cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = Int32.Parse(pisoInput.Text);
                    char vista;
                    if (btnSi.Checked)
                    {
                        vista = 'S';
                    }
                    else
                    {
                        vista = 'N';
                    }
                    cmd.Parameters.AddWithValue("@VistaAlExterior", SqlDbType.Char).Value = vista;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Char).Value = descripcionInput.Text;
                    cmd.Parameters.Add("@MESSAGE", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                        int MENSAJE = Convert.ToInt32(cmd.Parameters["@MESSAGE"].Value);
                        if (MENSAJE == 0)
                        {
                            MessageBox.Show("La habitacion no se puede dar de alta porque ya existe");
                            //this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("La habitacion se dio de alta con exito");
                            this.Hide();
                        }
                    }
                    else
                    {
                        this.Hide();
                    }


                }
            }
        }
        private int getTipo()
        {
            if (cboTipo.SelectedIndex == 0)
                return 1001;
            if (cboTipo.SelectedIndex == 1)
                return 1002;
            if (cboTipo.SelectedIndex == 2)
                return 1003;
            if (cboTipo.SelectedIndex == 3)
                return 1004;
            if (cboTipo.SelectedIndex == 5)
                return 1005;
            return 1001;
        }
        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            ControlResetter.ResetAllControls(this);

            this.Hotel = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void seleccionarHotelBtn_Click(object sender, EventArgs e)
        {
            var abmHotel = new AbmHotel.Listado(true);

            abmHotel.ShowDialog();

            if(abmHotel.DialogResult == DialogResult.OK)
            {
                Hotel = abmHotel.ObjetoResultado;

                this.hotelInput.Text = Hotel.Nombre;
            } 
        }
    }
}
