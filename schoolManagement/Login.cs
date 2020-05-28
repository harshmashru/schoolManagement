using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace schoolManagement
{
    class Login
    {
        int _Id;
        string _pass;
        public Login(int Id, string pass)
        {
            this._Id = Id;
            this._pass = pass;
        }

        public int Id
        {
            get { return this._Id; }
        }

        public string pass
        {
            get { return this._pass; }
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
        public string GetRole()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Auth where Id=@Id and pass=@pass", con);
            cmd.Parameters.AddWithValue("@Id", this.Id);
            cmd.Parameters.AddWithValue("@pass", this.pass);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string s = dr[2].ToString();

            if (dr.HasRows) { con.Close(); return (s); }
            else { con.Close(); return null; }

            throw new NotImplementedException();

        }
    }
}
