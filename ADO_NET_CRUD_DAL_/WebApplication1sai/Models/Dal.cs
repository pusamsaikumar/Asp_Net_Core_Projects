using System.Data;
using System.Data.SqlClient;

namespace WebApplication1sai.Models
{
    public class Dal
    {
       public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name,Email,Password,PhoneNo,IsActive,IsApproved) VALUES('"+registration.Name+"','"+registration.Email+"','"+registration.Password+"','"+registration.PhoneNo+"',1,0)",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.SatusMessage = " Registration Successful ";

            } else
            {
                response.StatusCode = 100;
                response.SatusMessage = " Registration Failed ";
            }
            return response;
        }

      public Response RegistrationList(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Registration",connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Registration> ListReg = new List<Registration>(); 
           if(dt.Rows.Count > 0)
            {   
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration registration1 = new Registration();
                    registration1.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    registration1.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    registration1.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    registration1.PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]);
                    registration1.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    registration1.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    ListReg.Add(registration1);
                }

                if (ListReg.Count > 0)
                {
                    response.StatusCode = 200;
                    response.SatusMessage = "data found";
                    response.ListReg = ListReg;
                   

                }
                else
                {
                    response.StatusCode = 100;
                    response.SatusMessage = "data not found";
                    response.ListReg = ListReg;
                }  

            } else   {
                    response.StatusCode = 100;
                    response.SatusMessage = "data not found";
                    response.ListReg = null;
                }
           return response;
        }
    }
}
