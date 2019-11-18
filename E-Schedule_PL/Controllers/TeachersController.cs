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
    public class TeachersController : ApiController
    {
        IBLL bll;

        public TeachersController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/teachers")]
        public IEnumerable<Models.Teacher> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Teacher>>(bll.GetAllTeachers(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/teachers/{teacherID}")]
        public Models.Teacher Get(string apiToken, int teacherID)
        {
            try
            {
                return Mapper.Map<Models.Teacher>(bll.GetTeacher(bll.ApiTokenToID(apiToken), teacherID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/teachers")]
        public bool Post(string apiToken, [FromBody]Models.Teacher teacher)
        {
            try
            {
                return bll.AddTeacher(bll.ApiTokenToID(apiToken), Mapper.Map<Teacher>(teacher));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/teachers/{teacherID}")]
        public bool Put(string apiToken, int teacherID, [FromBody]Models.Teacher teacher)
        {
            try
            {
                return bll.UpdateTeacher(bll.ApiTokenToID(apiToken), teacherID, Mapper.Map<Teacher>(teacher));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/teachers/{teacherID}")]
        public bool Delete(string apiToken, int teacherID)
        {
            try
            {
                return bll.DeleteTeacher(bll.ApiTokenToID(apiToken), teacherID);
            }
            catch
            {
                return false;
            }
        }
    }
}
