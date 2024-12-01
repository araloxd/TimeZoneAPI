using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepsController : ControllerBase
    {
        private readonly IStepRepository _stepRepository;
        public StepsController(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Step>> GetSteps(Guid userId)
        {
            var steps = await _stepRepository.GetAllStepsByIdAsync(userId);
            return steps;
        }
    }
}
