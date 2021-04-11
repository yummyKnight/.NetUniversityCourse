using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.DAL;

namespace WebApp.BLL.Implementations {
    public class
        GenericCreateService<TIRepository, TUpdateModel, TDomainClass, TIdentityModel> : ICreateService<TUpdateModel,
            TIdentityModel,
            TDomainClass>
        where TUpdateModel : TIdentityModel
        where TDomainClass : class
        where TIdentityModel : class
        where TIRepository : IRepository<TDomainClass, TIdentityModel, TUpdateModel> {
        private TIRepository _repository;

        public GenericCreateService(TIRepository repository) {
            _repository = repository;
        }

        public async Task<TDomainClass> CreateAsync(TUpdateModel model) {
            return await _repository.CreateAsync(model);
        }
    }


    public class
        GenericGetService<TIRepository, TUpdateModel, TDomainClass, TIdentityModel> : IGetService<TIdentityModel,
            TDomainClass>
        where TUpdateModel : TIdentityModel
        where TDomainClass : class
        where TIdentityModel : class
        where TIRepository : IRepository<TDomainClass, TIdentityModel, TUpdateModel> {
        private TIRepository _repository;
        
        public async Task<IEnumerable<TDomainClass>> GetAsync() {
            return await _repository.GetByAsync();
        }

        public async Task<TDomainClass> GetAsync(TIdentityModel model) {
            return await _repository.GetByAsync(model);
        }

        public virtual Task ValidateAsync(TIdentityModel model) {
            throw new System.NotImplementedException();
        }

        public GenericGetService(TIRepository repository) {
            _repository = repository;
        }
    }

    public class
        GenericUpdateService<TIGetService, TIRepository, TUpdateModel, TDomainClass, TIdentityModel> : IUpdateService<
            TUpdateModel,
            TIdentityModel,
            TDomainClass>
        where TUpdateModel : TIdentityModel
        where TDomainClass : class
        where TIdentityModel : class
        where TIRepository : IRepository<TDomainClass, TIdentityModel, TUpdateModel>
        where TIGetService : IGetService<TIdentityModel, TDomainClass> {
        private TIRepository _repository;
        private TIGetService _service;

        public GenericUpdateService(TIRepository repository, TIGetService getService) {
            _repository = repository;
            _service = getService;
        }

        public async Task<TDomainClass> UpdateAsync(TUpdateModel model) {
            await _service.ValidateAsync(model);
            return await _repository.UpdateAsync(model);
        }
    }

    public class
        GenericDeleteService<TIGetService, TIRepository, TUpdateModel, TDomainClass,
            TIdentityModel> : IDeleteService<TIdentityModel>
        where TUpdateModel : TIdentityModel
        where TDomainClass : class
        where TIdentityModel : class
        where TIRepository : IRepository<TDomainClass, TIdentityModel, TUpdateModel>
        where TIGetService : IGetService<TIdentityModel, TDomainClass> {
        private TIRepository _repository;
        private TIGetService _service;

        public GenericDeleteService(TIRepository repository, TIGetService service) {
            _repository = repository;
            _service = service;
        }

        public async Task DeleteAsync(TIdentityModel model) {
            await _service.ValidateAsync(model);
            await _repository.DeleteAsync(model);
        }
    }
}