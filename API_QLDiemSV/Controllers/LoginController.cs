using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISinhVienRepository _svRepository;
        private readonly IGiangVienRepository _gvRepository;

        public LoginController(ISinhVienRepository svRepository, IGiangVienRepository gvRepository)
        {
            _svRepository = svRepository;
            _gvRepository = gvRepository;
        }

        [HttpPost]
        public IActionResult LoginGv([FromBody] UserDto gv)
        {
            try
            {
                bool canLogin = _gvRepository.Login(gv); ;
                return StatusCode(StatusCodes.Status200OK, canLogin);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
