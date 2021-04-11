using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;

namespace WebApp.DAL {
    public interface IRepository<TDomainClass, TIContainer, TUpdateModel>
        where TDomainClass : class
        where TIContainer : class
        where TUpdateModel : TIContainer {
        Task<IEnumerable<TDomainClass>> GetByAsync(); // получение всех объектов
        Task<TDomainClass> GetByAsync(TIContainer model); // получение одного объекта по id
        Task<TDomainClass> CreateAsync(TUpdateModel model); // создание объекта
        Task<TDomainClass> UpdateAsync(TUpdateModel model); // обновление объекта
        Task DeleteAsync(TIContainer model); // удаление объекта по id
    }

    public interface IClientRepository : IRepository<Domain.Client, IClientContainer, ClientUpdateModel> {
    }
}