using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IOrderPartRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<OrderPart>> GetOrderParts(UserParams userParams);

        Task<PagedList<OrderPart>> GetCompanyOrderParts(int companyid, UserParams userParams );


        Task<OrderPart> GetOrderPart(int id);
        Task<bool> PartExists(string username);
        Task<bool> CompanyPartExists(int userid, int partid);

    }
}