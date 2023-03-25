using AutoMapper;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.DTO.Input;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Repository;

public class GenreRepository
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

}