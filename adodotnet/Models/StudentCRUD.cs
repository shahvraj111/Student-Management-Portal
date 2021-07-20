using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace adodotnet.Models
{
    public class StudentCRUD
    {
        public List<StudentDB> GetAllStudents()
        {
            List<StudentDB> list = new List<StudentDB>();
            try
            {
                DBConnection con = new DBConnection();
                NpgsqlCommand cmd = new NpgsqlCommand();
                {
                    string query = @"SELECT ek_spcruda(";
                    query += "p_chk:=0";

                    query += ",p_ref1:='p_ref1');";
                    query += "fetch all in " + "\"p_ref1\";";
                    cmd = new NpgsqlCommand(query);
                    DataTable dt = con.getDataBy_SqlCommand_CB(cmd).Tables[1];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        list = dt.AsEnumerable().Select(x => new StudentDB()
                        {
                            id = Convert.ToInt32(x["id"]),
                            Name = (x["name"]).ToString(),
                            Age = Convert.ToInt32(x["age"]),
                            BirthDate = (x["birthdate"]).ToString(),
                            Subject = (x["subject"]).ToString(),

                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public int Add(StudentDB stu)
        {
            int OutputResult = 1;
            try
            {
                DBConnection con = new DBConnection();
                NpgsqlCommand cmd = new NpgsqlCommand();
                {
                    string query = @"SELECT ek_spcruda(";
                    query += "p_chk:=1";
                    query += ",p_name:='" + stu.Name + "'";
                    query += ",p_age:=" + stu.Age;
                    query += ",p_birthdate:='" + Convert.ToDateTime(stu.BirthDate).ToString("yyyy/MM/dd") + "'";
                    query += ",p_subject:='" + stu.Subject + "'";
                    query += ",p_ref1:='p_ref1');";
                    query += "fetch all in " + "\"p_ref1\";";

                    cmd.CommandType = CommandType.Text;
                    cmd = new NpgsqlCommand(query);
                    bool val = con.InsertData(cmd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return OutputResult;
        }
        public StudentDB GetStudentbyid(int id)
        {
            StudentDB stuobj = new StudentDB();
            try
            {
                DBConnection con = new DBConnection();
                NpgsqlCommand cmd = new NpgsqlCommand();
                {
                    string query = @"SELECT ek_spcruda(";
                    query += "p_chk:=4";
                    query += ",p_id:=" + id;
                    query += ",p_ref1:='p_ref1');";
                    query += "fetch all in " + "\"p_ref1\";";
                    cmd.CommandType = CommandType.Text;
                    cmd = new NpgsqlCommand(query);
                    DataTable dt = con.getDataBy_SqlCommand_CB(cmd).Tables[1];

                    if (dt.Rows.Count > 0)
                    {
                        stuobj.Name = dt.Rows[0]["name"].ToString();
                        stuobj.Age = Convert.ToInt32(dt.Rows[0]["age"]);
                        stuobj.BirthDate = dt.Rows[0]["birthdate"].ToString();
                        stuobj.Subject = dt.Rows[0]["subject"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stuobj;
        }
        public int UpdateEmployee(StudentDB stu)
        {
            int OutputResult = 1;
            try
            {
                DBConnection con = new DBConnection();
                NpgsqlCommand cmd = new NpgsqlCommand();
                {
                    string query = @"SELECT ek_spcruda(";
                    query += "p_chk:=2";
                    query += ",p_id:=" + stu.id;
                    query += ",p_name:='" + stu.Name + "'";
                    query += ",p_age:=" + stu.Age;
                    query += ",p_birthdate:='" + Convert.ToDateTime(stu.BirthDate).ToString("yyyy/MM/dd") + "'";
                    query += ",p_subject:='" + stu.Subject + "'";
                    query += ",p_ref1:='p_ref1');";
                    query += "fetch all in " + "\"p_ref1\";";

                    cmd.CommandType = CommandType.Text;
                    cmd = new NpgsqlCommand(query);
                    bool val = con.Update(cmd);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return OutputResult;
        }
        public int DeleteData(int id)
        {
            int OutputResult = 1;
            try
            {
                DBConnection con = new DBConnection();
                NpgsqlCommand cmd = new NpgsqlCommand();
                {
                    string query = @"SELECT ek_spcruda(";
                    query += "p_chk:=3";
                    query += ",p_id:=" + id;
                    query += ",p_ref1:='p_ref1');";
                    query += "fetch all in " + "\"p_ref1\";";

                    cmd.CommandType = CommandType.Text;
                    cmd = new NpgsqlCommand(query);
                    bool val = con.Delete(cmd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return OutputResult;
        }

    }
}