using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

public class ControllerBase<TRepository> : IController where TRepository : IRepository
{
    protected readonly TRepository Repository;

    protected ControllerBase(TRepository repository)
    {
        Repository = repository;
    }
}
