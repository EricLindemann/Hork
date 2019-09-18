using Hork_Api.Entities;

namespace Hork_Api.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>
    {         
        public UserProfileRepository(HorkContext context)
                : base(context)
        { }

    }
}