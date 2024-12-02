using System.Text.RegularExpressions;
using Domain.Interfaces;

namespace Domain.Repositories;

public class GroupRepository:ARepository<Group>
{
    public GroupRepository(MotorContext context) : base(context)
    {
    }
}