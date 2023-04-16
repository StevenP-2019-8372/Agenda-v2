using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_datos;
using Capa_entidad;

namespace Capa_negocio
{
    public class Classnegocio
    {
        Classdatos objd = new Classdatos();

        public DataTable N_listar_clientes()
        {
            return objd.D_listar_clientes();
        }

        public DataTable N_buscar_clientes(Classentidad obje)
        {
            return objd.D_buscar_clientes(obje);
        }

        public String N_mantenimiento_cliente(Classentidad obje)
        {
            return objd.D_mantenimiento_clientes(obje);
        }
    }
}
