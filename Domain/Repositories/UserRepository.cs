using BAWLib;
using BAWLib.Configs;

namespace Domain.Repositories;

public class UserRepository:ARepository<User>
{
    protected UserRepository(MotorContext context) : base(context)
    {
    }
}