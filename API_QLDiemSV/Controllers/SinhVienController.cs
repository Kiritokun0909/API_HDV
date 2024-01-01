using API_QLDiemSV.Dto;
using API_QLDiemSV.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepository _svRepository;

        public SinhVienController(ISinhVienRepository gvRepository)
        {
            _svRepository = gvRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var svs = _svRepository.GetSinhViens();
                return StatusCode(StatusCodes.Status200OK, svs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sv = _svRepository.GetSinhVienById(id);
            if (sv != null)
            {
                return StatusCode(StatusCodes.Status200OK, sv);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("maLopSv={id}")]
        public IActionResult GetByMaLopSv(int id)
        {
            var svs = _svRepository.GetSinhVienByMaLopSv(id);
            if (svs != null)
            {
                return StatusCode(StatusCodes.Status200OK, svs);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("maLopTc={id}")]
        public IActionResult GetByMaLopTc(int id)
        {
            var svs = _svRepository.GetSinhVienByMaLopTinChi(id);
            if (svs != null)
            {
                return StatusCode(StatusCodes.Status200OK, svs);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SinhVienDto sv)
        {
            try
            {
                _svRepository.InsertSinhVien(sv);
                return StatusCode(StatusCodes.Status201Created, sv);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] SinhVienDto sv)
        {
            if (sv != null)
            {
                _svRepository.UpdateSinhVien(sv);
                return StatusCode(StatusCodes.Status200OK, sv);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("matkhau")]
        public IActionResult PutMatKhau([FromBody] UserDto user)
        {
            if (user != null)
            {
                _svRepository.UpdateMatKhauSinhVien(user);
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _svRepository.DeleteSinhVien(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
