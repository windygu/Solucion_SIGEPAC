using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;
namespace BL
{
    public class BLMarca : Gestion
    {
        Marca m = new Marca();
        ENMarca m2 = new ENMarca();
        public override string registrar(ENCliente c = null, ENMarca marca = null)
        {
            context.registrarMarcas(marca.Nombre, marca.Comentario, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override string actualizar(int? id, ENCliente c = null, ENMarca marca = null)
        {
            context.modificarMarcas(id, marca.Nombre, marca.Comentario, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override string eliminar(int id)
        {
            context.eliminarMarcas(id, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override List<object> lista(string nombre = null, string apellido = null, int? id = null, string dui = null)
        {
            if (nombre != null)
            {
                return context.listadoMarcas(null, nombre).ToList<object>();

            }
            else if (id != null)
            {
                return context.listadoMarcas(id, null).ToList<object>(); ;
            }
            else return context.listadoMarcas(null, null).ToList<object>();
        }

        public override object buscar(int? id)
        {
            m = context.Marca.Find(id);
            m2.Nombre = m.Nombre;
            m2.Comentario = m.Comentario;
            return m2;
        }
    }
}
