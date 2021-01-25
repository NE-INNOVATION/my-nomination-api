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
            if(user.Role.ToLower() == "admin" || user.Role.ToLower() == "view")
            {
                return _nominationService.GetPrograms(user.UserId);
            }
            else if(user.Role.ToLower() == "superadmin")
            {
                return _nominationService.GetAllProgram();
            }

            return new List<NominationProgram>();
            
        }

        [HttpGet]
        [Route("GetActivePrograms")]
        public List<NominationProgram> GetActivePrograms()
        {
            return _nominationService.GetAllActiveProgram();
        }

        [HttpPost]
        [Route("GetProgramsByUserId")]
        public List<NominationProgram> GetProgramsByUserId(User user)
        {
            if (user.Role.ToLower() == "admin")
            {
                return _nominationService.GetPrograms(user.UserId);
            }
            else if (user.Role.ToLower() == "superadmin")
            {
                return _nominationService.GetAllProgram();
            }

            return new List<NominationProgram>();
          
        }

        [HttpGet]
        [Route("GetProgramsById")]
        public NominationProgram GetProgramsById([FromQuery] string programId)
        {
           return _nominationService.GetProgramById(programId);
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
            var getUser = _nominationService.GetUser(user.UserId);
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
        [Route("CreateProgram")]
        public NominationProgram CreateProgram(NominationProgram nominationProgram)
        {
            var program = _nominationService.GetProgramById(nominationProgram.ProgramId);
            if (string.IsNullOrEmpty(nominationProgram.ProgramId) && program == null)
            {
                return _nominationService.CreateNominationProgram(nominationProgram);
            }

            nominationProgram.Id = program.Id;
            return _nominationService.UpdateNominationProgram(nominationProgram);

        }


        [HttpPost]
        [Route("UpdateProgram")]
        public ActionResult<NominationProgram> UpdateProgram(NominationProgram nominationProgram)
        {
            var program = _nominationService.GetProgramById(nominationProgram.ProgramId);
            if (string.IsNullOrEmpty(nominationProgram.ProgramId) && program == null)
            {
                return BadRequest();
            }

            nominationProgram.Id = program.Id;
            return _nominationService.UpdateNominationProgram(nominationProgram);

        }

    }
}
