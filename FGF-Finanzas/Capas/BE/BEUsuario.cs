using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FGF_Finanzas.Capas.BE
{
    public class BEUsuario
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public BEUsuario()
        {

        }
        public BEUsuario(string dni, string nombre, string apellido, string username, string password)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Usuario = username;
            Contraseña = password;
        }
    }
}