namespace WebAPI.Application.Queries.GroupImageQueries
{
    public class GetAllImageQueryHandler : IRequestHandler<GetAllImageQuery, List<ImageDTO>>
    {
        private readonly IGroupImageRepository _repository;

        public GetAllImageQueryHandler(IGroupImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ImageDTO>> Handle(GetAllImageQuery request, CancellationToken cancellationToken)
        {
            var listImg = _repository.GetAllImage();
            return listImg;
        }
    }
}
