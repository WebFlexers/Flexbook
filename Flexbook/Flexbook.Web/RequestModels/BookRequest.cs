namespace Flexbook.Web.RequestModels;

public class BookRequest
{
    // Product information
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public double StartingPrice { get; set; }
    public double FinalPrice { get; set; }
    
    // Book information
    public string ISBN { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; }
    public string Summary { get; set; }
    public int AuthorId { get; set; }
}