using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core.Objects;
using EN;
using DAL;

namespace BL
{

    public class BLCliente : Gestion
    {
        Cliente c = null;
        ENCliente c2 = new ENCliente();
        public override string registrar(ENCliente c = null, ENMarca m = null)
        {
            context.registrarClientes(c.primerNombre, c.segundoNombre, c.primerApellido,
                c.segundoApellido, c.dui, c.direccion, c.telefono, c.correo, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override string actualizar(int? id, ENCliente c = null, ENMarca m = null)
        {
            context.modificarClientes(id, c.primerNombre, c.segundoNombre, c.primerApellido,
                c.segundoApellido, c.dui, c.direccion, c.telefono,
                c.correo, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override string eliminar(int id)
        {
            context.eliminarClientes(id, salida);
            context.SaveChanges();
            return salida.Value.ToString();
        }

        public override List<object> lista(string nombre = null, string apellido = null, int? id = null, string dui = null)
        {
            if (nombre!=null)
            {
                return context.Buscar_Clientes(nombre).ToList<object>();
             
            }
            else if (apellido != null)
            {
                
                return context.listadoClientes(null, null, apellido, null).ToList<object>();
            }
            else if (id != null)
            {
                
                return context.listadoClientes(id, null, null, null).ToList<object>(); ;
            }
            else if (dui != null)
            {
                return context.listadoClientes(null, null, null, dui).ToList<object>();
            }
            else return context.listadoClientes(null, null, null, null).ToList<object>();

        }

        public override object buscar(int? id)
        {
            
                c = context.Cliente.Find(id);
                ENCliente c2 = new ENCliente();
                c2.primerNombre = c.PrimerNombre;
                c2.segundoNombre = c.SegundoNombre;
                c2.primerApellido = c.PrimerApellido;
                c2.segundoApellido = c.SegundoApellido;
                c2.dui = c.Dui;
                c2.direccion = c.Direccion;
                c2.telefono = c.Telefono;
                c2.correo = c.Correo;
                return c2;
        }

        public List<object> listaConPedido()
        {
            return (from c in context.Cliente join p in context.Pedido on c.Id equals p.IdCliente
              select new
              {
                  Id = c.Id,
                  PrimerNombre = c.PrimerNombre,
                  SegundoNombre = c.SegundoNombre,
                  PrimerApellido = c.PrimerApellido,
                  SegundoApellido = c.SegundoApellido,
                  Dui = c.Dui,
                  Direccion = c.Direccion,
                  Telefono = c.Telefono,
                  Correo = c.Correo
              }).ToList<object>();
        }
    }
}
