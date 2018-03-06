using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Dashboard
{
    public partial class Grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string obterDados()
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP\SQLSERVERLOCAL;Initial Catalog=DbChart;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Linguagem,Pupolaridade FROM Cursos ORDER BY Pupolaridade DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexao;
            conexao.Open();

            DataTable dados = new DataTable();
            dados.Load(cmd.ExecuteReader());
            conexao.Close();

            //DataTable dados = new DataTable();
            ////Colunas de los datas
            //dados.Columns.Add(new DataColumn("Linguagem", typeof(string)));
            //dados.Columns.Add(new DataColumn("Popularidade", typeof(string)));

            ////Dados de kas colunas(Mostrar no Chart)
            //dados.Rows.Add(new object[] { "JavaScript", 11 });
            //dados.Rows.Add(new object[] { "C#", 20 });
            //dados.Rows.Add(new object[] { "PYTHON", 15 });
            //dados.Rows.Add(new object[] { "JAVA", 18 });
            //dados.Rows.Add(new object[] { "RUBY", 12 });

            string strDados;
            strDados = "[['Task','Horas per day'],";
            foreach(DataRow dr in dados.Rows)
            {
                strDados = strDados + "[";
                strDados = strDados + "'" + dr[0] + "'" + "," + dr[1];
                strDados = strDados + "],";
            }
            strDados = strDados + "]";
            return strDados;
        }
    }
}