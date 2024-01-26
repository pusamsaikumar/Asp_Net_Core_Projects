using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace socialMedia.Models
{
    public class Dal
    {

        // create register 
        public Response Registration(Registration registration,SqlConnection connection)
        {
           Response response  = new Response();
            SqlCommand  cmd = new SqlCommand("insert into Registration(Name,Email,Password,PhoneNo,IsActive,IsApproved,UserType) values('" + registration.Name+"','"+registration.Email+"','"+registration.Password+"','"+registration.PhoneNo+"',1,1,'"+registration.UserType+"')",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage="Registration done successfully";
            } else{
                response.StatusCode = 100;
                response.StatusMessage = "Registration has failed";
            }

            return response;
        }

        // create login
        public Response Login(Registration registration, SqlConnection connection)
        {
           
           // string query = "SELECT * FROM Registration WHERE Email='" + registration.Email+ "'AND Password= '" + registration.Password+"'";
            //SqlDataAdapter da = new SqlDataAdapter(query,connection);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE Email='" + registration.Email + "'AND Password= '" + registration.Password + "'",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
         
            if(dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login successfully";
                Registration reg = new Registration();
                reg.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);
                reg.Password = Convert.ToString(dt.Rows[0]["Password"]);
                reg.PhoneNo = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                reg.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                reg.IsApproved = Convert.ToInt32(dt.Rows[0]["IsApproved"]);
                reg.UserType = Convert.ToString(dt.Rows[0]["UserType"]);
                

            
                
                response.registration = reg;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login failed";

                response.registration = null;
            }
            return response;
        }

        // get all user registration list:

        public Response RegistrationList(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Registration where  IsActive =1 and UserType='"+registration.UserType+"'";


            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da?.Fill(dt);

           List<Registration> listReg = new List<Registration>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration n = new Registration();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Name = Convert.ToString(dt.Rows[i]["Name"]);
                
                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.Password= Convert.ToString(dt.Rows[i]["Password"]);
                    n.PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]);
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    n.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    n.UserType = Convert.ToString(dt.Rows[i]["UserType"]);

                    listReg.Add(n);
                }
                if (listReg.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User registration list data is found";
                    response.listRegistration =listReg;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User registration list data not found";
                    response.listRegistration = null;
                }
            }

            return response;
        }

        public Response StaffRegistrationList(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Staff where  IsActive =1 and UserType='" + staff.UserType + "'";


            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da?.Fill(dt);

            List<Staff> listReg = new List<Staff>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   Staff n = new Staff();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Name = Convert.ToString(dt.Rows[i]["Name"]);

                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.Password = Convert.ToString(dt.Rows[i]["Password"]);
                
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                 
                    n.UserType = Convert.ToString(dt.Rows[i]["UserType"]); 
                    listReg.Add(n);
                }
                if (listReg.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User registration list data is found";
                    response.staffs = listReg;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User registration list data not found";
                    response.staffs = null;
                }
            }

            return response;
        }


        // Update user approval:
        public Response UserApproval(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            string query = "UPDATE Registration SET IsApproved = 1 WHERE ID = '" + registration.ID+"' AND IsActive = 1";
            SqlCommand cmd = new SqlCommand(query,connection);  
            connection.Open();
            int i= cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode =200;
                response.StatusMessage = "User approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User approval failed";
            }
            return response;
        }


        // created news 
        public Response News(News news , SqlConnection connection)
        {
            Response response = new Response();
            string query = "insert into News(Title,Content,Email,IsActive,CreatedOn) values('" + news.Title + "','" + news.Content + "','" + news.Email + "',1,GetDate())";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i= cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode =200;
                response.StatusMessage = "News created successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "News creation failed";
            }
            return response;
        }

        // get all active list of news:
        public Response ListNews(SqlConnection connection)
        {
            Response response = new Response();
           // string query = "select * from News";
            string query = "select * from News where IsActive =1";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<News> lstNews = new List<News>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News n = new News();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    n.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    n.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    lstNews.Add(n);
                }
                if (lstNews.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data is found";
                    response.listNews = lstNews;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "News data not found";
                    response.listNews = null;
                }
            }

            return response;
        }

        // craete all article

        public Response AddArticle(Article article, SqlConnection connection)
        {
            Response response = new Response();
            string query = "insert into Article(Title,Content,Email,Image,IsActive,IsApproved ,type) values('" + article.Title + "','" + article.Content + "','" + article.Email + "','"+article.Image+"',1,0,'"+article.type+"')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article created successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article creation failed";
            }
            return response;
        }


        // get article list of uers

        public Response ArticleList(SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Article where  IsActive =1";
           
        
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da?.Fill(dt);

            List<Article> listArticle = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article n = new Article();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    n.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    n.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    n.type = Convert.ToString(dt.Rows[i]["type"]);

                    listArticle.Add(n);
                }
                if (listArticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data is found";
                    response.listArticle = listArticle;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "News data not found";
                    response.listArticle = null;
                }
            }

            return response;
        }


        public Response ArticleListUser(Article article, SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Article where  Email='" + article.Email + "' and  IsActive =1";

         
            
          
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da?.Fill(dt);

            List<Article> listArticle = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article n = new Article();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    n.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    n.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    n.type = Convert.ToString(dt.Rows[i]["type"]);

                    listArticle.Add(n);
                }
                if (listArticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data is found";
                    response.listArticle = listArticle;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "News data not found";
                    response.listArticle = null;
                }
            }

            return response;
        }

        // Article approval:

        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new Response();
            string query = "UPDATE Article SET IsApproved = 1 WHERE ID = '" + article.ID + "' AND IsActive = 1";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article approval failed";
            }
            return response;
        }


        // add staff registration:

        public Response StaffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Staff(Name,Email,Password,IsActive,UserType) values('" + staff.Name + "','" + staff.Email + "','" + staff.Password + "',1,'staff')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = " Staff registration done successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " Staff registration has failed";
            }

            return response;
        }

        // admin deleted the staff registration:
        public Response DeleteStaff(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            string query = "Delete from Staff where ID= '"+staff.ID+"'  and IsActive =1";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff registration deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff registration deletion has failed";
            }
            return response;

        }


        // Add events:
        public Response AddEvents(Events events, SqlConnection connection)
        {
            Response response = new Response();
            string query = "insert into Events(Title,Content,Email,IsActive,CreatedOn) values('" + events.Title + "','" + events.Content + "','" + events.Email + "',1,GetDate())";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Event created successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Event creation failed";
            }
            return response;
        }

        // get list of events:

        public Response Eventlist(SqlConnection connection)
        {
            Response response = new Response();
            // string query = "select * from Events";
            string query = "select * from Events where IsActive = 1";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Events> lstEvent = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Events n = new Events();
                    n.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    n.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    n.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    n.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    n.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    n.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    lstEvent.Add(n);
                }
                if (lstEvent.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Events data is found";
                    response.listEvents = lstEvent;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Events data not found";
                    response.listEvents = null;
                }
            }

            return response;
        }


        // save file:
        public Response UploadFile([FromForm] Fileupload fileupload)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine("D:\\csharpprojects\\socialmedia\\socialMedia\\Photos", fileupload.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileupload.file.CopyTo(stream);
                }

                response.StatusCode = 200;
                response.StatusMessage = "File uploaded successfully";

            }
            catch (Exception ex)
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error occured" + ex.Message;
            }
            return response;
        }

    }
}
