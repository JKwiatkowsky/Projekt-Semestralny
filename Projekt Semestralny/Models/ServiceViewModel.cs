using ProjektSemestralny.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny.ViewModels
{
    public class ServiceViewModel
    {
        private DatabaseContext _context;

        public ServiceViewModel(DatabaseContext context)
        {
            _context = context;
        }

        public List<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            var existingService = _context.Services.Find(service.Id);
            if (existingService != null)
            {
                existingService.Name = service.Name;
                existingService.Price = service.Price;
                _context.SaveChanges();
            }
        }

        public void DeleteService(int serviceId)
        {
            var service = _context.Services.Find(serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}