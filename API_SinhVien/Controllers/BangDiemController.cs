using API_SinhVien.Dto;
using API_SinhVien.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_SinhVien.Controllers
{
    [Route("api/sinhvien/[controller]")]
    [ApiController]
    public class BangDiemController : ControllerBase
    {
        private readonly IBangDiemRepo _repo;

        public BangDiemController(IBangDiemRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("maSinhVien={id}")]
        public IActionResult GetListBangDiem(int id)
        {
            IEnumerable<BangDiemDto> bds = _repo.GetBangDiemByMaSinhVien(id);
            if (bds != null) return StatusCode(StatusCodes.Status200OK, bds);

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
