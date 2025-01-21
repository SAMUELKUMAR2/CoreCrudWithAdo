

using Microsoft.Data.SqlClient;

namespace SamuelCoreAdo.Models
{
    public class DataAccessLayer
    {
        SqlConnection con;

        public DataAccessLayer() { 
            con = new SqlConnection("data source=DESKTOP-K0N4E78; initial catalog=SamuelCoreAdo; Trusted_connection=True; TrustServerCertificate=True;");
        }

        public List<tblEmployee> getAllEmployee()
        {
            List<tblEmployee> list = new List<tblEmployee>();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAllEmpoyee", con);
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tblEmployee emp = new tblEmployee();

                emp.EmpId = Convert.ToInt32(reader["EmpId"]);
                emp.Name = reader["Name"].ToString();
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Gender =reader["Gender"].ToString();
                    emp.Country = reader["cname"].ToString();
                    emp.State = reader["sname"].ToString();
                    list.Add(emp);

                }
                con.Close();
                
            
            return list;

        }

        public void insertEmployee(tblEmployee emp)
        {

           
                //Insert
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@State", emp.State);
                cmd.ExecuteNonQuery();

                con.Close();

        }

        public void updateEmployee(tblEmployee emp)
        {
            if (emp.EmpId>0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@State", emp.State);
                cmd.ExecuteNonQuery();

                con.Close();

            }
        }

        public void deleteEmmployee(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tblEmployee where EmpId=@EmpId", con);
            cmd.Parameters.AddWithValue("@EmpId", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<tblCountry> BindCountry()
        {
            List<tblCountry> list = new List<tblCountry>();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCountry", con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tblCountry country = new tblCountry();
                country.cid = Convert.ToInt32(reader["cid"]);
                country.cname = reader["cname"].ToString();
                list.Add(country);
            }
            con.Close();

            return list;
        }

        public List<tblState> BindState(int cid)
        {
            List<tblState> list = new List<tblState>();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState where cid=@cid", con);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tblState state = new tblState();
                state.sid = Convert.ToInt32(reader["sid"]);
                state.sname = reader["sname"].ToString();
                list.Add(state);
            }
            con.Close();

            return list;
        }

        public tblEmployee GetEmployeeById(int id)
        {
                tblEmployee emp = new tblEmployee();
           
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblEmployee where EmpId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                emp.EmpId = Convert.ToInt32(reader["EmpId"]);
                emp.Name = reader["Name"].ToString();
                emp.Age = Convert.ToInt32(reader["Age"]);
                emp.Gender = reader["Gender"].ToString();
                emp.Country = reader["Country"].ToString();
                emp.State = reader["State"].ToString();
      

            }
            con.Close();


            return emp;

        }
    }
}
