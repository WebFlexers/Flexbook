namespace Flexbook.Web.RequestModels
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        
        public AddressRequest Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
    }
}