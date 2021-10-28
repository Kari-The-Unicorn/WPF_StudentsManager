using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_StudentsManager.Model;

namespace WPF_StudentsManager.DataProvider
{
    public interface IStudentsDataProvider
    {
        Task<IEnumerable<Student>> LoadStudentsAsync();
        Task SaveStudentsAsync(IEnumerable<Student> students);
    }
}