using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApp.BLL.Contracts {
    public interface ICreateService<TUpdateModel, TDomainClass> where TUpdateModel : class where TDomainClass : class {
        Task<TDomainClass> CreateAsync(TUpdateModel model);
    }

    public interface IUpdateService<TUpdateModel, TDomainClass> where TUpdateModel : class where TDomainClass : class {
        Task<TDomainClass> UpdateAsync(TUpdateModel model);
    }

    public interface IGetService<TIdentityModel, TDomainClass> where TIdentityModel : class where TDomainClass : class {
        Task<IEnumerable<TDomainClass>> GetAsync();
    }

    public interface IDeleteService<TIdentityModel> where TIdentityModel : class {
        void DeleteAsync(TIdentityModel model);
    }
    
    public interface IValidateService<TIdentityModel> where TIdentityModel : class {
        void ValidateAsync(TIdentityModel model);
    }
}