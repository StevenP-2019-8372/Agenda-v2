using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_entidad;


namespace Capa_datos
{
    public class Classdatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_clientes()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_clientes",cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable D_buscar_clientes(Classentidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_clientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public String D_mantenimiento_clientes(Classentidad obje)
        {

            string accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_clientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obje.id);
            cmd.Parameters.AddWithValue("@Nombre", obje.nombre);
            cmd.Parameters.AddWithValue("@Apellido", obje.apellido);
            cmd.Parameters.AddWithValue("@Direccion", obje.direccion);
            cmd.Parameters.AddWithValue("@FechaDN", obje.fechadn);
            cmd.Parameters.AddWithValue("@Movil", obje.movil);
            cmd.Parameters.AddWithValue("@Telefono", obje.telefono);
            cmd.Parameters.AddWithValue("@Correo", obje.correo);
            cmd.Parameters.AddWithValue("@Genero", obje.genero);
            cmd.Parameters.AddWithValue("@Estado", obje.estado);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;

        }

    }
}
