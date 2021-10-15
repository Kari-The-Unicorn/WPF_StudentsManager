using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WPF_StudentsManager.Base.Student;

namespace WPF_StudentsManager.Base
{
    public class Student : Observable // INotifyPropertyChanged Notify about property changes
                                      // (e.g when user changes input in txtFirstName, it updates content in list view)
                                      // type INotifyPropertyChanged then rgt click Implement interface, then
                                      // public event PropertyChangedEventHandler PropertyChanged; is generated
    {
        private string firstName;
        private string lastName;
        private bool isActive;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(); // because this property changed, optionally:
                                     // OnPropertyChanged(nameof(FirstName)); 
                                     // OnPropertyChanged("FirstName");
                                     // Here is OnPropertyChanged(); because private void OnPropertyChanged([CallerMemberName]string propertyName = null)
                                     // takes null by default, when caller doesn't pass any parameter, then compiler will use CallerMemberName, in this case FirstName
            }
        } // Steps:
          // 1. public string FirstName { get; set; } click on FirstName,
          // then Ctrl Dot & choose Convert to full property
          // 2. public string FirstName { get => firstName; set => firstName = value; }
          // move set => firstName = value; } to new line, then Ctrl Dot and choose Use block body for properties
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged();
            }
        }
    }
}