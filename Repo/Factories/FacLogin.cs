using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo.Models;
using Duser;
using System.Data.SqlClient;

namespace Repo.Factories
{
    public class FacLogin
    {
        public Users Login(string Username)
        {
            string SQL = "Select ID, Username, Password, Role, Firstname, Lastname, Email, Image FROM Users WHERE Username = @Username";

            using(SqlCommand cmd = new SqlCommand(SQL, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", Username);

                Mapper<Users> mapper = new Mapper<Users>();

                SqlDataReader reader = cmd.ExecuteReader();

                Users user = new Users();

                if (reader.Read())
                {
                    user = mapper.Map(reader);
                }

                reader.Close();
                cmd.Connection.Close();

                return user;
            }
        }
    }
}
