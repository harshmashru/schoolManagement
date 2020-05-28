using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace schoolManagement
{
    public class doMessage
    {
        /* public List<users> userList()
        {
            List<users> userList = new List<>();
            try
            {
                cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\crazyChat\crazyChat\chat.mdf;Integrated Security=True;User Instance=True");
                scm = new SqlCommand("select message from ");
                cn.Open();
                sdr = scm.ExecuteReader();
                users us;
                while(sdr.HasRows)
                {
                    us = new users(sdr.GetString(4));
                    userList.Add(us);
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return userList;
        }*/
        public void sendMessage(string sender, string reciever, string message)
        {
            int log = 0;
            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
                SqlCommand scm = new SqlCommand("select * from Deatils", cn);
                cn.Open();
                SqlDataReader sdr = scm.ExecuteReader();
                /*SqlDataAdapter sda = new SqlDataAdapter(scm);
                DataTable dt = new DataTable();
                sda.Fill(dt);*/
                while (sdr.Read())
                {
                    if (sdr.GetValue(1).Equals(reciever))
                    {
                        log = 1;
                        break;
                    }
                }
                if (log == 1)
                {
                    DateTime current = DateTime.Now;
                    string dt = current.ToString("F");
                    SqlConnection cn2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
                    SqlCommand scm2 = new SqlCommand("insert into msghistory(sender,reciever,message,dateTime) values(@sender,@reciever,@message,@dt)", cn2);
                    scm2.Parameters.AddWithValue("@sender", sender);
                    scm2.Parameters.AddWithValue("@reciever", reciever);
                    scm2.Parameters.AddWithValue("@message", message);
                    scm2.Parameters.AddWithValue("@dt", dt);
                    cn2.Open();
                    SqlDataReader sdr2 = scm2.ExecuteReader();
                    Console.WriteLine("Message sent successfully!");
                }
                else
                {
                    Console.WriteLine("Check out the error!");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
        public void display(string sender)
        {
            Console.WriteLine("Inbox :");
            SqlConnection cn3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
            SqlCommand scm3 = new SqlCommand("select * from msghistory where reciever=@sender", cn3);
            scm3.Parameters.AddWithValue("@sender", sender);
            cn3.Open();
            SqlDataReader dr3 = scm3.ExecuteReader();
            while (dr3.Read())
            {
                Console.WriteLine(dr3.GetValue(1).ToString());
                Console.WriteLine(dr3.GetValue(3).ToString());
            }
            //cn3.Close();
            Console.WriteLine("Outbox :");
            SqlConnection cn4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
            SqlCommand scm4 = new SqlCommand("select * from msghistory where sender=@sender", cn4);
            scm4.Parameters.AddWithValue("@sender", sender);
            cn4.Open();
            SqlDataReader dr4 = scm4.ExecuteReader();
            while (dr4.Read())
            {
                //Console.WriteLine(dr4.GetValue(1).ToString());
                Console.WriteLine(dr4.GetValue(2).ToString());
                Console.WriteLine(dr4.GetValue(3).ToString());
            }
        }
    }
}
