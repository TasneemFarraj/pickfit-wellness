namespace FITTNESS.Data.Models;

using FITTNESS.Data.Enum;

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public UserTypeEnum UserType { get; set; }
    }


