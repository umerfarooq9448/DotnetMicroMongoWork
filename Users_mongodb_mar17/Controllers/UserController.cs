using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users_mongodb_mar17.Models;
using Users_mongodb_mar17.Services;
using MongoDB.Driver;
namespace Users_mongodb_mar17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userservice;

        public UserController(UserService userservice)
        {
            _userservice = userservice;
        }


        [HttpGet]
        [Route("/getAllUsers")]
        public async Task<IActionResult> getAllUsers()
        {
            var userList = await _userservice.getAllUsers();
            return Ok(userList);
        }


        [HttpGet]
        [Route("/getUserById")]
        public async Task<IActionResult> getUserByID(string id)
        {
            var user = await _userservice.getUserByID(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("/getUser")]
        public async Task<IActionResult> addUser(Users user)
        {
            await _userservice.addUser(user);
            return StatusCode(200);
        }

        [HttpPut]
        [Route("/updateUser")]

        public async Task<IActionResult> updateUser(string id, Users user)
        {
            await _userservice.updateUser(id, user);
            return StatusCode(200);

        }

        [HttpDelete]
        [Route("/deleteUser")]
        public async Task<IActionResult> deleteUser(string id)
        {
            await _userservice.deleteUser(id);
            return StatusCode(200);
        }


        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> login(Users user)
        {
            var result = await _userservice.loginUser(user);
            return Ok(result);
        }




    }
}
