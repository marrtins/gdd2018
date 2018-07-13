using FrbaHotel.Utilities;
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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class MainRegEstadia : Form
    {
        int idEst;
        DateTime fechaDesde;
        
        public MainRegEstadia()
        {
            InitializeComponent();
            
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtDatosOk())
            {
                if (existeReserva())
                {
                    
                    registrarCheckIn();
                    registrarHuespedes();

                }
            }
            
            //chequeo q la estadia no este inconsistente(si la estadia ya existe, mando a modificar. no existe-> la creo)
            //registro el check in
        }

        private void registrarHuespedes()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.getCantHuespedes", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@codigoReserva", SqlDbType.Int).Value = Int32.Parse(txtCodigoRes.Text);
            cmd.Parameters.Add("@cantPersonas", SqlDbType.Int).Direction = ParameterDirection.Output;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int cantPersonas = int.Parse(cmd.Parameters["@cantPersonas"].Value.ToString());

            if (cantPersonas > 1)
            {
                IngresarCliente ic = new IngresarCliente(this, cantPersonas-1);
                this.Hide();
                ic.Show();
            }
            else
            {
                MessageBox.Show("Fecha check in ingresada exitosamente", "X", MessageBoxButtons.OK);
            }
            
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            if (txtDatosOk())
            {
                registrarCheckOut();
            }
            

        }
        private bool txtDatosOk()
        {
            int i;
            if (txtCodigoRes.Text == "" || !int.TryParse(txtCodigoRes.Text, out i))
            {
                MessageBox.Show("Complete el codigo de reserva correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }
        private bool existeReserva()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.existeReserva", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = Int32.Parse(txtCodigoRes.Text);
            cmd.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.Output; //1-> existe / 0-> no existe
            cmd.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Direction = ParameterDirection.Output;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int ret = int.Parse(cmd.Parameters["@ret"].Value.ToString());
            
            if (ret == 0)
            {
                MessageBox.Show("El codigo de reserva no existe/La reserva no esta vigente. Intente nuevamente", "X", MessageBoxButtons.OK);
                return false;
            }
            int idHotel = int.Parse(cmd.Parameters["@idHotel"].Value.ToString());
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);
            fechaDesde = DateTime.Parse(cmd.Parameters["@fechaDesde"].Value.ToString());
            if (fechaDesde != value)
            {
                MessageBox.Show("El check in solo puede realizarse el día estípulado en la reserva", "X", MessageBoxButtons.OK);
                return false;
            }
            if (idHotel!= LoginData.Hotel.IdHotel)
            {
                MessageBox.Show("No puede realizarse la operación en este hotel. La reserva pertenece a otro establecimiento de la cadena", "X", MessageBoxButtons.OK);
                return false;
            }
            
            
            return true;
        }


        private void registrarCheckIn()
        {
            string consultaBusqueda = String.Format("select top 1 idEstadia,CodigoReserva,FechaCheckIN,FechaCheckOUT,Consistente,FechaDesde from mmel.Estadia e,mmel.Reserva r where  CodigoReserva={0} and e.idReserva=r.idReserva and (EstadoReserva='CO' or EstadoReserva='RINCF') ", txtCodigoRes.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int idEstadia, codRes;
                
                char consistente='\n';
                while (reader.Read())
                {
                    
                    idEstadia = Int32.Parse(reader["idEstadia"].ToString());
                    codRes = Int32.Parse(reader["CodigoReserva"].ToString());
                    DateTime fechaCheckIn = DateTime.Parse(reader["fechaCheckIn"].ToString());
                    
                    consistente = Char.Parse(reader["consistente"].ToString());
                    idEst = idEstadia;


                    actualizar(idEstadia,codRes);
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    /* if (consistente == 'S')
                    {
                        ModificarCheckinConsistente mcc = new ModificarCheckinConsistente(fechaCheckIn, idEstadia, this);
                        mcc.Show();
                        this.Hide();
                        return;
                    }
                    else if (consistente == 'N')
                    {
                        DateTime fechaCheckOut = DateTime.Parse(reader["fechaCheckOut"].ToString());
                        ModificarCheckInInconsistente mic = new ModificarCheckInInconsistente(fechaCheckIn, fechaCheckOut, idEstadia,this);
                        mic.Show();
                        this.Hide();
                        return;
                    }*/

                }
                
            }
            else
            {
                strCo = ConfigurationManager.AppSettings["stringConexion"];
                con = new SqlConnection(strCo);
                
                cmd = new SqlCommand("MMEL.realizarCheckIn", con);
                DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codigoRes", SqlDbType.Int).Value = Int32.Parse(txtCodigoRes.Text);

                cmd.Parameters.Add("@fechaCheckIn", SqlDbType.DateTime).Value = value;
                cmd.Parameters.Add("@idRecepQueModifica", SqlDbType.Int).Value = LoginData.IdUsuario;

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Fecha check in ingresada exitosamente", "X", MessageBoxButtons.OK);           
                
            }

        }private void actualizar(int idest,int codRes)
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckIn", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idest;
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);
            cmd.Parameters.Add("@fechaCheckIn", SqlDbType.DateTime).Value = LoginData.SystemDate;
            cmd.Parameters.Add("@iduserQueModifica", SqlDbType.Int).Value = LoginData.IdUsuario;
            cmd.Parameters.Add("@rta", SqlDbType.Int).Direction = ParameterDirection.Output;
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int rta = int.Parse(cmd.Parameters["@rta"].Value.ToString());
            if (rta == 1)
            {
                MessageBox.Show("Fecha check in modificada exitosamente", "X", MessageBoxButtons.OK);
                this.Hide();
                //ftr.Show();
            }
            else
            {
                MessageBox.Show("Solo puede realizarse check in el día que fue reservado", "X", MessageBoxButtons.OK);
                //MessageBox.Show("Fecha check in modificada exitosamente", "X", MessageBoxButtons.OK);
                //this.Hide();
                //ftr.Show();
            }
        }
        private void realizarCheckOut()
        {
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.actualizarCheckOut", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstadia", SqlDbType.Int).Value = idEst;
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateKey"]);

            cmd.Parameters.Add("@fechaCheckOut", SqlDbType.DateTime).Value = value;
            cmd.Parameters.Add("@iduserQueModifica", SqlDbType.Int).Value = LoginData.IdUsuario;


            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();


            MessageBox.Show("Fecha check out modificada exitosamente", "OK", MessageBoxButtons.OK);
            
        }
        private void registrarCheckOut()
        {
            string consultaBusqueda = String.Format("select top 1 idHotel,idEstadia,CodigoReserva,FechaCheckIN,FechaCheckOUT,Consistente from mmel.Estadia e,mmel.Reserva r where  CodigoReserva={0} and e.idReserva=r.idReserva and (r.EstadoReserva='RCICF' or r.EstadoReserva='RCI' or r.EstadoReserva='RINCF') ", txtCodigoRes.Text);
            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);
            SqlCommand cmd = new SqlCommand(consultaBusqueda, con);
            con.Open();
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int idEstadia, codRes,idHotel;

                char consistente = '\n';
                while (reader.Read())
                {

                    idEstadia = Int32.Parse(reader["idEstadia"].ToString());
                    idHotel = Int32.Parse(reader["idHotel"].ToString());
                    codRes = Int32.Parse(reader["CodigoReserva"].ToString());
                    DateTime fechaCheckIn = DateTime.Parse(reader["fechaCheckIn"].ToString());
                    //DateTime fechaCheckOut = DateTime.Parse(reader["fechaCheckOut"].ToString());
                    consistente = Char.Parse(reader["consistente"].ToString());

                    /*if (consistente == 'S')
                    {
                        ModificarCheckOutConsistente mcc = new ModificarCheckOutConsistente(fechaCheckIn, idEstadia, this);
                        mcc.Show();
                        this.Hide();
                        return;
                    }
                    else if (consistente == 'N')
                    {
                        //MessageBox.Show("No se pudo realizar la operación por fecha de check in inconsistente. Modifique el CHECK IN primero", "X", MessageBoxButtons.OK);
                        ModificarCheckOutConsistente mcc = new ModificarCheckOutConsistente(fechaCheckIn, idEstadia, this);
                        mcc.Show();
                        this.Hide();
                        return;
                    }*/
                    idEst = idEstadia;

                    if (idHotel != LoginData.Hotel.IdHotel)
                    {
                        MessageBox.Show("No puede registrarse la estadia de otro hotel");
                        return;
                    }

                    realizarCheckOut();

                }

            }
            else
            {
                MessageBox.Show("Realizar el Check-In antes de proceder", "X", MessageBoxButtons.OK);

            }

        }

        private void MainRegEstadia_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Inicio f1 = new Inicio();
            //f1.Show();
        }
    }
}
