using API_QLDiemSV.Dto;
using API_QLDiemSV.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class BangDiemController : ControllerBase
    {
        private readonly IBangDiemRepository _BangDiemRepository;

        public BangDiemController(IBangDiemRepository BangDiemRepository)
        {
            _BangDiemRepository = BangDiemRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var BangDiem = _BangDiemRepository.GetBangDiemById(id);
            if (BangDiem != null)
            {
                return StatusCode(StatusCodes.Status200OK, BangDiem);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("maSinhVien={id}")]
        public IActionResult GetBySinhVienId(int id)
        {
            var sv = _BangDiemRepository.GetBangDiemBySinhVienId(id);
            if (sv != null)
            {
                return StatusCode(StatusCodes.Status200OK, sv);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("maLopTc={id}")]
        public IActionResult GetByMaLopTc(int id)
        {
            var bds = _BangDiemRepository.GetBangDiemInfoByMaLopTc(id);
            if (bds != null)
            {
                return StatusCode(StatusCodes.Status200OK, bds);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        // POST api/<BangDiemController>
        [HttpPost]
        public IActionResult Post([FromBody] BangDiemDto BangDiem)
        {
            try
            {
                _BangDiemRepository.InsertBangDiem(BangDiem);
                return StatusCode(StatusCodes.Status201Created, BangDiem);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // PUT api/<BangDiemController>/5
        [HttpPut]
        public IActionResult Put([FromBody] BangDiemDto BangDiem)
        {
            if (BangDiem != null)
            {
                _BangDiemRepository.UpdateBangDiem(BangDiem);
                return StatusCode(StatusCodes.Status200OK, BangDiem);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // DELETE api/<BangDiemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _BangDiemRepository.DeleteBangDiem(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("maloptc={maloptc}&masv={masv}")]
        public IActionResult Delete(int maloptc, int masv)
        {
            try
            {
                _BangDiemRepository.DeleteBangDiem(maloptc, masv);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
