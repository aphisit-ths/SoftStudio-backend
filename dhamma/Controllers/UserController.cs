using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using dhamma.Models;

using static dhamma.Models.User;

namespace dhamma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUser_ID(int id)
        {
            var result = GetUserbyId(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = getAllUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register_user([FromBody] User user)
        {
            var result = Register_User(user);
            return Ok(result);
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login_User(String username, String password)
        {
            var result = User_Login(username, password);
            return Ok(result);
        }

        [HttpGet] // Pass as KEY and VALUE to use  || Note : Some error occur so I can't write this function properly
        [Route("GetbyStatus")]
        public IActionResult GetUserbyStatus(String status)
        { //  "Active" ,"Cancled" , "Banned"
            Console.WriteLine("Status");
            var result = getUserbyStatus(status);
            return Ok(result);
        }

        [HttpGet] // Pass as KEY and VALUE to use  || Note : Some error occur so I can't write this function properly
        [Route("GetbyEmail")]
        public IActionResult GetbyEmail(String Email)
        { //  "Active" ,"Cancled" , "Banned"
            Console.WriteLine("Status");
            var result = GetUserbyEmail(Email);
            return Ok(result);
        }

        [HttpPut]
        [Route("Edit_user")]
        public IActionResult Edit_USER([FromBody] User newUser)
        {
            var result = edit_User_object(newUser);
            return Ok(result);
        }

        [HttpPut]
        [Route("ban_user")]
        public IActionResult Ban_USER(int userId, int adminId)
        {
            var result = banned_user(userId, adminId);
            return Ok(result);
        }

        [HttpPut]
        [Route("cancle_user")]
        public IActionResult Cancle_USER(int userId)
        {
            var result = cancle_member(userId);

            //var result = GetUserbyId(userId);
            return Ok(result);
        }

        [HttpPut]
        [Route("activate_user")]
        public IActionResult activate_USER(int userId)
        {
            var result = activate_member(userId);
            return Ok(result);
        }
    }
}
