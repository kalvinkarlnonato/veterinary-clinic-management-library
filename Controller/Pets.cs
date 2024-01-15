using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCMS.Library.Models;

namespace VCMS.Library.Controller
{
    public class Pets
    {
        public List<PetModel> AllPets()
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<PetModel>("spAllPets", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<PetModel> FindPetsByClientID(int clientId)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<PetModel>("spFindPets_ByClientID", new { clientId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<PetModel> FindPetsByID(int Id)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<PetModel>("spFindPet_ByID", new { Id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public PetModel Create(PetModel petModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters client = new DynamicParameters();
                client.Add("@OwnerID", petModel.OwnerID);
                client.Add("@PetName", petModel.PetName);
                client.Add("@Species", petModel.Species);
                client.Add("@Breed", petModel.Breed);
                client.Add("@ColorMarking", petModel.ColorMarking);
                client.Add("@Birthday", petModel.Birthday);
                client.Add("@Sex", petModel.Sex);
                client.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spInsert_Pet", client, commandType: CommandType.StoredProcedure);
                petModel.ID = client.Get<int>(@"ID");
                return petModel;
            }
        }
        public PetModel Update(PetModel petModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters client = new DynamicParameters();
                client.Add("@ID", petModel.ID);
                client.Add("@OwnerID", petModel.OwnerID);
                client.Add("@PetName", petModel.PetName);
                client.Add("@Species", petModel.Species);
                client.Add("@Breed", petModel.Breed);
                client.Add("@ColorMarking", petModel.ColorMarking);
                client.Add("@Birthday", petModel.Birthday);
                client.Add("@Sex", petModel.Sex);
                connection.Execute("spUpdate_Pet", client, commandType: CommandType.StoredProcedure);
                return petModel;
            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                connection.Execute("spDelete_Pet", new { ID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
