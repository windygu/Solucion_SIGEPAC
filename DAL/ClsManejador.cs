using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class ClsManejador
    {
        
        //public int insertar(List<string> parametros)
        //{


        //    using (SIGEPACEntity db = new SIGEPACEntity())
        //    {
        //        db.registrarClientes();
        //    }
        //}

        //public void modificar(string nombreSP, List<SqlParameter> parametros)
        //{
        //    db.Cliente.SqlQuery(nombreSP, parametros);
        //    db.SaveChanges();
        //}


        //public List<Cliente> lista(string nombreSP, List<SqlParameterCollection> parametros = null)
        //{

        //    return db.Cliente.SqlQuery(nombreSP, parametros).ToList();
        //}

        //public DataSet lista(string nombreSP, List<SqlParameterCollection> parametros = null)
        //{

        //    return db.Database.SqlQuery<DataSet>(nombreSP, parametros).First();
        //}


        //public string c { get { return c } set { } }
        //public static string c = ConfigurationManager.ConnectionStrings["DAL.Properties.Settings.SIGEPACConnectionString"].ConnectionString;
        //SqlConnection conexion = new SqlConnection(c);


        //Método para abrir conexión
        //void abriConexion()
        //{

        //    if (conexion.State == ConnectionState.Closed) conexion.Open();
        //}

        /*
        Método para cerrar la conexión
        void cerrarConexion()
        {

            if (conexion.State == ConnectionState.Open) conexion.Close();
        }

        //Método para ejecutar SP (insert, update, delete)
        public void ejecutarSP(string nombreSP, List<ClsParametros> lst)
        {
            abriConexion();
            SqlCommand cmd;

            //using (conexion)
            //{
                try
                {

                    //SqlCommand cmd = new SqlCommand(string.Concat(nombreSP, " ", parametrosSP), conexion);
                    cmd = new SqlCommand(nombreSP, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (lst != null)
                    {

                        for (int i = 0; i < lst.Count; i++)
                        {
                            if (lst[i].DIRECCION == ParameterDirection.Input) cmd.Parameters.AddWithValue(lst[i].NOMBRE, lst[i].VALOR);

                            if (lst[i].DIRECCION == ParameterDirection.Output) cmd.Parameters.Add(lst[i].NOMBRE, lst[i].TIPODATO, lst[i].TAMAÑO).Direction = ParameterDirection.Output;
                        }
                    }
                    
                    cmd.ExecuteNonQuery();

                    //Recuperamos parámetro de salida
                    for (int k = 0; k < lst.Count; k++)
                    {
                        if (cmd.Parameters[k].Direction == ParameterDirection.Output)
                        {
                            lst[k].VALOR = cmd.Parameters[k].Value.ToString();
                        }
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }
                
            //}
            cerrarConexion();
        }
        */


        //Método para los listados o Consultas (Select)

        /*
        public DataTable listado (string nombreSP,  List<ClsParametros> lst)
        {
            
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(nombreSP , conexion);
                da.SelectCommand.CommandType = CommandType.Text;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].NOMBRE, lst[i].VALOR);
                    }
                }
                da.Fill(dt);

            }
            catch (Exception e)
            {
                
                throw e;
            }
            
            
            return dt;
        }
        */
    }
}
