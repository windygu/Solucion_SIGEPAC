using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ClsParametros
    {
        //Parámetros
        public string NOMBRE { get; set; }
        public object VALOR { get; set; }
        public SqlDbType TIPODATO { get; set; }
        public int TAMAÑO { get; set; }
        public ParameterDirection DIRECCION { get; set; }

        //CONSTRUCTORES
             //C. Entrada
        public ClsParametros(string nombreParametro, string valorParemetro)
        {
            NOMBRE = nombreParametro;
            VALOR = valorParemetro;
            DIRECCION = ParameterDirection.Input;
        }
             //C. Salida
        public ClsParametros(string nombreParametro, SqlDbType tipoDatoParametro, int tamañoTipoDeDato)
        {
            NOMBRE = nombreParametro;
            TIPODATO = tipoDatoParametro;
            TAMAÑO = tamañoTipoDeDato;
            DIRECCION = ParameterDirection.Output;
        }
    }
}
