namespace WebEmployeeApp
{
    public class User
    {
        //add all employee properties from database to user
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; } //add first name
        public string LastName { get; set; } //add last name

        public string Email { get; set; }
        public string Phone { get; set; }

        public string EmergencyContact { get; set; }

        public string HourlyRate { get; set; }

        public int RoleID { get; set; }


    }

    //list of users
    public class Users : List<User>
    {
        public int Id { get; internal set; }
        public object FirstName { get; internal set; }
    }

}
