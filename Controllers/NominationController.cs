using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using my_nomination_api.models;
using my_nomination_api.Services;

namespace my_nomination_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class NominationController : ControllerBase
    {
        private readonly NominationService _nominationService;

        public NominationController(NominationService nominationService)
        {
            _nominationService = nominationService;
        }

        [HttpGet]
        [Route("GetNominations")]
        public List<Nominations> GetNominations([FromQuery]string programId)
        {
            return _nominationService.GetProgramNominations(programId);
        }

        [HttpGet]
        [Route("GetNominationDetails")]
        public Nominations GetNominationDetails([FromQuery] string programId, [FromQuery] string EnterpriseId)
        {
            return _nominationService.GetNominationDetails(programId, EnterpriseId);
        }

        [Route("CreateNominations")]
        public ActionResult<Nominations> CreateNominations([FromBody] Nominations nominations)
        {
            var nomination = _nominationService.GetProgramNominations(nominations.ProgramId).FirstOrDefault(x=> x.EnterpriseId == nominations.EnterpriseId);
            if(nomination != null)
            {
                return BadRequest();
            }

            return _nominationService.CreateNominations(nominations);
        }

        [Route("UpdateNominations")]
        public ActionResult<Nominations> UpdateNominations([FromBody] Nominations nominations)
        {
            var nomination = _nominationService.GetProgramNominations(nominations.ProgramId).FirstOrDefault(x => x.EnterpriseId == nominations.EnterpriseId);
            if (nomination == null)
            {
                return BadRequest();
            }

            return _nominationService.UpdateNominations(nominations);
        }

        [Route("DeleteNominations")]
        public ActionResult<Nominations> DeleteNominations([FromBody] Nominations nominations)
        {
            var nomination = _nominationService.GetProgramNominations(nominations.ProgramId).FirstOrDefault(x => x.EnterpriseId == nominations.EnterpriseId);
            if (nomination == null)
            {
                return BadRequest();
            }

            return _nominationService.DeleteNominations(nominations);
        }

    }
}
