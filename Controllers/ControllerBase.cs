using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.Configs;
using video_pujcovna_back.Repository;
using video_pujcovna_back.Facades;

namespace video_pujcovna_back.Controllers;

public class ControllerBase<TRepository> : ControllerBase, IController where TRepository : IRepository
{
    protected readonly TRepository Repository;

    public ControllerBase(TRepository repository)
    {
        Repository = repository;
    }
}

public class ControllerBase<TRepository, TFacade> : ControllerBase<TRepository> where TRepository : IRepository where TFacade : IFacade
{
    protected readonly TFacade Facade;

    public ControllerBase(TRepository repository, TFacade facade) : base(repository)
    {
        Facade = facade;
    }
}