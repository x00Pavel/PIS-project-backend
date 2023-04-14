using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.Configs;
using video_pujcovna_back.Repository;

namespace video_pujcovna_back.Controllers;

public class ControllerBase<TRepository> : ControllerBase, IController where TRepository : IRepository
{
    protected readonly TRepository Repository;

    public ControllerBase(TRepository repository)
    {
        Repository = repository;
    }
}
