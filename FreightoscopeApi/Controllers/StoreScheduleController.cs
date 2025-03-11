using BL;
using Entities;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreightoscopeApi.Controllers
{
    [RoutePrefix("api/StoreSchedule")]
    public class StoreScheduleController : ApiController
    {
        private readonly FetchDetails _fetch = new FetchDetails();
        [HttpPost]
        [Route("Submit")]
        public IHttpActionResult Submit(ScheduleRequest _req)
        {
            try
            {
                if (string.IsNullOrEmpty(_req.UserId))
                {
                    return Ok(new ResponseMessage(400, "UserId is not passed in the request."));
                }
                return Ok(_fetch.FetchSubmitDetails(_req));
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
