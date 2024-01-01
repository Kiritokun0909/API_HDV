using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using API_QLDiemSV.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienRepository _gvRepository;

        public GiangVienController(IGiangVienRepository gvRepository)
        {
            _gvRepository = gvRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var gvs = _gvRepository.GetGiangViens();
                return StatusCode(StatusCodes.Status200OK, gvs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var gv = _gvRepository.GetGiangVienById(id);
            if (gv != null)
            {
                return StatusCode(StatusCodes.Status200OK, gv);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("maKhoa={id}")]
        public IActionResult GetByMaKhoa(int id)
        {
            var gvs = _gvRepository.GetGiangvienByMaKhoa(id);
            if (gvs != null)
            {
                return StatusCode(StatusCodes.Status200OK, gvs);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GiangVienDto gv)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _gvRepository.InsertGiangVien(gv);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status201Created, gv);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // PUT api/<GiangVienController>/5
        [HttpPut]
        public IActionResult Put([FromBody] GiangVienDto gv)
        {
            if (gv != null)
            {
                using (var scope = new TransactionScope())
                {
                    _gvRepository.UpdateGiangVien(gv);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status200OK, gv);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut("matkhau")]
        public IActionResult PutMatKhau([FromBody] UserDto user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _gvRepository.UpdateMatKhauGiangVien(user);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status200OK);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _gvRepository.DeleteGiangVien(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
