using BAWLib;
using BAWLib.Configs;

namespace Domain.Repositories;

public class WaypointsRepository:ARepository<Waypoint>
{
    public WaypointsRepository(MotorContext context) : base(context)
    {
    }
}