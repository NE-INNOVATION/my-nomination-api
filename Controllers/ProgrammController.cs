using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_nomination_api.models;
using my_nomination_api.Services;

namespace my_nomination_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammController : Controller
    {
        private readonly NominationService _nominationService;

        public ProgrammController(NominationService nominationService)
        {
            _nominationService = nominationService;
        }

        public List<NominationProgram> GetPrograms(string userId)
        {
            return _nominationService.GetPrograms(userId);
        }

        public User GetUser(string userId)
        {
            return _nominationService.GetUser(userId);
        }

        public NominationProgram CreateNominations(NominationProgram nominationProgram)
        {
            return _nominationService.CreateNominationProgram(nominationProgram);
        }
    }
}
