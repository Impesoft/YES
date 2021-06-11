using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YES.Server.Data.Entities;
using YES.Server.Data.Repos;

namespace YES.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepo<EventInfo> _testRepo;

        public UserController(IGenericRepo<EventInfo> testRepo)
        {
            _testRepo = testRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(EventInfo eventInfo)
        {
            return Ok(await _testRepo.AddEntityAsync(eventInfo));
        }

        [HttpGet()]
        public async Task<IEnumerable<EventInfo>> GetAllUserTradeItems()
        {
            var test = await _testRepo.GetAllEntitiesAsync();

            return test;
        }
    }
}