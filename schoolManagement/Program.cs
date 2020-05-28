using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace schoolManagement
{
    class Program
    {

        static void Main(string[] args)
        {
        Main:
            Console.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Harsh\C #\schoolManagement\schoolManagement\DatabaseLocal.mdf;Integrated Security=True;User Instance=True");
            Console.Write("Enter Your Id:");

            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your Pass:");
            string pass = PassAsterisk();

            Login login = new Login(Id, pass);
            string role = login.GetRole();
            Console.WriteLine("Role:" + role);

            if (role == "admin")
            {
            Switch:
                Console.Clear();
                char ch;
                Console.WriteLine("Welcome to the Admin Portal\n\n");
                Console.WriteLine("a. Register b. View c. Alter d. Delete e. Profile  f.doMessage g.Exit h.logout");
                Console.Write("Select Option : ");
                ch = Convert.ToChar(Console.ReadLine());
                Console.Clear();

                string tempRole = "null";
                int tempId = 0;

                switch (Char.ToLower(ch))
                {

                    case 'a':
                        Admin admin = new Admin();
                        Console.Write("Enter Role:");
                        tempRole = Console.ReadLine();
                        admin.Registration(tempRole);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y' || Convert.ToChar(Console.ReadLine()) == 'Y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }


                    case 'b':
                        Admin admin1 = new Admin();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        admin1.ShowDetails(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }



                    case 'c':
                        Admin admin2 = new Admin();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        admin2.AlterData(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }


                    case 'd':
                        Admin admin4 = new Admin();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        admin4.Delete(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }


                    case 'e':
                        Admin admin5 = new Admin();
                        Login login1 = new Login(Id, pass);

                        admin5.Profile(login1.Id);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'f':
                        doMessage dm = new doMessage();
                        SqlCommand scm = new SqlCommand("select name from deatils where Id=@Id",con);
                        scm.Parameters.AddWithValue("@Id",Id);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        string uname = sdr[0].ToString();
                        dm.display(uname);
                        Console.WriteLine("Enter reciever name:");
                        string recname = Console.ReadLine();
                        Console.WriteLine("Enter message:");
                        string msg = Console.ReadLine();
                        dm.sendMessage(uname,recname,msg);
                        break;

                    case 'g':
                        Console.WriteLine("Thank you ");
                        Environment.Exit(0);
                        break;

                    case 'h':
                        Console.WriteLine("Thank you ");
                        goto Main;


                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }
            if (role == "teacher")
            {
            Switch:
                Console.Clear();
                char ch;
                Console.WriteLine("Welcome to the Teacher Portal\n\n");
                Console.WriteLine("a. Register b. View c. Alter d. Delete e. Profile f.doMessage g.Exit h.Logout");
                Console.WriteLine("Select Option : ");
                ch = Convert.ToChar(Console.ReadLine());


                int tempId = 0;

                switch (Char.ToLower(ch))
                {

                    case 'a':
                        Teacher teacher = new Teacher();
                        teacher.Registration("student");

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'b':
                        Teacher teacher1 = new Teacher();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        teacher1.ShowDetails(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'c':
                        Teacher teacher2 = new Teacher();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        teacher2.AlterData(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }


                    case 'd':
                        Teacher teacher3 = new Teacher();
                        Console.Write("Enter Your Id:");
                        tempId = Convert.ToInt32(Console.ReadLine());
                        teacher3.Delete(tempId);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'e':
                        Teacher teacher5 = new Teacher();
                        Login login1 = new Login(Id, pass);
                        teacher5.Profile(login1.Id);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'f':
                        doMessage dm = new doMessage();
                        SqlCommand scm = new SqlCommand("select name from deatils where Id=@Id", con);
                        scm.Parameters.AddWithValue("@Id", Id);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        string uname = sdr[0].ToString();
                        dm.display(uname);
                        Console.WriteLine("Enter reciever name:");
                        string recname = Console.ReadLine();
                        Console.WriteLine("Enter message:");
                        string msg = Console.ReadLine();
                        dm.sendMessage(uname, recname, msg);
                        break;

                    case 'g':
                        Console.WriteLine("Thank you ");
                        Environment.Exit(0);
                        break;

                    case 'h':
                        Console.WriteLine("Thank you ");
                        goto Main;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }


            }
            if (role == "student")
            {
            Switch:
                Console.Clear();
                char ch;
                Console.WriteLine("Welcome to the Student Portal\n\n");
                Console.WriteLine("a. Alter b. Delete c. Profile d.doMessage e.Exit f.Logout");
                Console.WriteLine("Select Option : ");
                ch = Convert.ToChar(Console.ReadLine());

                switch (Char.ToLower(ch))
                {
                    case 'a':
                        Teacher teacher2 = new Teacher();
                        teacher2.AlterData(Id);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'b':
                        Teacher teacher1 = new Teacher();
                        teacher1.Delete(Id);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'c':
                        Student student2 = new Student();
                        Login login1 = new Login(Id, pass);
                        student2.Profile(login1.Id);

                        Console.WriteLine("Press Y to Continue");
                        if (Convert.ToChar(Console.ReadLine()) == 'y') { goto Switch; }
                        else { Console.WriteLine("Thank you "); break; }

                    case 'd':
                        doMessage dm = new doMessage();
                        SqlCommand scm = new SqlCommand("select name from deatils where Id=@Id", con);
                        scm.Parameters.AddWithValue("@Id", Id);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        string uname = sdr[0].ToString();
                        dm.display(uname);
                        Console.WriteLine("Enter reciever name:");
                        string recname = Console.ReadLine();
                        Console.WriteLine("Enter message:");
                        string msg = Console.ReadLine();
                        dm.sendMessage(uname, recname, msg);
                        break;

                    case 'e':
                        Console.WriteLine("Thank you ");
                        Environment.Exit(0);
                        break;

                    case 'f':
                        Console.WriteLine("Thank you ");

                        goto Main;


                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static string PassAsterisk()
        {
            string pass = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    pass += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(pass))
                    {
                        // remove one character from the list of password characters
                        pass = pass.Substring(0, pass.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            return pass;
        }



    }
}
