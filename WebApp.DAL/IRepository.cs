﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.DAL {
    public interface IRepository<TDomainClass, TIdentityModel, TUpdateModel> 
        where TDomainClass : class 
        where TIdentityModel : class
        where TUpdateModel : class
    {
        Task<IEnumerable<TDomainClass>> GetByAsync(); // получение всех объектов
        Task<TDomainClass> GetByAsync(TIdentityModel model); // получение одного объекта по id
        Task<TDomainClass> CreateAsync(TUpdateModel model); // создание объекта
        Task<TDomainClass> UpdateAsync(TUpdateModel model); // обновление объекта
        void DeleteAsync(TIdentityModel model); // удаление объекта по id
    }

    
}