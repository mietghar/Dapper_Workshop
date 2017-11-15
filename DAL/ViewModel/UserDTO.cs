using System;

namespace DAL.ViewModel
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime ModifiedDate { get; set; }
    } 
}
