using Arangodbtest.model;
using Arangodbtest.Repository.Irepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arangodbtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendrepostory _repository;
        public FriendsController(IFriendrepostory friendrepostory)
        {
            _repository= friendrepostory;
        }
        [HttpGet]
        public IActionResult GetFriendRelation()
        {
            var Friend = _repository.GetFriendRelation();
            return Ok(Friend);
        }
        [HttpPost]
        public IActionResult addFriendRelation(Friends friends)
        {
            _repository.addFriendRelation(friends);
            return Ok(friends);
        }
        [HttpDelete]
        public IActionResult deleterelation(string _key)
        {
            _repository.deleteRelation(_key);
            return Ok("relation delete successfully");
        }
        [HttpPut]
        public IActionResult updaterelation([FromBody] Friends friends)
        {
            _repository.updateRelation(friends);
            return Ok(friends);
        }
    }
}
