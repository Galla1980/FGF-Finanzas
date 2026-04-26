using FGF_Finanzas.Capas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FGF_Finanzas
{
    public partial class Usuarios : System.Web.UI.Page
    {
        BLLUsuario bllUsuario = new BLLUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            grillaUsuarios.DataSource = null;
            grillaUsuarios.DataSource = bllUsuario.ObtenerUsuarios();
            grillaUsuarios.DataBind();
        }
    }
}