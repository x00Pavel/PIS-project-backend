using video_pujcovna_back.Models;

namespace video_pujcovna_back.DTO.Output;


public class UserEntityOutput: UserBaseDTO
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }
    public IEnumerable<string> Roles { get; set; }
    public IEnumerable<Guid> Reservations { get; set; }
    
    public override string ToString()
    {
        return $"{nameof(UserName)}: {UserName}; {nameof(Roles)}: {Roles} ; {nameof(Email)}: {Email}; {nameof(Reservations)}: {Reservations}";
    }
}