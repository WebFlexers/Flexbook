using Flexbook.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Services.Statistics;

public interface IStatisticsService
{
    public List<Data.Models.OrderSystem.Order> GetAllOrdersByAuthorId(int author_id);

    public Book GetBestSellerBookOfAuthor(int author_id);
}
