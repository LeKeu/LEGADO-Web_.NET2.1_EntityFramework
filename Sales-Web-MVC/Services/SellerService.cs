using Microsoft.EntityFrameworkCore;
using Sales_Web_MVC.Models;
using Sales_Web_MVC.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

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

        public List<Seller> FindAll() => _context.Seller.ToList();

        // o find by id, dessa maneira, retorna apenas o Seller, se carregar o Department do seller! Preciso de um "join"
        //public Seller FindById(int Id) => _context.Seller.FirstOrDefault(obj => obj.Id == Id);
        public Seller FindById(int Id) => _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == Id);
        public void Remove(int Id)
        {
            var obj = FindById(Id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
                throw new NotFoundException("Id not found for update!");

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
