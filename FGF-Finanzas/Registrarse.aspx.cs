using FGF_Finanzas.Capas.BE;
using FGF_Finanzas.Capas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FGF_Finanzas
{
    public partial class Registrarse : System.Web.UI.Page
    {
        BLLUsuario bllUsuario = new BLLUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            try
            {
                bllUsuario.ValidarUsuario(DniUsuario.Text, UserName.Text);

                BEUsuario usuario = new BEUsuario(DniUsuario.Text, Nombre.Text, Apellido.Text, UserName.Text.Trim(), Password.Text);
                bllUsuario.AgregarUsuario(usuario);
                Response.Redirect("~/Login.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}