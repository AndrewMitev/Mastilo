namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using System.Collections.Generic;

    public class PagableMasterpieces
    {
            public string SortField { get; set; }

            public string SortDirection { get; set; }

            public string Search { get; set; }

            public int CurrentPage { get; set; }

            public int TotalPages { get; set; }

            public IEnumerable<MasterpieceResponseViewModel> Masterpieces { get; set; }
    }
}