using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class ActorRepository : IRepository
{
    private readonly DbContextFactory _factory;
    private readonly IMapper _mapper;

    public ActorRepository(DbContextFactory factory, IMapper mapper)
    {
        _factory = factory;
        _mapper = mapper;
    }
    
    public async Task<ICollection<ActorModel>> GetActorModelList(IEnumerable<ActorEntity> actors)
    {   
        var nameList = actors.Select(actor => actor.NameAndSurname).ToList();
        await using var context = _factory.CreateDbContext();
        return await context.Actors.Where(x => nameList.Contains(x.NameAndSurname)).ToListAsync();
    }
    public async Task<ActorEntity> GetActor(string nameAndUsername)
    {
        await using var context = _factory.CreateDbContext();
        return _mapper.Map<ActorEntity>(await GetActorModel(nameAndUsername));
    }

    public async Task<ActorModel> GetActorModel(string nameAndUsername)
    {
        await using var context = _factory.CreateDbContext();
        return await context.Actors.FirstAsync(x => x.NameAndSurname == nameAndUsername);
    }

    public async Task<IEnumerable<ActorEntity>> GetAllActors()
    {
        await using var context = _factory.CreateDbContext();
        return _mapper.Map<IEnumerable<ActorEntity>>(await context.Actors.ToListAsync());
    }

    public async Task<ActorEntity> AddActor(ActorEntity actor)
    {
        await using var context = _factory.CreateDbContext();
        var actorModel = _mapper.Map<ActorModel>(actor);
        
        if (await context.Actors.AnyAsync(x => x.NameAndSurname == actorModel.NameAndSurname))
        {
            throw new Exception("Actor already exists");
        }

        await context.Actors.AddAsync(actorModel);
        await context.SaveChangesAsync();
        return _mapper.Map<ActorEntity>(actorModel);
    }

    public async Task<ActorEntity> DeleteActor(string actorName)
    {
        await using var context = _factory.CreateDbContext();
        var actorModel = context.Actors.FirstAsync(x => x.NameAndSurname == actorName).Result;
        
        if (actorModel == null)
        {
            throw new Exception("Actor not found");
        }

        context.Actors.Remove(actorModel);
        await context.SaveChangesAsync();
        return _mapper.Map<ActorEntity>(actorModel);
    }
    
    public async Task<ActorEntity> UpdateActor(string actorName, ActorEntity actor)
    {
        await using var context = _factory.CreateDbContext();
        var actorModel = GetActorModel(actorName).Result;
        
        if (actorModel == null)
        {
            throw new Exception("Actor not found");
        }

        actorModel.NameAndSurname = actor.NameAndSurname;

        context.Actors.Update(actorModel);
        await context.SaveChangesAsync();
        return _mapper.Map<ActorEntity>(actorModel);
    }
}