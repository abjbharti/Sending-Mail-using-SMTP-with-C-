public class EmailDetails
{
    public int Email_Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public EmailDetails(int id, string name, string email)
    {
        this.Email_Id = id;
        this.Name = name;
        this.Email = email;
    }

}
