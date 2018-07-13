using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmCliente
{
    public class DatosCliente
    {
        public int idPersona;
        public string nombre;
        public string apellido;
        public string tipodoc;
        public string nrodoc;
        public string mail;
        public string telefono;
        public DateTime fechanac;
        public string nacionalidad;
        public string dircalle;
        public int dirnrocalle;
        public string pais;
        public int dirpiso;
        public string dirdepto;
        public string dirloc;
        public string habilitado;

        public DatosCliente(int idPersona, string nombre, string apellido, string tipodoc, string nrodoc, string mail, string telefono, DateTime fechanac, string nacionalidad, string dircalle, int dirnrocalle, string pais, int dirpiso, string dirdepto, string dirloc, string habilitado)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipodoc = tipodoc;
            this.nrodoc = nrodoc;
            this.mail = mail;
            this.telefono = telefono;
            this.fechanac = fechanac;
            this.nacionalidad = nacionalidad;
            this.dircalle = dircalle;
            this.dirnrocalle = dirnrocalle;
            this.pais = pais;
            this.dirpiso = dirpiso;
            this.dirdepto = dirdepto;
            this.dirloc = dirloc;
            this.habilitado = habilitado;
        }




        public int esErroneo(int id)
        {

            string strCo = ConfigurationManager.AppSettings["stringConexion"];
            SqlConnection con = new SqlConnection(strCo);

            SqlCommand cmd;
            cmd = new SqlCommand("MMEL.esErroneo", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

            cmd.Parameters.Add("@codigoRet", SqlDbType.Int).Direction = ParameterDirection.Output; //0->ok. 1->tipoynroid existe. 2->mail existe

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            cmd.ExecuteNonQuery();

            int codigoRet = int.Parse(cmd.Parameters["@codigoRet"].Value.ToString());

            if (codigoRet == 0)
            {
                return 0;
            }
            else if (codigoRet == 1)
            {
                return 1;

            }
            else if (codigoRet == 2)
            {
                return 2;

            }

            return 0;
        }


    }


}
