using API_SinhVien.Dto;
using API_SinhVien.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_SinhVien.Controllers
{
    [Route("api/sinhvien/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepo _svRepo;

        public SinhVienController(ISinhVienRepo svRepo)
        {
            _svRepo = svRepo;
        }

        [HttpGet("maSinhVien={id}")]
        public IActionResult GetInfo(int id)
        {
            SinhVienDto sv = _svRepo.GetById(id);
            if(sv != null) return StatusCode(StatusCodes.Status200OK, sv);
            
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("matkhau")]
        public IActionResult UpdateMatKhau([FromBody] TaiKhoanDto user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    bool success = _svRepo.UpdateMatKhau(user);
                    scope.Complete();
                    if (success)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
