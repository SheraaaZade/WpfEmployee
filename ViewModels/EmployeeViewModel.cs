using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfEmployee.Models;

namespace WpfEmployee
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        private NorthwindContext _context = new NorthwindContext();
        public List<EmployeeModel> EmployeesList {

            get
            {
                List<EmployeeModel> localList = new List<EmployeeModel>();
                foreach (Employee emp in _context.Employees)
                {
                    localList.Add(new EmployeeModel(emp));
                }
                return localList;
            }
                        
 

        }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        // Implémentez vos commandes ici (AddCommand, SaveCommand, etc.)

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
