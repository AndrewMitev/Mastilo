namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using Mastilo.Web.ViewModels.GenreViewModels;
    using System.Collections.Generic;

    public class MasterpieceRequestDataModel 
    {
        public ICollection<GenreViewModel> Genres { get; set; }

        public MasterpieceRequestViewModel Masterpiece { get; set; }

        public IEnumerable<string> SelectedGroups { get; set; }
    }
}