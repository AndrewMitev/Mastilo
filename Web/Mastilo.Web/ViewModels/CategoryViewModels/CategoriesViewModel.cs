namespace Mastilo.Web.ViewModels.CategoryViewModels
{
    using Mastilo.Data.Models;
    using Mastilo.Web.Infrastructure.Mapping;

    public class CategoriesViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public string Name { get; set; }
    }
}