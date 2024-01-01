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
    public class LopTinChiController : ControllerBase
    {
        private readonly ILopTinChiRepository _LopTinChiRepository;

        public LopTinChiController(ILopTinChiRepository LopTinChiRepository)
        {
            _LopTinChiRepository = LopTinChiRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var LopTinChis = _LopTinChiRepository.GetLopTinChis();
                return StatusCode(StatusCodes.Status200OK, LopTinChis);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var LopTinChi = _LopTinChiRepository.GetLopTinChiById(id);
                return StatusCode(StatusCodes.Status200OK, LopTinChi);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("maMonHoc={id}")]
        public IActionResult GetByMaMonHoc(int id)
        {
            var lopTc = _LopTinChiRepository.GetLopTcByMaMonHoc(id);
            if (lopTc != null)
            {
                return StatusCode(StatusCodes.Status200OK, lopTc);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("namHoc={nam}")]
        public IActionResult GetByNamHoc(int nam)
        {
            var lopTc = _LopTinChiRepository.GetLopTcByNamHoc(nam);
            if (lopTc != null)
            {
                return StatusCode(StatusCodes.Status200OK, lopTc);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LopTinChiDto LopTinChi)
        {
            try
            {
                _LopTinChiRepository.InsertLopTinChi(LopTinChi);
                return StatusCode(StatusCodes.Status201Created, LopTinChi);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] LopTinChiDto LopTinChi)
        {
            if (LopTinChi != null)
            {
                _LopTinChiRepository.UpdateLopTinChi(LopTinChi);
                return StatusCode(StatusCodes.Status200OK, LopTinChi);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // DELETE api/<LopTinChiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _LopTinChiRepository.DeleteLopTinChi(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
