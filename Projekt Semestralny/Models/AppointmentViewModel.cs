using ProjektSemestralny.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny.ViewModels
{
    public class AppointmentViewModel
    {
        private DatabaseContext _context;

        public AppointmentViewModel(DatabaseContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _context.Appointments.Find(appointment.Id);
            if (existingAppointment != null)
            {
                existingAppointment.CustomerId = appointment.CustomerId;
                existingAppointment.Date = appointment.Date;
                _context.SaveChanges();
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }
}