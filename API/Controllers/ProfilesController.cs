using Application.Activities;
using Application.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username) 
        {
            return HandleResult(await Mediator.Send(new Application.Profiles.Details.Query{Username = username}));
        }

        [HttpGet("{username}/activities")]
        public async Task<IActionResult> GetUserActivities(string username, string predicate) 
        {
            return HandleResult(await Mediator.Send(new ListActivities.Query{Username = username, Predicate = predicate}));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Edit.Command command) 
        {
            return HandleResult(await Mediator.Send(command));
        }
    }
}