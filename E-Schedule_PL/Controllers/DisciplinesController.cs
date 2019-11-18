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
    public class DisciplinesController : ApiController
    {
        IBLL bll;

        public DisciplinesController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/disciplines")]
        public IEnumerable<Models.Discipline> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Discipline>>(bll.GetAllDisciplines(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/disciplines/{disciplineID}")]
        public Models.Discipline Get(string apiToken, int disciplineID)
        {
            try
            {
                return Mapper.Map<Models.Discipline>(bll.GetDiscipline(bll.ApiTokenToID(apiToken), disciplineID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/disciplines")]
        public bool Post(string apiToken, [FromBody]Models.Discipline discipline)
        {
            try
            {
                return bll.AddDiscipline(bll.ApiTokenToID(apiToken), Mapper.Map<Discipline>(discipline));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/disciplines/{disciplineID}")]
        public bool Put(string apiToken, int disciplineID, [FromBody]Models.Discipline discipline)
        {
            try
            {
                return bll.UpdateDiscipline(bll.ApiTokenToID(apiToken), disciplineID, Mapper.Map<Discipline>(discipline));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/disciplines/{disciplineID}")]
        public bool Delete(string apiToken, int disciplineID)
        {
            try
            {
                return bll.DeleteDiscipline(bll.ApiTokenToID(apiToken), disciplineID);
            }
            catch
            {
                return false;
            }
        }
    }
}
