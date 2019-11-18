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
    public class AudiencesController : ApiController
    {
        IBLL bll;

        public AudiencesController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/audiences")]
        public IEnumerable<Models.Audience> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Audience>>(bll.GetAllAudiences(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/audiences/{audienceID}")]
        public Models.Audience Get(string apiToken, int audienceID)
        {
            try
            {
                return Mapper.Map<Models.Audience>(bll.GetAudience(bll.ApiTokenToID(apiToken), audienceID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/audiences")]
        public bool Post(string apiToken, [FromBody]Models.Audience audience)
        {
            try
            {
                return bll.AddAudience(bll.ApiTokenToID(apiToken), Mapper.Map<Audience>(audience));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/audiences/{audienceID}")]
        public bool Put(string apiToken, int audienceID, [FromBody]Models.Audience audience)
        {
            try
            {
                return bll.UpdateAudience(bll.ApiTokenToID(apiToken), audienceID, Mapper.Map<Audience>(audience));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/audiences/{audienceID}")]
        public bool Delete(string apiToken, int audienceID)
        {
            try
            {
                return bll.DeleteAudience(bll.ApiTokenToID(apiToken), audienceID);
            }
            catch
            {
                return false;
            }
        }
    }
}
