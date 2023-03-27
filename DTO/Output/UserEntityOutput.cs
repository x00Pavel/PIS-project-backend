using video_pujcovna_back.Models;

namespace video_pujcovna_back.DTO.Output;


public class UserEntityOutput
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public RoleEntityOutput Role { get; set; }
    public IEnumerable<Guid> Reservations { get; set; }
    
    public override string ToString()
    {
        return $"{nameof(Username)}: {Username}, {nameof(Role)}: | {Role} |, {nameof(Reservations)}: {Reservations}";
    }
}