using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Dashboard.Conexao;
using System.Configuration;
using Dashboard.Models;
using System.Web.Script.Serialization;

namespace Dashboard.Servicos
{
    /// <summary>
    /// Summary description for WebServiceDashboard
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDashboard : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Produtos>DashbaordProdutos(string mes)
        {
            try
            {

                List<Produtos> lista = new List<Produtos>();
                Contexto con = new Contexto();
                var abrirConexao = con.OpenCon();
                string str = string.Format(@"SELECT Nome, Valores FROM Produtos WHERE Mes =@mes");
                using (SqlCommand cmd = new SqlCommand(str,abrirConexao))
                {
                   cmd.Parameters.AddWithValue("@mes", mes);
                   using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Produtos mod = null;
                        while(dr.Read())
                        {
                            mod = new Produtos();
                            mod.Nome = Convert.ToString(dr["Nome"]);
                            mod.Valores = Convert.ToString(dr["Valores"]);
                            lista.Add(mod);
                        }
                        return lista;
                        
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    Context.Response.Write(js.Serialize(lista));
                }

            }
            catch (SqlException ex)
            {

                throw new Exception("Error to the create the chart " + ex.Message);
            }
           
        }
    }
}
