using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCMS.Library.Models;

namespace VCMS.Library.Controller
{
    public class Clients
    {
        public List<OwnerModel> AllClients()
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<OwnerModel>("spAllClients",null,commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<OwnerModel> Find(string word)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<OwnerModel>("spFindClient", new { word }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<OwnerModel> FindClientByID(int clientId)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<OwnerModel>("spFindClient_ByClientID", new { clientId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public OwnerModel Create(OwnerModel clientModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters client = new DynamicParameters();
                client.Add("@FirstName", clientModel.FirstName);
                client.Add("@LastName", clientModel.LastName);
                client.Add("@Address", clientModel.Address);
                client.Add("@Cellphone", clientModel.Cellphone);
                client.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spInsert_Client", client, commandType: CommandType.StoredProcedure);
                clientModel.ID = client.Get<int>(@"ID");
                return clientModel;
            }
        }
        public OwnerModel Update(OwnerModel clientModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters client = new DynamicParameters();
                client.Add("@ID", clientModel.ID);
                client.Add("@FirstName", clientModel.FirstName);
                client.Add("@LastName", clientModel.LastName);
                client.Add("@Address", clientModel.Address);
                client.Add("@Cellphone", clientModel.Cellphone);
                connection.Execute("spUpdate_Client", client, commandType: CommandType.StoredProcedure);
                return clientModel;
            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                connection.Execute("spDelete_Client", new { ID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
