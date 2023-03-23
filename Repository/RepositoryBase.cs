using AutoMapper;
using video_pujcovna_back.Factories;

namespace video_pujcovna_back.Repository;

public class RepositoryBase: IRepository
{
    protected readonly DbContextFactory _dbFactory;
    protected readonly IMapper _mapper;

    protected RepositoryBase(DbContextFactory dbFactory, IMapper mapper)
    {
        _dbFactory = dbFactory;
        _mapper = mapper;
    }
}