using FGF_Finanzas.Capas.BE;
using FGF_Finanzas.Capas.DAL;
using FGF_Finanzas.Capas.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FGF_Finanzas.Capas.BLL
{
    public class BLLUsuario
    {
        DALUsuario dalUsuario;
        public BLLUsuario()
        {
            dalUsuario = new DALUsuario();
        }

        public DataTable ObtenerUsuarios()
        {
            return dalUsuario.ObtenerUsuarios();
        }

        public void AgregarUsuario(BEUsuario usuario)
        {
            string encriptado = Encriptacion.Encriptar(usuario.Contraseña);
            usuario.Contraseña = encriptado;
            dalUsuario.AgregarUsuario(usuario);
        }
    }
}