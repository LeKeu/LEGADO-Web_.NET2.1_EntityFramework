using Sales_Web_MVC.Models;
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
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
