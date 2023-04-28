using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class GenreRepository: IRepository
{
    private readonly DbContextFactory _dbFactory;
    private readonly IMapper _mapper;

    public GenreRepository(DbContextFactory dbFactory, IMapper mapper)
    {
        _dbFactory = dbFactory;
        _mapper = mapper;
    }

    public async Task<GenreEntity> GetGenre(string name)
    {
        await using var context = _dbFactory.CreateDbContext();
        return _mapper.Map<GenreEntity>(GetGenreModel(name).Result);
    }

    public async Task<GenreModel> GetGenreModel(string name)
    {
        await using var context = _dbFactory.CreateDbContext();
        return await context.Genre.FirstAsync(x => x.Name == name);
    }

    public async Task<ICollection<GenreEntity>> GetAllGenres()
    {
        await using var context = _dbFactory.CreateDbContext();
        return _mapper.Map<ICollection<GenreEntity>>(await context.Genre.ToListAsync());
    }

    public async Task<GenreEntity> AddGenre(GenreEntity genre)
    {
        await using var context = _dbFactory.CreateDbContext();
        var genreModel = _mapper.Map<GenreModel>(genre);
        
        if (await context.Genre.AnyAsync(x => x.Name == genreModel.Name))
        {
            throw new Exception("Genre already exists");
        }

        await context.Genre.AddAsync(genreModel);
        await context.SaveChangesAsync();
        return _mapper.Map<GenreEntity>(genreModel);
    }

    public async Task<GenreEntity> DeleteGenre(string genreName)
    {
        await using var context = _dbFactory.CreateDbContext();
        var genreModel = await context.Genre.FirstOrDefaultAsync(x => x.Name == genreName);

        if (genreModel == null)
        {
            throw new Exception("Genre does not exist");
        }
        
        context.Genre.Remove(genreModel);
        await context.SaveChangesAsync();
        return _mapper.Map<GenreEntity>(genreModel);
    }

    public async Task<GenreEntity> UpdateGenre(string genreName, GenreEntity genre)
    {
        await using var context = _dbFactory.CreateDbContext();
        var origGenre = context.Genre.FirstOrDefault(x => x.Name == genreName);

        if (origGenre == null)
        {
            throw new Exception("Genre does not exist");
        }

        origGenre.Name = genre.Name;
        await context.SaveChangesAsync();
        return _mapper.Map<GenreEntity>(origGenre);
    }
}