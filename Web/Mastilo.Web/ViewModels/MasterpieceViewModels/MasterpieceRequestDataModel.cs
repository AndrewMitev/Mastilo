namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using System.Collections.Generic;
    using Mastilo.Web.ViewModels.GenreViewModels;

    public class MasterpieceRequestDataModel
    {
        public ICollection<GenreViewModel> Genres { get; set; }

        public MasterpieceRequestViewModel Masterpiece { get; set; }

        public IEnumerable<string> SelectedGroups { get; set; }
    }
}