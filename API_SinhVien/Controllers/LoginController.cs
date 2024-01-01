using API_SinhVien.Dto;
using API_SinhVien.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_SinhVien.Controllers
{
    [Route("api/sinhvien/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISinhVienRepo _svRepo;

        public LoginController(ISinhVienRepo svRepo)
        {
            _svRepo = svRepo;
        }

        [HttpPost]
        public IActionResult Login([FromBody] TaiKhoanDto sv)
        {
            try
            {
                bool canLogin = _svRepo.Login(sv);
                return StatusCode(StatusCodes.Status200OK, canLogin);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
