using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.DTO.Output;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class VideotapeRepository: RepositoryBase
{
    public VideotapeRepository(DbContextFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
    }
    
    public async Task<ICollection<VideoTapeEntityOutput>> GetAllVideotapes()
    {
        await using var context = _dbFactory.CreateDbContext();
        var records= await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .ToListAsync();
        return _mapper.Map<IList<VideotapeModel>, IList<VideoTapeEntityOutput>>(records);
    }
    
    public async Task<VideoTapeEntityOutput> AddVideotape(VideoTapeEntityInput videoTape)
    {
        var videoTapeMapped = _mapper.Map<VideotapeModel>(videoTape);
        await using var context = _dbFactory.CreateDbContext();
        var result = await context.VideTape.AddAsync(videoTapeMapped);
        Unchanged(context, videoTapeMapped.Actors, videoTapeMapped.Genre, videoTapeMapped.Stock);
        await context.SaveChangesAsync();
        return _mapper.Map<VideotapeModel, VideoTapeEntityOutput>(result.Entity);
    }
    
    public async Task<VideotapeModel> GetVideotapeModel(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        return await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<VideoTapeEntityOutput> GetVideotape(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        var videoTape = await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Id == id);
        return _mapper.Map<VideoTapeEntityOutput>(videoTape);
    }
    
    public async Task<VideotapeModel> GetVideotapeById(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        return  await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Id == id);
    }

    public async Task<VideotapeModel> GetVideotapeModelByName(string sourceVideotapeName)
    {
        await using var context = _dbFactory.CreateDbContext();
        return await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Title == sourceVideotapeName);
    }

    public async Task<VideoTapeEntityOutput> GetVideotapeByName(string sourceVideotapeName)
    {
        await using var context = _dbFactory.CreateDbContext();
        var videoTape = await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Title == sourceVideotapeName);
        return _mapper.Map<VideoTapeEntityOutput>(videoTape);
    }

    public async Task<VideoTapeEntityOutput> UpdateVideotape(VideoTapeEntityOutput videoTape)
    {
        await using var context = _dbFactory.CreateDbContext();
        var videoTapeModel = context.VideTape
            .Include(x => x.Genre)
            .Include(x => x.Actors)
            .Include(x => x.Stock)
            .FirstAsync(x => x.Id == videoTape.Id).Result;
    
        videoTapeModel.Title = videoTape.Title;
        videoTapeModel.Description = videoTape.Description;
        videoTapeModel.Duration = videoTape.Duration;
        videoTapeModel.CountryOfOrigin = videoTape.CountryOfOrigin;
        videoTapeModel.Language = videoTape.Language;
        videoTapeModel.Count = videoTape.Count;
        videoTapeModel.Director = videoTape.Director;
        videoTapeModel.year = videoTape.year;
        videoTapeModel.PricePerDay = videoTape.PricePerDay;
        videoTapeModel.Stock = context.Stock.First(x => x.Name == videoTape.Stock.Name);

        videoTapeModel.Genre.Clear();
        foreach(var genre in videoTape.Genre)
        {
            var GenreModel = context.Genre.First(x => x.Name == genre.Name);
            videoTapeModel.Genre.Add(GenreModel);
            Unchanged(context, GenreModel);
        }
        
        videoTapeModel.Actors.Clear();
        foreach(var actor in videoTape.Actors)
        {
            var ActorModel = context.Actors.First(x => x.NameAndSurname == actor.NameAndSurname);
            videoTapeModel.Actors.Add(ActorModel);
            Unchanged(context, ActorModel);
        }
        context.VideTape.Update(videoTapeModel);
        await context.SaveChangesAsync();
        return _mapper.Map<VideotapeModel, VideoTapeEntityOutput>(videoTapeModel);
    }

    public async Task<bool> DeleteVideoTape(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        var videoTape = await context.VideTape.FindAsync(id);
        if (videoTape == null)
        {
            return false;
        }
        context.VideTape.Remove(videoTape);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IActionResult> UploadImage(VideotapeModel videotape, string path)
    {
        await using var context = _dbFactory.CreateDbContext();
        videotape.ImagePath = path;
        context.VideTape.Update(videotape);
        await context.SaveChangesAsync();
        return new OkObjectResult("Image uploaded");
    }

    public async Task<IActionResult> DeleteImage(VideotapeModel videotape)
    {
        await using var context = _dbFactory.CreateDbContext();
        videotape.ImagePath = null;
        context.VideTape.Update(videotape);
        await context.SaveChangesAsync();
        return new OkObjectResult("Image deleted");
    }
}