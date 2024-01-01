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
    public class LopSvController : ControllerBase
    {
        private readonly ILopSvRepository _lopSvRepository;

        public LopSvController(ILopSvRepository LopSvRepository)
        {
            _lopSvRepository = LopSvRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var LopSv = _lopSvRepository.GetLopSvs();
                return StatusCode(StatusCodes.Status200OK, LopSv);
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
                var LopSv = _lopSvRepository.GetLopSvById(id);
                return StatusCode(StatusCodes.Status200OK, LopSv);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("maKhoa={id}")]
        public IActionResult GetByMaKhoa(int id)
        {

            var lopSv = _lopSvRepository.GetLopSvByMaKhoa(id);
            if (lopSv != null)
            {
                return StatusCode(StatusCodes.Status200OK, lopSv);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        // POST api/<LopSvController>
        [HttpPost]
        public IActionResult Post([FromBody] LopSvDto LopSv)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _lopSvRepository.InsertLopSv(LopSv);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status201Created, LopSv);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] LopSvDto LopSv)
        {
            if (LopSv != null)
            {
                using (var scope = new TransactionScope())
                {
                    _lopSvRepository.UpdateLopSv(LopSv);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status200OK, LopSv);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _lopSvRepository.DeleteLopSv(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}

