using ApplicationCore.Models.Entities;
using ApplicationCore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService _service;

        public SubscriptionsController(ISubscriptionsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Subscription subscription)
        {
            await _service.AddSubscription(subscription);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _service.GetAllSubscriptions();
            return Ok(results);
        }
    }
}
