using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCMS.Library.Models;
using Dapper;

namespace VCMS.Library.Controller
{
    public class Users
    {
        public List<UserModel> getByUsername(string Username,string Password)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<UserModel>("spGetUser_ByUsername", new { Username,Password }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
