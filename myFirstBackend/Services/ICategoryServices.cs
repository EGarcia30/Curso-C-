using myFirstBackend.Models.DataModels;

namespace myFirstBackend.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCoursesOfCategory(string CategoryName);
    }
}
