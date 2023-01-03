using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
    }
}
