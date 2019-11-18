using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using E_Schedule_BLL;
using E_Schedule_BLL.Entities;

namespace E_Schedule_PL.Controllers
{
    public class ScheduleController : ApiController
    {
        IBLL bll;

        public ScheduleController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/schedule")]
        public IEnumerable<Models.Schedule> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Schedule>>(bll.GetAllSchedule(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/schedule/my")]
        public IEnumerable<Models.Schedule> GetSchedule(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Schedule>>(bll.GetSchedule(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/schedule/{scheduleID}")]
        public Models.Schedule Get(string apiToken, int scheduleID)
        {
            try
            {
                return Mapper.Map<Models.Schedule>(bll.GetScheduleByID(bll.ApiTokenToID(apiToken), scheduleID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/schedule")]
        public bool Post(string apiToken, [FromBody]Models.Schedule schedule)
        {
            try
            {
                return bll.AddSchedule(bll.ApiTokenToID(apiToken), Mapper.Map<Schedule>(schedule));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/schedule/{scheduleID}")]
        public bool Put(string apiToken, int scheduleID, [FromBody]Models.Schedule schedule)
        {
            try
            {
                return bll.UpdateSchedule(bll.ApiTokenToID(apiToken), scheduleID, Mapper.Map<Schedule>(schedule));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/schedule/{scheduleID}")]
        public bool Delete(string apiToken, int scheduleID)
        {
            try
            {
                return bll.DeleteSchedule(bll.ApiTokenToID(apiToken), scheduleID);
            }
            catch
            {
                return false;
            }
        }
    }
}
