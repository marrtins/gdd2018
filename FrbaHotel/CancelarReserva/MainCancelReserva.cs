﻿using System;
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

namespace FrbaHotel.CancelarReserva
{
    public partial class MainCancelReserva : Form
    {
        public MainCancelReserva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {

                int codigores = Int32.Parse(textBox1.Text);
                if (existeReserva(codigores))
                { 
                    CancelarReserva cr = new CancelarReserva(codigores);
                    this.Hide();
                    cr.Show();
                }
            }
            else
            {
                MessageBox.Show("Completar codigo de reserva", "X", MessageBoxButtons.OK);
            }
        }

        private bool existeReserva(int codigoRes)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.existeReserva", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = codigoRes;

            cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.Output; //0->no existe. 1->existe. 
            

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int ret = int.Parse(cmd.Parameters["@ret"].Value.ToString());
            if (ret == 0)
            {
                MessageBox.Show("El codigo no existe. Intente nuevamente", "X", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
