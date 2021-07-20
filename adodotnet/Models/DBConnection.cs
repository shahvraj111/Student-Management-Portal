using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace adodotnet.Models
{
    public class DBConnection
    {
        string cs = @"server = localhost; port = 5432; user id = postgres; password =vraj; database = postgres";


        public static string conString = Convert.ToString(ConfigurationManager.ConnectionStrings["cs"]);

        public NpgsqlConnection cn = new NpgsqlConnection(conString);
        NpgsqlCommand cmd = null;
        NpgsqlDataAdapter ad = null;

        public static string DBConnectionString
        {
            get
            {
                return conString;
            }
            set
            {
                DBConnectionString = value;
            }
        }

        public DataSet getDataBy_SqlCommand_CB(NpgsqlCommand cmd)
        {
            NpgsqlConnection cn = new NpgsqlConnection(cs);
            DataSet dt = new DataSet();
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.CommandTimeout = 100;
                cmd.Connection = cn;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return dt;
            }
            finally
            {
                closeConnection(cn, cmd);
            }
        }

        public bool Delete(NpgsqlCommand cmd)
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                using (cn = new NpgsqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                closeConnection(cn, cmd);
            }
            return true;
        }
        public bool InsertData(NpgsqlCommand cmd)
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                using (cn = new NpgsqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                closeConnection(cn, cmd);
            }
            return true;
        }

        public bool Update(NpgsqlCommand cmd)
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                using (cn = new NpgsqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                closeConnection(cn, cmd);
            }
            return true;
        }

        #region CloseConnection
        public static void closeConnection(NpgsqlConnection cn, NpgsqlCommand cmd)
        {
            if (cn != null)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            cmd.Dispose();
        }
        #endregion       
    }
}