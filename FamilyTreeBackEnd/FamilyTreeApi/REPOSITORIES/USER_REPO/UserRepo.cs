using DATA_LAYER.CORE;
using ENTITIES.CORE;
using Microsoft.EntityFrameworkCore;
using SHARED.COMMON_REPO;
using System.Linq;
using System.Threading.Tasks;

namespace REPOSITORIES.USER_REPO
{
    public class UserRepo : CommonRepo<User> , IUserRepo
    {
        private CoreContext context;
        public UserRepo(CoreContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await context.User.Where(x => x.Email == email && x.IsDeleted == 0).FirstOrDefaultAsync();
            return user;
        }

    }
}
