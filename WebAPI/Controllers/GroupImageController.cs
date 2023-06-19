namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get_all_img")]
        public async Task<IActionResult> GetAllImage()
        {
            var query = new GetAllImageQuery();
            var listImg = _mediator.Send(query);
            return Ok(listImg);
        }
    }
}
