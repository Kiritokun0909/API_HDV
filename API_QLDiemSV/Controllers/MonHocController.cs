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
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocRepository _MonHocRepository;

        public MonHocController(IMonHocRepository MonHocRepository)
        {
            _MonHocRepository = MonHocRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var MonHocs = _MonHocRepository.GetMonHocs();
                return StatusCode(StatusCodes.Status200OK, MonHocs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var MonHoc = _MonHocRepository.GetMonHocById(id);
            if (MonHoc != null)
            {
                return StatusCode(StatusCodes.Status200OK, MonHoc);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MonHocDto MonHoc)
        {
            try
            {
                bool isSuccess = _MonHocRepository.InsertMonHoc(MonHoc);
                if (isSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, MonHoc);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] MonHocDto MonHoc)
        {
            if (MonHoc != null)
            {
                bool isSuccess = _MonHocRepository.UpdateMonHoc(MonHoc);
                if (isSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, MonHoc);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // DELETE api/<MonHocController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _MonHocRepository.DeleteMonHoc(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
