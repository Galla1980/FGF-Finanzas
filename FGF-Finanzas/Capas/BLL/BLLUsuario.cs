using FGF_Finanzas.Capas.BE;
using FGF_Finanzas.Capas.DAL;
using FGF_Finanzas.Capas.Servicios;
using FGF_Finanzas.Capas.Servicios.SessionManager;
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

        public void ValidarUsuario(string dni, string usuario)
        {
            DataTable dt = ObtenerUsuarios();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["dni"].ToString() == dni)
                {
                    throw new Exception("DNI ya registrado.");
                }
                if (dr[3].ToString() == usuario)
                {
                    throw new Exception("Usuario ya existente.");
                }
            }
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

        public void IniciarSesion(string usuario, string contraseña)
        {
            if (SessionManager.IsLogged()) throw new Exception("Ya ha iniciado sesión.");

            BEUsuario user = null;

            foreach (DataRow item in dalUsuario.ObtenerUsuarios().Rows)
            {
                if (item["usuario"].ToString() == usuario)
                {
                    user = new BEUsuario(item);
                }
            }

            if (user == null) throw new Exception("Credenciales incorrectas.");

            if (user.Bloqueado == true) throw new Exception("Usuario bloqueado");

            if (!Encriptacion.Encriptar(contraseña).Equals(user.Contraseña))
            {
                user.Intento++;

                if (user.Intento == 3)
                {
                    user.Bloqueado = true;
                    user.Intento = 0;
                    dalUsuario.Actualizar(user);
                }
                else { dalUsuario.Actualizar(user); }

                throw new Exception("Credenciales incorrectas.");
            }
            else
            {
                user.Intento = 0;
                dalUsuario.Actualizar(user);
                SessionManager.Login(user);

                //SessionManager.Idioma = user.Idioma_516MF;

                //Evento_516MF evento = Evento_516MF.GenerarEvento(_bllEvento.UltimoEvento_516MF(), 1, "Usuarios", "Login");
                //_bllEvento.GuardarEvento_516MF(evento);
            }
        }
    }
}