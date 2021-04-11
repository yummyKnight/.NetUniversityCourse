using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApp.BLL.Contracts {
    public interface ICreateService<TUpdateModel, TIdentityModel, TDomainClass>
        where TUpdateModel : TIdentityModel where TDomainClass : class {
        Task<TDomainClass> CreateAsync(TUpdateModel model);
    }

    public interface IUpdateService<TUpdateModel, TIdentityModel, TDomainClass> where
        TDomainClass : class
        where TIdentityModel : class
        where TUpdateModel : TIdentityModel {
        Task<TDomainClass> UpdateAsync(TUpdateModel model);
    }

    public interface IGetService<TIdentityModel, TDomainClass> where TIdentityModel : class where TDomainClass : class {
        Task<IEnumerable<TDomainClass>> GetAsync();
        Task<TDomainClass> GetAsync(TIdentityModel employee);

        Task ValidateAsync(TIdentityModel model);
    }

    public interface IDeleteService<TIdentityModel> where TIdentityModel : class {
        Task DeleteAsync(TIdentityModel model);
    }
}