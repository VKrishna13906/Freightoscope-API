using Entities;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace FreightoscopeApi.Controllers
{
    [RoutePrefix("api/ClientDetails")]
    public class ClientDetailsController : ApiController
    {
        private readonly FetchDetails _fetch = new FetchDetails();
        [HttpGet]
        [Route("Details")]
        public IHttpActionResult Details()
        {
            try
            {
                string flag = Helper.HttpValue(Constant.flag);

                if (string.IsNullOrEmpty(flag))
                {
                    return Ok(new ResponseMessage(400, "Flag is not passed in the request."));
                }

                switch (flag)
                {
                    case Constant.country:
                        return Ok(_fetch.FetchCountryDetails(flag));

                    case Constant.city:
                        return Ok(_fetch.FetchCityDetails(flag));

                    case Constant.user:
                        return Ok(_fetch.FetchUserDetails(flag));

                    case Constant.company:
                        return Ok(_fetch.FetchCompanyDetails(flag));
                    default:
                        return Ok(new ResponseMessage(400, "Wrong Flag Passed"));
                }
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
        public IHttpActionResult Error(Exception ex)
        {
            var response = new ResponseMessage(400, $"Error Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            return Ok(response);
        }
    }
}
