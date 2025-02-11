using BAWLib.Configs;
using BAWLib.Entities;

namespace Domain.Repositories;

public class GroupMembersRepository:ARepository<GroupMembers_JT>
{
    public GroupMembersRepository(MotorContext context) : base(context)
    {
    }
}