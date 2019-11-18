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
    public class GroupsController : ApiController
    {
        IBLL bll;

        public GroupsController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/groups")]
        public IEnumerable<Models.Group> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Group>>(bll.GetAllGroups(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/groups/{groupID}")]
        public Models.Group Get(string apiToken, int groupID)
        {
            try
            {
                return Mapper.Map<Models.Group>(bll.GetGroup(bll.ApiTokenToID(apiToken), groupID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/groups")]
        public bool Post(string apiToken, [FromBody]Models.Group group)
        {
            try
            {
                return bll.AddGroup(bll.ApiTokenToID(apiToken), Mapper.Map<Group>(group));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/groups/{groupID}")]
        public bool Put(string apiToken, int groupID, [FromBody]Models.Group group)
        {
            try
            {
                return bll.UpdateGroup(bll.ApiTokenToID(apiToken), groupID, Mapper.Map<Group>(group));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/groups/{groupID}")]
        public bool Delete(string apiToken, int groupID)
        {
            try
            {
                return bll.DeleteGroup(bll.ApiTokenToID(apiToken), groupID);
            }
            catch
            {
                return false;
            }
        }
    }
}
