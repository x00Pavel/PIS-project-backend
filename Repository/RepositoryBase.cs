using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

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

    protected void Unchanged(AppDbContext context, params object?[] fields)
    {
        foreach (var field in fields)
        {   
            if (field is IList)
            {
                foreach (var item in (IEnumerable<object>)field)
                {
                    context.Entry(item).State = EntityState.Unchanged;
                }
            }
            else
            {
                context.Entry(field).State = EntityState.Unchanged;    
            }
        }
    }
    
    public void Modified(AppDbContext context, params object[] fields)
    {
        foreach (var field in fields)
        {   
            if (field is IList)
            {
                foreach (var item in (IEnumerable<object>)field)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
            }
            else
            {
                context.Entry(field).State = EntityState.Modified;    
            }
        }
    }
    
}