using ProjektSemestralny.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny.ViewModels
{
    public class CompletedServiceViewModel
    {
        private DatabaseContext _context;

        public CompletedServiceViewModel(DatabaseContext context)
        {
            _context = context;
        }

        public List<CompletedService> GetCompletedServices()
        {
            return _context.CompletedServices.ToList();
        }

        public void AddCompletedService(CompletedService completedService)
        {
            _context.CompletedServices.Add(completedService);
            _context.SaveChanges();
        }

        public void UpdateCompletedService(CompletedService completedService)
        {
            var existingCompletedService = _context.CompletedServices.Find(completedService.Id);
            if (existingCompletedService != null)
            {
                existingCompletedService.ServiceId = completedService.ServiceId;
                existingCompletedService.CustomerId = completedService.CustomerId;
                existingCompletedService.CompletionDate = completedService.CompletionDate;
                _context.SaveChanges();
            }
        }

        public void DeleteCompletedService(int completedServiceId)
        {
            var completedService = _context.CompletedServices.Find(completedServiceId);
            if (completedService != null)
            {
                _context.CompletedServices.Remove(completedService);
                _context.SaveChanges();
            }
        }
    }
}