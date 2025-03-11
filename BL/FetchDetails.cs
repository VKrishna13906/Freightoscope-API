using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Library;

namespace BL
{
    public class FetchDetails
    {

        public ResponseMessage FetchCountryDetails(string flag)
            => FetchDetailsFromDB<CountryEntities>(flag);

        public ResponseMessage FetchCityDetails(string flag)
            => FetchDetailsFromDB<CityEntities>(flag);
        public ResponseMessage FetchUserDetails(string flag)
            => FetchDetailsFromDB<UserEntities>(flag);

        private ResponseMessage FetchDetailsFromDB<T>(string flag) where T: class
        {
            try
            {
                SerializeResponse<T> _res = new SerializeResponse<T>(200, Constant.success);
                SqlParameter[] para = new SqlParameter[] { 
                    new SqlParameter("@Flag", flag)
                };

                bool _dbRes;
                DataSet ds = SqlHelper.FillDataSet(para, Constant.SP, ApiConnection.con, out _dbRes);
                
                if(!_dbRes)
                {
                    return new ResponseMessage(400, Constant.DbError);
                }

                _res.ArrayOfResponse = Helper.ListConvertDataTable<T>(ds.Tables[0]);

                return _res;
            }
            catch (Exception ex)
            {
                return Helper.Error(ex);
            }
        }
        public ResponseMessage FetchCompanyDetails(string flag)
        {
            try
            {
                SerializeResponse<CompanyEntities> _res = new SerializeResponse<CompanyEntities>(200, Constant.success);

                SqlParameter[] para = new SqlParameter[]
                {
            new SqlParameter("@Flag", flag)
                };

                bool _dbRes;
                DataSet ds = SqlHelper.FillDataSet(para, Constant.SP, ApiConnection.con, out _dbRes);

                if (!_dbRes)
                {
                    return new ResponseMessage(400, Constant.DbError);
                }


                List<CompanyEntities> companies = Helper.ListConvertDataTable<CompanyEntities>(ds.Tables[0]);
                List<CompanyTypeEntities> companyTypes = Helper.ListConvertDataTable<CompanyTypeEntities>(ds.Tables[1]);
                foreach (var company in companies)
                {
                    company.Type = companyTypes.Where(ct => ct.Id == company.CompanyID).ToList();
                }

                _res.ArrayOfResponse = companies;
                return _res;
            }
            catch (Exception ex)
            {
                return Helper.Error(ex);
            }
        }
        public ResponseMessage FetchSubmitDetails(ScheduleRequest _req)
        {
            try
            {
                SerializeResponse<ScheduleResponse> _res = new SerializeResponse<ScheduleResponse>(200, Constant.success);

                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Userid", _req.UserId)
                };

                bool _dbRes;
                DataSet ds = SqlHelper.FillDataSet(para, Constant.storeSP, ApiConnection.con, out _dbRes);

                if (!_dbRes)
                {
                    return new ResponseMessage(400, Constant.DbError);
                }
                
                List<ScheduleResponse> company = Helper.ListConvertDataTable<ScheduleResponse>(ds.Tables[0]);
                List<userList> users = Helper.ListConvertDataTable<userList>(ds.Tables[1]);

                foreach (var comp in company)
                {
                    comp.Users = users.Where(ct => ct.Companyid == comp.CompanyId).ToList();
                    comp.Length = comp.Users.Count;
                }

                _res.ArrayOfResponse = company;
                return _res;
            }
            catch (Exception ex)
            {
                return Helper.Error(ex);
            }
        }
    }
}
