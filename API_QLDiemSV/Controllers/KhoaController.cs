using API_QLDiemSV.Dto;
using API_QLDiemSV.Entities;
using API_QLDiemSV.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaRepository _khoaRepository;

        public KhoaController(IKhoaRepository khoaRepository)
        {
            _khoaRepository = khoaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var khoas = _khoaRepository.GetKhoas();
                return StatusCode(StatusCodes.Status200OK, khoas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var khoa = _khoaRepository.GetKhoaById(id);
            if(khoa != null)
            {
                return StatusCode(StatusCodes.Status200OK, khoa);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public IActionResult Post([FromBody] KhoaDto khoa)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _khoaRepository.InsertKhoa(khoa);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status201Created, khoa);
                }
            }
            catch 
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] KhoaDto khoa)
        {
            if (khoa != null)
            {
                using (var scope = new TransactionScope())
                {
                    _khoaRepository.UpdateKhoa(khoa);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status200OK, khoa);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _khoaRepository.DeleteKhoa(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
