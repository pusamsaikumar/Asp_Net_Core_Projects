

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace WebApplication2social.Models
{
    public class Dal

    {
        // create response
        public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Registration(Name,Email,Password,PhoneNo,IsActive,IsApproved)" +
                " VALUES('" + registration.Name + "','" + registration.Email + "','" +
                registration.Password + "','" + registration.PhoneNo + "',1,0 )", connection
                );
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration Successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";
            }
            return response;
        }

        // login response
        public Response Login(Registration registration, SqlConnection connection)
        {
            SqlDataAdapter data = new SqlDataAdapter(
                "SELECT * FROM Registration WHERE Email = '" + registration.Email + "'" +
                " AND Password = '" + registration.Password + "'", connection);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            Response response = new Response();
            if (dataTable.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful";
                Registration reg = new Registration();
                reg.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);

                reg.Name = Convert.ToString(dataTable.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                response.Registration = reg;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed";
                response.Registration = null;
            }
            return response;

        }

        //User approval 
        public Response UserApproval(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand(
                "UPDATE Registration SET IsApproved = 1 WHERE Id = ' " + registration.Id + "' AND IsActive = 1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Approved Successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Approval Failed";
            }
            return response;
        }

        // creater news 
        public Response AddNews(News news, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO News(Title,Content,Email,IsActive,CreatedOn) VALUES('" + news.Title + "','" + news.Content + "', '" + news.Email + "',1,GETDATE()) ", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "News Created successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " News Creation Failed";
            }
            return response;
        }

        // get all news records:
        public Response NewsList(News news, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM News WHERE IsActive = 1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<News> listNews = new List<News>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News newobj = new News();
                    newobj.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    newobj.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    newobj.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    newobj.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    newobj.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    listNews.Add(newobj);
                }
                if (listNews.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data found";
                    response.listNews = listNews;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No News data found";
                    response.listNews = null;
                }
            } else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No News data found";
                response.listNews = null;
            }

            return response;
        }

        // get all article list:

        public Response ArticleList(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = null;
            if (article.type == "User")
            {
                new SqlDataAdapter("SELECT * FROM Article WHERE Email = '" + article.Email + "' AND IsActive = 1  ", connection);
            }
            if (article.type == "Page")
            {
                new SqlDataAdapter("SELECT * FROM Article WHERE  IsActive = 1  ", connection);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Article> listArticle = new List<Article>();
            if(dt.Rows.Count > 0) { 
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    Article article1 = new Article();
                    article1.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    article1.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    article1.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    article1.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    article1.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    article1.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);
                    listArticle.Add(article1);

                }
                if(listArticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Article data found";
                    response.listArticle = listArticle;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Article data found";
                    response.listArticle = null;
                }
            } else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Article data found";
                response.listArticles = null;
            }
            return response;
        }
    
        // add article      
        public Response AddArticle(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Article(Title,Content,Email,Image,IsActive,IsApproved) VALUES('"+article.Title+ "','"+article.Content+"','"+article.Email+"','"+article.Image+"',1,0) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article created successful";
            }   else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article creation failed";
            }
            return response;
        }

        // Article approval :
        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Article SET IsApproved = 1 WHERE Id = '" + article.Id + "' AND IsActive =1 ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Approved";

            } else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article Approved Failed";
            }
            return response;
        }

        // staff registration:
       public Response StaffRegistration(Staff staff,SqlConnection connection)
        {
            Response response= new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Staff(Name,Email,Password,IsActive) VALUES('"+staff.Name+"','"+staff.Email+"','"+staff.Password+"',1 )", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Registration Successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Registration Failed";
            }
            return response;
         }
        // staff deleted
        public Response DeleteStaff(Staff staff,SqlConnection connection)
        {
            Response response= new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE Id = '" + staff.Id + "' AND IsActive = 1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Deleted Successfully!";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Deletion Failed";
            }
            return response;
        }
    }
}