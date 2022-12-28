using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myFirstBackend.Models.DataModels
{
    public class Services
    {

        public static IEnumerable<User> SearchForEmail(string Email)
        {
            var newUser = new[] {
                new User()
            };

            var UserForEmail = newUser.Where(user => user.Email == Email);

            return UserForEmail;
        }
    }
}
