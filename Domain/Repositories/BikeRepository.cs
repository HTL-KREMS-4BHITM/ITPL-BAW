using BAWLib;

namespace Domain.Repositories;

public class BikeRepository:ARepository<Motorbike>
{
    public BikeRepository(MotorContext context) : base(context)
    {
    }
}