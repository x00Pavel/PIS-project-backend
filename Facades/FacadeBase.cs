using AutoMapper;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Facades;

public abstract class FacadeBase<TRepository> : IFacade where TRepository : IRepository
{
    protected readonly TRepository Repository;

    protected readonly IMapper Mapper;

    public FacadeBase(TRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

}