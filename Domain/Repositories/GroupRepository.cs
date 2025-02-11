using BAWLib;
using BAWLib.Configs;
using Domain.Interfaces;

namespace Domain.Repositories;

public class GroupRepository:ARepository<Groups>
{
    public GroupRepository(MotorContext context) : base(context)
    {
    }
}