using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dashboard.Conexao
{
    public class Contexto
    {
        private SqlConnection con;
        private SqlCommand cmd;
        protected SqlDataReader Dr;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenCon()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                return con;
            }
            catch (Exception ex)
            {

                throw new Exception("Error to the open connection " + ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseCon()
        {
            try
            {
               
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }

                return con;
            }
            catch (Exception ex)
            {

                throw new Exception("Error to the closed connection " + ex.Message);
            }
        }
    }
}