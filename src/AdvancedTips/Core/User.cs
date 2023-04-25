namespace AdvancedTips.Core;

public class User
{
    public User()
    {

    }
    public User(string name, string email, string cpf)
    {
        Name = name;
        Email = email;
        Cpf = cpf;
    }

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
}