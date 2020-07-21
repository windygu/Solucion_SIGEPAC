using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using DAL;
using EN;

namespace BL
{
    public abstract class Gestion
    {
        public SIGEPACEntities context = new SIGEPACEntities();
        public ObjectParameter salida = new ObjectParameter("msj", typeof(string));
        public abstract string registrar(ENCliente p = null);
        public abstract string actualizar(int? id, ENCliente p = null);
        public abstract string eliminar(int id);
        public abstract List<object> lista(string nombre = null, string apellido = null, int? id = null, string dui = null);
        public abstract object buscar(int? id=null);

    }
}
