using BAWLib;
using BAWLib.Configs;
using BAWLib.Entities;

namespace Domain.Repositories;

public class BikeRepository:ARepository<Motorbike>
{
    public BikeRepository(MotorContext context) : base(context)
    {
    }
}