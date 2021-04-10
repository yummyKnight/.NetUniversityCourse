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

    class UpdateService<TUpdateModel, TDomainClass> : IUpdateService<TUpdateModel, TDomainClass> where TUpdateModel : class where TDomainClass : class {
        public Task<TDomainClass> UpdateAsync(TUpdateModel model) {
            throw new System.NotImplementedException();
        }
    }

    public interface IGetService<TIdentityModel, TDomainClass> where TIdentityModel : class where TDomainClass : class {
        Task<IEnumerable<TDomainClass>> GetAsync();
        Task<TDomainClass> GetAsync(TIdentityModel employee);
    }

    public interface IDeleteService<TIdentityModel> where TIdentityModel : class {
        Task DeleteAsync(TIdentityModel model);
    }

    public interface IValidateService<TIdentityModel> where TIdentityModel : class {
        Task ValidateAsync(TIdentityModel model, bool isTracked=false);
    }

    public class CreateService<TUpdateModel, TDomainClass> : ICreateService<TUpdateModel, TDomainClass>
        where TUpdateModel : class
        where TDomainClass : class {
        public Task<TDomainClass> CreateAsync(TUpdateModel model) {
            throw new System.NotImplementedException();
        }
    }
}