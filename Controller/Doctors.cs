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
    public class Doctors
    {
        public List<DoctorModel> AllDoctors()
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<DoctorModel>("spAllDoctors", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<DoctorModel> Find(string word)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                return connection.Query<DoctorModel>("spFindDoctor", new { word }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public DoctorModel Create(DoctorModel doctorModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters doctor = new DynamicParameters();
                doctor.Add("@FirstName", doctorModel.FirstName);
                doctor.Add("@LastName", doctorModel.LastName);
                doctor.Add("@Sex", doctorModel.Sex);
                doctor.Add("@Cellphone", doctorModel.Cellphone);
                doctor.Add("@Address", doctorModel.Address);
                doctor.Add("@Birthday", doctorModel.Birthday);
                doctor.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spInsert_Doctor", doctor, commandType: CommandType.StoredProcedure);
                doctorModel.ID = doctor.Get<int>(@"ID");
                return doctorModel;
            }
        }
        public DoctorModel Update(DoctorModel doctorModel)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                DynamicParameters doctor = new DynamicParameters();
                doctor.Add("@ID", doctorModel.ID);
                doctor.Add("@FirstName", doctorModel.FirstName);
                doctor.Add("@LastName", doctorModel.LastName);
                doctor.Add("@Sex", doctorModel.Sex);
                doctor.Add("@Cellphone", doctorModel.Cellphone);
                doctor.Add("@Address", doctorModel.Address);
                doctor.Add("@Birthday", doctorModel.Birthday);
                connection.Execute("spUpdate_Doctor", doctor, commandType: CommandType.StoredProcedure);
                return doctorModel;
            }
        }
        public void Delete(int ID)
        {
            using (IDbConnection connection = new SqlConnection(Config.ConString("VCMSdb")))
            {
                connection.Execute("spDelete_Doctor", new { ID }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
