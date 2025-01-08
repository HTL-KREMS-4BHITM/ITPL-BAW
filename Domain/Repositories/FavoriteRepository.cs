using BAWLib;
using BAWLib.Configs;


namespace Domain.Repositories;

public class FavoriteRepository:ARepository<Favorite>
{
    public FavoriteRepository(MotorContext context) : base(context) { }
    
}