using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace schoolManagement
{
    class Teacher : aPerson, iRegistration, iAlter
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");

        public void Registration(string role)
        {
            Console.Clear();
            Console.WriteLine("Teacher Registration Portal");


            Console.Write("Enter Name:"); string name = Console.ReadLine();
            Console.Write("Enter Password:"); string pass = Console.ReadLine();
            Console.Write("Enter Contact No:"); string contact_no = Console.ReadLine();

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT Auth (pass, role) VALUES ( @pass,@role )", con);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@role", "student");
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted in Auth");
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand(" SELECT MAX(Id) FROM Auth; ", con);
            SqlDataReader dr = cmd2.ExecuteReader();
            dr.Read();

            int Id = Convert.ToInt32(dr[0].ToString());
            Console.WriteLine("Max Id" + dr[0]);
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("INSERT Deatils (Id, name, contact_no) VALUES (@Id, @name, @contact_no )", con);
            cmd3.Parameters.AddWithValue("@Id", Id);
            cmd3.Parameters.AddWithValue("@name", name);
            cmd3.Parameters.AddWithValue("@contact_no", contact_no);
            cmd3.ExecuteNonQuery();
            Console.WriteLine("Data Inserted in Detail");
            con.Close();

            con.Open();
            Console.Write("Enter Grade:"); string grade = Console.ReadLine();

            SqlCommand cmd4 = new SqlCommand("INSERT Grade (Id, grade) VALUES ( @Id, @grade )", con);
            cmd4.Parameters.AddWithValue("@Id", Id);
            cmd4.Parameters.AddWithValue("@grade", grade);
            cmd4.ExecuteNonQuery();
            Console.WriteLine("Data Inserted in Grade");
            con.Close();
            Console.WriteLine("Data Inserted Successfully on Id:" + Id);

        }
        public override void ShowDetails(int Id)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT role FROM Auth WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            string role = dr[0].ToString();
            con.Close();
            if (role == "student")
            {
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
                Console.WriteLine("Garde:" + dr3["grade"].ToString());

            }



            else
            {
                Console.WriteLine("No Access");
            }

        }
        public void AlterData(int Id)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT role FROM Auth WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            string role = dr[0].ToString();
            con.Close();
            if (role == "student")
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
                Console.WriteLine("Data Details Updated");
                con.Close();

            }
            else
            {
                Console.WriteLine("No Access");
            }
        }
        public override void Delete(int Id)
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("SELECT role FROM Auth WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            string role = dr[0].ToString();
            con.Close();
            if (role == "student")
            {

                SqlCommand cmd2 = new SqlCommand(" DELETE FROM Auth WHERE Id=@Id; ", con);
                cmd2.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Record Deleted from Auth");
                con.Close();

                SqlCommand cmd3 = new SqlCommand(" DELETE FROM Deatils WHERE Id=@Id; ", con);
                cmd3.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd3.ExecuteNonQuery();
                Console.WriteLine("Record Deleted from Deatils");
                con.Close();

                SqlCommand cmd4 = new SqlCommand(" DELETE FROM Grade WHERE Id=@Id; ", con);
                cmd4.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd4.ExecuteNonQuery();
                Console.WriteLine("Record Deleted from Grade");
                con.Close();
            }

            else
            {
                Console.WriteLine("No Access");
            }
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
            SqlCommand cmd3 = new SqlCommand("Select salary from Salary where Id = @Id", con);
            cmd3.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            Console.WriteLine("Salary :" + dr3["salary"].ToString());
        }
    }
}
