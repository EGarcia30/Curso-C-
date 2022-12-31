using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myFirstBackend.Models.DataModels
{
    public class Services
    {

        public static void SearchForEmail(string Email)
        {
            var newUser = new[] {
                new User()
            };

            var UserForEmail = newUser.Where(user => user.Email.Contains(Email));
        }

        public static void OlderStudents(int Edad)
        {
            DateTime date = DateTime.Now;

            var newStudents = new[]
            {
                new Student()
            };

            var OlderStudents = from student in newStudents
                                let Dob = student.Dob.Year
                                let dateNow = date.Year
                                where Dob - dateNow >= 18
                                select student;
        }

        public static void CourseValidation()
        {
            var newStudents = new[]
            {
                new Student()
            };

            var StudentCourseValidation = newStudents.Where(student => student.Courses.Count() > 0);
        }


    }
}
