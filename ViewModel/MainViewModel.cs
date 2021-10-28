using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF_StudentsManager.Base;
using WPF_StudentsManager.DataProvider;
using WPF_StudentsManager.Model;

namespace WPF_StudentsManager.ViewModel
{
    public class MainViewModel : Observable
    {
        private IStudentsDataProvider _studentsDataProvider;
        private Student _selectedStudent;

        public MainViewModel(IStudentsDataProvider studentsDataProvider)
        {
            _studentsDataProvider = studentsDataProvider;
            Students = new ObservableCollection<Student>();
        }

        //propfull part 1
        //private Student _selectedStudent;
        //propfull part 2
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                // if _selectedStudent is not equal to selected student that we have already
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Student> Students { get; }

        // Load students to View Model
        public async Task LoadAsync()
        {
            Students.Clear();
            var students = await _studentsDataProvider.LoadStudentsAsync();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
        
        public async Task SaveAsync()
        {
            await _studentsDataProvider.SaveStudentsAsync(Students);
        }
    }
}
