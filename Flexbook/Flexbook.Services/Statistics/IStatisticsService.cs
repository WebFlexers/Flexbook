using Flexbook.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Services.Statistics;

public interface IStatisticsService
{
    Dictionary<int, int> GetBooksSalesOfAuthor(int authorId);
}
