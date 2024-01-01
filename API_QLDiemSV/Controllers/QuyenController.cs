using API_QLDiemSV.IRepository;
using API_QLDiemSV.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_QLDiemSV.Controllers
{
    [Route("api/qldiemsv/[controller]")]
    [ApiController]
    public class QuyenController : ControllerBase
    {
        private readonly IQuyenRepository _quyenRepository;

        public QuyenController(IQuyenRepository quyenRepository)
        {
            _quyenRepository = quyenRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var quyens = _quyenRepository.GetQuyens();
                return StatusCode(StatusCodes.Status200OK, quyens);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quyen = _quyenRepository.GetQuyenById(id);
            if (quyen != null)
            {
                return StatusCode(StatusCodes.Status200OK, quyen);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }

    }
}
