using System.Linq.Expressions;
using BAWLib.Configs;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class ARepository<TEntity> :IRepository<TEntity> where TEntity : class
{
    protected readonly MotorContext Context;
    protected readonly DbSet<TEntity> Table;
    protected ARepository(MotorContext context) {
        Context= context;
        Table = context.Set<TEntity>();
    }
    public TEntity Create(TEntity t) {
        Table.Add(t);
        Context.SaveChanges();
        return t;
    }
    public List<TEntity> CreateRange(List<TEntity> list) {
        Table.AddRange(list);
        Context.SaveChanges();
        return list;
    }
    public void Update(TEntity t) {
        Context.ChangeTracker.Clear();
        Table.Update(t);
        Context.SaveChanges();
    }
    public void UpdateRange(List<TEntity> list) {
        Table.UpdateRange(list);
        Context.SaveChanges();
    }
    public TEntity? Read(int id) => Table.Find(id);
    public List<TEntity> Read(Expression<Func<TEntity, bool>> filter) => Table.Where(filter).ToList();
    public List<TEntity> Read(int start, int count) =>
        Table.Skip(start)
            .Take(count)
            .ToList();
    public List<TEntity> ReadAll() => Table.ToList();
    public void Delete(TEntity t) {
        Table.Remove(t);
        Context.SaveChanges();
    }

    public void Delete(int bikeId, int userId)
    {
        var entity = Table.Find(bikeId, userId);
        Table.Remove(entity!);
        Context.SaveChanges();
    }
}