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
    public class UsersController : ApiController
    {
        IBLL bll;

        public UsersController(IBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        [Route("api/{apitoken}/users")]
        public IEnumerable<Models.User> Get(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.User>>(bll.GetAllUsers(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/users/{userID}")]
        public Models.User Get(string apiToken, int userID)
        {
            try
            {
                return Mapper.Map<Models.User>(bll.GetUser(bll.ApiTokenToID(apiToken), userID));
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/{apitoken}/users")]
        public bool Post(string apiToken, [FromBody]Models.User user)
        {
            try
            {
                return bll.AddUser(bll.ApiTokenToID(apiToken), Mapper.Map<User>(user));
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/users/{userID}")]
        public bool Put(string apiToken, int userID, [FromBody]Models.User user)
        {
            try
            {
                return bll.UpdateUser(bll.ApiTokenToID(apiToken), userID, Mapper.Map<User>(user));
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/{apitoken}/users/{userID}")]
        public bool Delete(string apiToken, int userID)
        {
            try
            {
                return bll.DeleteUser(bll.ApiTokenToID(apiToken), userID);
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/users/mycredentials")]
        public Models.UserCredentials GetCredentials(string apiToken)
        {
            try
            {
                return Mapper.Map<Models.UserCredentials>(bll.GetUserCredetial(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/{apitoken}/users/allcredentials")]
        public IEnumerable<Models.UserCredentials> GetAllCredentials(string apiToken)
        {
            try
            {
                return Mapper.Map<List<Models.UserCredentials>>(bll.GetAllUserCredentials(bll.ApiTokenToID(apiToken)));
            }
            catch
            {
                return null;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/users/updpassword")]
        public bool PutPass(string apiToken, [FromBody]string oldPass, [FromBody]string newPass)
        {
            try
            {
                return bll.UpdatePassword(bll.ApiTokenToID(apiToken), oldPass, newPass);
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/users/updlogin")]
        public bool PutLogin(string apiToken, [FromBody]string newLogin, [FromBody]string pass)
        {
            try
            {
                return bll.UpdateLogin(bll.ApiTokenToID(apiToken), newLogin, pass);
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("api/{apitoken}/users/updtoken")]
        public string PutToken(string apiToken)
        {
            try
            {
                return bll.UpdateApiToken(bll.ApiTokenToID(apiToken));
            }
            catch
            {
                return null;
            }
        }
    }
}
