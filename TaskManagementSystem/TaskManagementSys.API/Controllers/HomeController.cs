

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.TaskManagementSys.API.Dto;
using TaskManagementSystem.TaskManagementSys.Application.Interfeces;

namespace TaskManagementSystem.TaskManagementSys.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IUserServices _userServices;
        public HomeController(IUserServices userServices) => _userServices = userServices;


        //When hit in this api All Users Detail with project and task is given
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var user =await _userServices.GetAllUser();
            return user;
        }

        //When url is hit UserData for paticular Id is given
        [Route("GetById")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> GetById([FromBody] Guid Id)
        {
            var user = await _userServices.GetUserById(Id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        //Use for Adding User
        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult<string>> AddUser([FromBody]UserDTO userDto)
        {
            
            var result = await _userServices.AddUser(userDto);
            if (result.Contains("Successfully"))
            {
                return Ok(result); // Success message
            }

            return BadRequest(result);
        }

        //User For Deleteing User
        [Route("DeleteUserById")]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUserById([FromBody]UserDTO userDTO)
        {
            var result = await _userServices.DeleteUserById(userDTO);
            return result.Contains("Succesfully") ? Ok(result) : BadRequest(result);
        }


    }
}
