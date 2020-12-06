using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_nomination_api.models;
using my_nomination_api.Services;

namespace my_nomination_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProgrammController : Controller
    {
        private readonly NominationService _nominationService;

        public ProgrammController(NominationService nominationService)
        {
            _nominationService = nominationService;
        }

        [HttpPost]
        [Route("GetPrograms")]
        public List<NominationProgram> GetPrograms(User user)
        {
            if(user.Role.ToLower() == "admin")
            {
                var data = _nominationService.GetAllProgram();
                return _nominationService.GetAllProgram();
            }

            return _nominationService.GetPrograms(user.Userid);
        }

        [HttpGet]
        [Route("GetAllPrograms")]
        public List<NominationProgram> GetAllPrograms()
        {
            return _nominationService.GetAllProgram();
        }

        public User GetUser(string userId)
        {
            return _nominationService.GetUser(userId);
        }

        [HttpPost]
        [Route("ValidateUser")]
        public User ValidateUser(User user)
        {
            var getUser = _nominationService.GetUser(user.Userid);
            if (getUser != null)
            {
                if(getUser.Password == user.Password)
                {
                    return getUser;
                }
            }

            return null;
        }

        [HttpPost]
        public NominationProgram CreateNominations(NominationProgram nominationProgram)
        {
            return _nominationService.CreateNominationProgram(nominationProgram);
        }
    }
}
