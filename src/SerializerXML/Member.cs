namespace SerializerXML;

public record Member(string Name, string Email, int Age, DateTime JoiningDate, bool IsPlatinumMember)
{
    public Member() : this(string.Empty, string.Empty, 0, DateTime.UtcNow, false) { }
}