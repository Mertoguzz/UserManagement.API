using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Service;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
       
        public IActionResult GetByTCKN(string TCKN)
        {
            Response response = _userService.GetByTCKN(TCKN);
            return Ok(response);
        }

        [HttpGet]
    
        public IActionResult GetByID(string ID)
        {
            Response response = _userService.GetByID(ID);
            return Ok(response);
        }

        [HttpGet]
       
        public IActionResult GetAll()
        {
            Response response = _userService.Get();
            return Ok(response);
        }


        [HttpPost]

        public IActionResult Register(RegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Response response = _userService.Register(user);
            if (response.IsSuccess)
                return Ok("Kullanıcı Ekleme başarılı");
            else
                return Ok(response);
        }

        [HttpPut("{id}")]
       
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            Response response = _userService.Update(id,model);
            if (response.IsSuccess)
                return Ok("Kullanıcı güncelleme başarılı");
            else
                return Ok(response);
            
        }

             [HttpDelete("{id}")]
       
        public IActionResult Update(int id)
        {
            Response response = _userService.Delete(id);
            if (response.IsSuccess)
                return Ok("Kullanıcı silme başarılı");
            else
                return Ok(response);
            
        }
    }
}
