using Sales_Web_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sales_Web_MVC.Services
{
    public class DepartmentService
    {
        private readonly Sales_Web_MVCContext _context;
        public DepartmentService(Sales_Web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() 
            => await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}
