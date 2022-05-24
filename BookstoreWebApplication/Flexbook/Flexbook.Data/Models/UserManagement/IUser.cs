namespace Flexbook.Data.Models.UserManagement
{
    public interface IUser : ILoginManagement
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
