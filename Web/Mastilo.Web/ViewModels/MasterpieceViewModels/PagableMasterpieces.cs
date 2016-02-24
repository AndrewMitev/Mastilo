namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using System.Collections.Generic;

    public class PagableMasterpieces
    {
            public int CurrentPage { get; set; }

            public int TotalPages { get; set; }

            public IEnumerable<MasterpieceResponseViewModel> Masterpieces { get; set; }
    }
}