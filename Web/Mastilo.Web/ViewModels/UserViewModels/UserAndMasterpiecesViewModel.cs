namespace Mastilo.Web.ViewModels.UserViewModels
{
    using Mastilo.Web.ViewModels.MasterpieceViewModels;

    public class UserAndMasterpiecesViewModel
    {
        public UserResponseViewModel UserResponse { get; set; }

        public PagableMasterpieces Masterpieces { get; set; }
    }
}