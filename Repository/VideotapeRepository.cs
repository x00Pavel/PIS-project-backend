using AutoMapper;
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
            .ToListAsync();
        return _mapper.Map<IList<VideotapeModel>, IList<VideoTapeEntityOutput>>(records);
    }
    
    public async Task<VideoTapeEntityOutput> AddVideotape(VideoTapeEntityInput videoTape)
    {
        var videoTapeMapped = _mapper.Map<VideotapeModel>(videoTape);
        await using var context = _dbFactory.CreateDbContext();
        var result = await context.VideTape.AddAsync(videoTapeMapped);
        Unchanged(context, videoTapeMapped.Actors, videoTapeMapped.Genre);
        await context.SaveChangesAsync();
        return _mapper.Map<VideotapeModel, VideoTapeEntityOutput>(result.Entity);
    }
    
    public async Task<VideotapeModel> GetVideotapeModel(Guid id)
    {
        await using var context = _dbFactory.CreateDbContext();
        return await context.VideTape
            .Include(x => x.Actors)
            .Include(x => x.Genre)
            .FirstAsync(x => x.Id == id);
    }

}