using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;

namespace WebApp.DAL {
    // class CreateUpdateRepository<TDomainClass, TIdentityModel, TUpdateModel, TEntityModel>
    //     where TDomainClass : class
    //     where TIdentityModel : class
    //     where TUpdateModel : class
    //     where TEntityModel : class
    // {
    //     private HotelDBContext Context { get; }
    //     private IMapper Mapper { get; }
    //     
    //
    //     public CreateUpdateRepository(HotelDBContext context, IMapper mapper) {
    //         Context = context;
    //         Mapper = mapper;
    //     }
    //     public async Task<TDomainClass> CreateAsync(TUpdateModel model) {
    //         var result = await dbSet.AddAsync(Mapper.Map<TEntityClass>(model));
    //         await Context.SaveChangesAsync();
    //         return Mapper.Map<TDomainClass>(result.Entity);
    //     }
    //
    //     public async Task<TDomainClass> UpdateAsync(TUpdateModel model) {
    //         var existing = await GetByAsync(model);
    //         var result = Mapper.Map(model, existing);
    //         Context.Clients.Update(result);
    //         await Context.SaveChangesAsync();
    //         return Mapper.Map<TDomainClass>(result);
    //     }
    //
    //     public async void DeleteAsync(TIdentityModel model) {
    //         dbSet.Remove(Mapper.Map<TEntityClass>(model));
    //         await Context.SaveChangesAsync();
    //     }
    //
    //     // public IEnumerable<TDomainClass> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties) {
    //     //     return Include(includeProperties).ToList();
    //     // }
    //
    //     // public IEnumerable<TDomainClass> GetWithInclude(Func<TDomainClass, bool> predicate,
    //     //     params Expression<Func<TDomainClass, object>>[] includeProperties) {
    //     //     var query = Include(includeProperties);
    //     //     return query.Where(predicate).ToList();
    //     // }
    //     //
    //     // private IQueryable<TDomainClass> Include(params Expression<Func<TEntity, object>>[] includeProperties) {
    //     //     IQueryable<TDomainClass> query = _dbSet.AsNoTracking();
    //     //     return includeProperties
    //     //         .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    //     // }
    // }
}