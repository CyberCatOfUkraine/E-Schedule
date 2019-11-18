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
    public class StudentsController : ApiController
    {
        IBLL bll;

        public StudentsController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/students")]
        public IEnumerable<Models.Student> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.Student>>(bll.GetAllStudents(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/students/{studentID}")]
        public Models.Student Get(string apiToken, int studentID)
        {
            try
            {
                return Mapper.Map<Models.Student>(bll.GetStudent(bll.ApiTokenToID(apiToken), studentID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/students")]
        public bool Post(string apiToken, [FromBody]Models.Student student)
        {
            try
            {
                return bll.AddStudent(bll.ApiTokenToID(apiToken), Mapper.Map<Student>(student));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/students/{studentID}")]
        public bool Put(string apiToken, int studentID, [FromBody]Models.Student student)
        {
            try
            {
                return bll.UpdateStudent(bll.ApiTokenToID(apiToken), studentID, Mapper.Map<Student>(student));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/students/{studentID}")]
        public bool Delete(string apiToken, int studentID)
        {
            try
            {
                return bll.DeleteStudent(bll.ApiTokenToID(apiToken), studentID);
            }
            catch
            {
                return false;
            }
        }
    }
}
