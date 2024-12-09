using BAWLib;
using BAWLib.Configs;

namespace Domain.Repositories;

public class UserRepository:ARepository<User>
{
    public UserRepository(MotorContext context) : base(context)
    {
    }
}