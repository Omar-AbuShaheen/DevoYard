using System.ComponentModel.DataAnnotations;

namespace Omar_Devoyard_v1.Models.Users
{
    public class UserModel
    {
  
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
        }


    }

