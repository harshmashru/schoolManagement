using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace schoolManagement
{
    sealed class Student : aPerson, iAlter
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");

        public void AlterData(int Id)
        {

            Console.Write("Enter Updated Name:"); string name = Console.ReadLine();
            Console.Write("Enter Updated Password:"); string pass = Console.ReadLine();
            Console.Write("Enter Updated Contact No:"); string contact_no = Console.ReadLine();

            SqlCommand cmd2 = new SqlCommand("UPDATE [Auth] SET pass = @newpass  WHERE Id = @Id", con);
            cmd2.Parameters.AddWithValue("@Id", Id);
            cmd2.Parameters.AddWithValue("@newpass", pass);
            con.Open();
            cmd2.ExecuteNonQuery();
            Console.WriteLine("Data Auth Updated");
            con.Close();

            SqlCommand cmd3 = new SqlCommand("UPDATE [Deatils] SET name = @name, contact_no = @contact_no  WHERE Id = @Id", con);
            cmd3.Parameters.AddWithValue("@Id", Id);
            cmd3.Parameters.AddWithValue("@name", name);
            cmd3.Parameters.AddWithValue("@contact_no", contact_no);
            con.Open();
            cmd3.ExecuteNonQuery();
            Console.WriteLine("Data Details Updated over Id" + Id);
            con.Close();


        }

        public override void Profile(int Id)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Auth WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Console.WriteLine("Id :" + dr["id"].ToString());
            Console.WriteLine("Password :" + dr["pass"].ToString());
            Console.WriteLine("Role :" + dr["role"].ToString());
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand(" SELECT * FROM Deatils WHERE Id = @Id ", con);
            cmd2.Parameters.AddWithValue("@Id", Id);

            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                Console.WriteLine("Name : " + dr2["name"].ToString());
                Console.WriteLine("Conatact No : " + dr2["contact_no"].ToString());
            }

            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select grade from Grade where Id = @Id", con);
            cmd3.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            Console.WriteLine("Grade :" + dr3["grade"].ToString());

        }

        public override void Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand(" DELETE FROM Auth WHERE Id=@Id; ", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record Deleted from Auth");
            con.Close();

            SqlCommand cmd2 = new SqlCommand(" DELETE FROM Deatils WHERE Id=@Id; ", con);
            cmd2.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd2.ExecuteNonQuery();
            Console.WriteLine("Record Deleted from Deatils");
            con.Close();

            SqlCommand cmd3 = new SqlCommand(" DELETE FROM Grade WHERE Id=@Id; ", con);
            cmd3.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd3.ExecuteNonQuery();
            Console.WriteLine("Record Deleted from Grade");
            con.Close();
        }

        public override void ShowDetails(int Id)
        {



        }
    }
}
