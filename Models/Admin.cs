using System;
using System.Data.SqlClient;
using System.Data;




namespace AdminAPI.Models
{
    public class Admin
    {
        public int Admin_Id { get; set; }

        public string Admin_FName { get; set; }

        public string Admin_LName { get; set; }

        public string Admin_email { get; set; }

        public string Admin_password { get; set; }

        public Admin()
        {

        }
        public Admin(int adminid, string adminfname, string lname, string email, string password)
        {
            Admin_Id = adminid;
            Admin_FName = adminfname;
            Admin_LName = lname;
            Admin_email = email;
            Admin_password = password;
        }

        public static SqlConnection con;
        public static SqlCommand cmd;
        public static void getcon()
        {

            con = new SqlConnection("Data Source=LAPTOP-6MJE97ED\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true");
            con.Open();
        }

        public static void insertAdminUsers(Admin A)
        {
            Admin.getcon();
            cmd = new SqlCommand("insertadminusers");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@adminfname", A.Admin_FName);
            cmd.Parameters.AddWithValue("@adminlname", A.Admin_LName);
            cmd.Parameters.AddWithValue("@adminemail", A.Admin_email);
            cmd.Parameters.AddWithValue("@adminpassword", A.Admin_password);
            cmd.ExecuteNonQuery();

        }

        public static List<Admin> GetAllAdmins()
        {
            List<Admin> ad = new List<Admin>();
            Admin.getcon();
            cmd = new SqlCommand("getadminusers");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Admin a = new Admin();
                a.Admin_Id = Convert.ToInt32(dr[0]);
                a.Admin_FName = dr[1].ToString();
                a.Admin_LName = dr[2].ToString();
                a.Admin_email = dr[3].ToString();
                a.Admin_password = dr[4].ToString();

                ad.Add(a);
            }
            return ad;

        }

        public static List<Admin> admins = Admin.GetAllAdmins();

        public static bool Login(string Admin_email, String Admin_password)
        {
            Admin a = admins.Where(x => x.Admin_email == Admin_email).Select(x => x).SingleOrDefault();
           Admin c = admins.Where(y => y.Admin_password == Admin_password).Select(y => y).SingleOrDefault();
            if(a!=null&&c!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



    }




    }


  