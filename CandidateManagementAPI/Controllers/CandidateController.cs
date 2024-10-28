using Candidate_Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private ICandidateProfileService candidateProfileService;
        public CandidateController() { 
            candidateProfileService = new CandidateProfileService();
        }
        [HttpGet(Name = "GetCandidates")]
        public IActionResult GetAllCandidates() {
            return Ok(candidateProfileService.GetCandidates().ToList());
        }
    }
}
