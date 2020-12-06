using Domain.User.Repository.Facade;
using Domain.User.Repository.PO;
using Domain.User.SeedWork;

namespace Domain.User.Repository.Persistence
{
    public class UserLoginRepository : BaseRepository<UserLoginInfo>, IUserLoginRepository
    {

    }
}
