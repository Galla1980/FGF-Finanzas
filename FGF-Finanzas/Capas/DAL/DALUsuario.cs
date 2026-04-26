using FGF_Finanzas.Capas.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FGF_Finanzas.Capas.DAL
{
    public class DALUsuario : DALAbstracta
    {
        public DALUsuario() { }

        public DataTable ObtenerUsuarios()
        {
            string query = "SELECT * FROM Usuario";
            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conexion);
            adapter.Fill(dt);
            return dt;
        }

        public void AgregarUsuario(BEUsuario usuario)
        {
            DataTable dt = ObtenerUsuarios();
            dt.Rows.Add(new object[] { usuario.DNI, usuario.Nombre, usuario.Apellido, usuario.Usuario, usuario.Contraseña});

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Usuario", _conexion);

            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

            adapter.Update(dt);
        }
    }
}