namespace Flexbook.Web.RequestModels;

public class AddressRequest
{
    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
}