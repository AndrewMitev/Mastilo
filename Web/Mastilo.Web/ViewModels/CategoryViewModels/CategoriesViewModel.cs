using Mastilo.Data.Models;
using Mastilo.Web.Infrastructure.Mapping;

namespace Mastilo.Web.ViewModels.CategoryViewModels
{
    public class CategoriesViewModel: IMapFrom<Category>, IMapTo<Category>
    {
        public string Name { get; set; }
    }
}