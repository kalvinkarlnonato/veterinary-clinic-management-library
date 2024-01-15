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
    public class Services
    {
        public List<ServiceModel> AllServices()
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<ServiceModel>("spAllServices", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ServiceModel> AllUnpaidService()
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<ServiceModel>("spAllUnpain_Service", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }


        public List<ServiceModel> GetServicesByPet(int PetId)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<ServiceModel>("spGetService_ByPet", new { PetId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public ServiceModel Create(ServiceModel serviceModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters service = new DynamicParameters();
                service.Add("@DocID", serviceModel.DocID);
                service.Add("@OwnerID", serviceModel.OwnerID);
                service.Add("@PetID", serviceModel.PetID);
                service.Add("@Service", serviceModel.Service);
                service.Add("@Weight", serviceModel.Weight);
                service.Add("@Temperature", serviceModel.Temperature);
                service.Add("@Againt", serviceModel.Against);
                service.Add("@Manufacturer", serviceModel.Manufacturer);
                service.Add("@Complaint", serviceModel.Complaint);
                service.Add("@Findings", serviceModel.Findings);
                service.Add("@Test", serviceModel.Test);
                service.Add("@LaboratoryResult", serviceModel.LaboratoryResult);
                service.Add("@NextVisit", serviceModel.NextVisit);
                service.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spInsert_Service", service, commandType: CommandType.StoredProcedure);
                serviceModel.ID = service.Get<int>(@"ID");
                return serviceModel;
            }
        }
        public ServiceModel UpdateCheckup(ServiceModel serviceModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters service = new DynamicParameters();
                service.Add("@ID", serviceModel.ID);
                service.Add("@Complaint", serviceModel.Complaint);
                service.Add("@Findings", serviceModel.Findings);
                service.Add("@LaboratoryResult", serviceModel.LaboratoryResult);
                service.Add("@NextVisit", serviceModel.NextVisit);
                connection.Execute("spUpdate_Checkup", service, commandType: CommandType.StoredProcedure);
                return serviceModel;
            }
        }
        public ServiceModel UpdateService(ServiceModel serviceModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters service = new DynamicParameters();
                service.Add("@ID", serviceModel.ID);
                service.Add("@Weight", serviceModel.Weight);
                service.Add("@Temperature", serviceModel.Temperature);
                service.Add("@Againt", serviceModel.Against);
                service.Add("@Manufacturer", serviceModel.Manufacturer);
                service.Add("@NextVisit", serviceModel.NextVisit);
                connection.Execute("spUpdate_Service", service, commandType: CommandType.StoredProcedure);
                return serviceModel;
            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                connection.Execute("spDelete_Service", new { ID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
