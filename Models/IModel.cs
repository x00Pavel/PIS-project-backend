using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_pujcovna_back.Models;

public interface IModel
{
    public Guid Id { get; set; }
}