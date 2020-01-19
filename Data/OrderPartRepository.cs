using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class OrderPartRepository : IOrderPartRepository
    {
        private readonly DataContext _context;


        public OrderPartRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<OrderPart> GetOrderPart(int id)
        {
            var orderPart = await _context.OrderParts.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return orderPart;
        }

        public async Task<List<OrderPart>> GetParts2()
        {
            return await _context.OrderParts.Include(p => p.Photos).ToListAsync<OrderPart>();
        }

        public async Task<string> GetCompanyName(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user.CompanyName;
        }

        public async Task<bool> PartExists(string partname)
        {
            if (await _context.OrderParts.AnyAsync(x => x.PartName == partname))
                return true;

            return false;
        }

        public async Task<bool> CompanyPartExists(int userid, int partid)
        {
            if (await _context.CompanyParts.AnyAsync(x => (x.OrderPartId == partid && x.UserId == userid)))
                return true;

            return false;
        }

        public async Task<PagedList<OrderPart>> GetCompanyOrderParts(int companyid, UserParams userParams)
        {
            List<int> ids = (from cp in _context.CompanyParts where cp.UserId == companyid select cp.OrderPartId).ToList<int>();
            var orderparts = _context.OrderParts.Where(p => ids.Contains(p.Id));
            return await PagedList<OrderPart>.CreateAsync(orderparts, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<OrderPart>> GetOrderParts(UserParams userParams)
        {
            var orderparts = _context.OrderParts.Include(p => p.Photos)
                .OrderByDescending(u => u.added);


            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        orderparts = orderparts.OrderByDescending(u => u.added);
                        break;
                    default:
                        orderparts = orderparts.OrderByDescending(u => u.added);
                        break;
                }
            }

            return await PagedList<OrderPart>.CreateAsync(orderparts, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            { return false; }
        }

    }
}