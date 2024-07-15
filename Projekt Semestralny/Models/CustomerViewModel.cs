using ProjektSemestralny.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProjektSemestralny.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly DatabaseContext _context;

        public CustomerViewModel(DatabaseContext context)
        {
            _context = context;
            NewCustomer = new Customer();
            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer, CanExecuteUpdateOrDelete);
            DeleteCommand = new RelayCommand(DeleteCustomer, CanExecuteUpdateOrDelete);
        }

        public Customer NewCustomer { get; set; }
        public Customer? SelectedCustomer { get; set; }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public List<Customer> Customers => _context.Customers.ToList();

        private void AddCustomer(object? parameter)
        {
            if (IsValidCustomer(NewCustomer))
            {
                _context.Customers.Add(NewCustomer);
                _context.SaveChanges();
                RefreshCustomers();
                NewCustomer = new Customer();
                OnPropertyChanged(nameof(NewCustomer));
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCustomer(object? parameter)
        {
            if (SelectedCustomer != null && IsValidCustomer(NewCustomer))
            {
                var existingCustomer = _context.Customers.Find(SelectedCustomer.IdKlienta);
                if (existingCustomer != null)
                {
                    existingCustomer.Imie = NewCustomer.Imie;
                    existingCustomer.Nazwisko = NewCustomer.Nazwisko;
                    existingCustomer.NrTelefonu = NewCustomer.NrTelefonu;
                    _context.SaveChanges();
                    RefreshCustomers();
                }
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione oraz klient musi być wybrany.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCustomer(object? parameter)
        {
            if (SelectedCustomer != null)
            {
                var customer = _context.Customers.Find(SelectedCustomer.IdKlienta);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    RefreshCustomers();
                }
            }
        }

        private bool CanExecuteUpdateOrDelete(object? parameter)
        {
            return SelectedCustomer != null;
        }

        private void RefreshCustomers()
        {
            OnPropertyChanged(nameof(Customers));
        }

        private bool IsValidCustomer(Customer customer)
        {
            return !string.IsNullOrWhiteSpace(customer.Imie) &&
                   !string.IsNullOrWhiteSpace(customer.Nazwisko) &&
                   !string.IsNullOrWhiteSpace(customer.NrTelefonu);
        }

        public void TestSqlConnection()
        {
            try
            {
                _context.Database.CanConnect();
                MessageBox.Show("Połączenie z bazą danych jest poprawne.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Połączenie z bazą danych nie powiodło się.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
