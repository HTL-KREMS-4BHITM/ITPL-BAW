using BAWLib;
using BAWLib.Configs;
using Domain.Interfaces;

namespace Domain.Repositories;

public class FavoriteRepository:ARepository<Favorite>
{
    public FavoriteRepository(MotorContext context) : base(context) { }
    
}