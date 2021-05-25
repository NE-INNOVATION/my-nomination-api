using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using my_nomination_api.models;
using my_nomination_api.Services;

namespace my_nomination_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        private readonly NominationService _nominationService;

        public NominationController(NominationService nominationService)
        {
            _nominationService = nominationService;
        }

        public List<Nominations> GetNominations(string programmId)
        {
            return _nominationService.GetProgramNominations(programmId);
        }
        
        [HttpGet("Health")] 
        public string Health()
        {
            return "Success";
        }

        public Nominations CreateNominations(Nominations nominations)
        {
            return _nominationService.CreateNominations(nominations);
        }
              
    }
}
