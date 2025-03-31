using Microsoft.EntityFrameworkCore;
using Sales_Web_MVC.Models;
using Sales_Web_MVC.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_Web_MVC.Services
{
    public class SellerService
    {
        // adiciono a injeção dele no startup
        private readonly Sales_Web_MVCContext _context;
        public SellerService(Sales_Web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() 
            => await _context.Seller.ToListAsync();

        // o find by id, dessa maneira, retorna apenas o Seller, se carregar o Department do seller! Preciso de um "join"
        //public Seller FindById(int Id) => _context.Seller.FirstOrDefault(obj => obj.Id == Id);
        public async Task<Seller> FindByIdAsync(int Id) 
            => await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == Id);
        
        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(Id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
        
        public async Task Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            var hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
                throw new NotFoundException("Id not found for update!");

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
