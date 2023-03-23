using video_pujcovna_back.Models;

namespace video_pujcovna_back.DTO.Output;


public class UserEntityOutput
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public RoleEntityOutput Role { get; set; }
    public IEnumerable<Guid> Reservations { get; set; }
    
    public override string ToString()
    {
        return $"{nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(Role)}: | {Role} |, {nameof(Reservations)}: {Reservations}";
    }

    // public UserEntityOutput MapTo<UserModel, UserEntityOutput>(UserModel input)
    // {
    //     throw new NotImplementedException();
    // }

    // public UserEntityOutput MapTo<UserModel, UserEntityOutput>(UserModel input) where UserModel : new() where UserEntityOutput : class
    // {
    //     throw new NotImplementedException();
    // }


    /*
    public UserEntityOutput MapTo<UserModel>(UserModel input)
    {
        return new()
        {
            Username = input.Username,
            Password = input.Password,
            Role = Role. input.Role,
            // Reservations = input.Reservations.Select(x => x.Id)
        };
    } */
}