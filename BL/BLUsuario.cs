using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class BLUsuario
    {
        SIGEPACEntities context = new SIGEPACEntities();
        ENUsuario c = new ENUsuario();
        Usuario c2 = new Usuario();

        public ENUsuario buscarUsuario (string usuario, string clave)
        {
            c2 = context.Usuario.Where(u => u.Usuario1 == usuario && u.Clave == clave).FirstOrDefault();
            if (c2 != null)
            {
                c.Usuario = c2.Usuario1;
                c.Clave = c2.Clave;
                return c;
            }
            else return null;
        }
    }
}
