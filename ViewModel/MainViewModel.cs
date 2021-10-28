using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF_StudentsManager.DataProvider;
using WPF_StudentsManager.Model;

namespace WPF_StudentsManager.ViewModel
{
    public class MainViewModel
    {
        private IStudentsDataProvider _studentsDataProvider;

        public MainViewModel(IStudentsDataProvider studentsDataProvider)
        {
            _studentsDataProvider = studentsDataProvider;
            Students = new ObservableCollection<Student>();
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
