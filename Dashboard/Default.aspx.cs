using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dashboard.Servicos;

namespace Dashboard
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string mes = ddlMes.SelectedItem.Text;
            WebServiceDashboard das = new WebServiceDashboard();
            GridView1.DataSource = das.DashbaordProdutos(mes);
            GridView1.DataBind();
         }
    }
}