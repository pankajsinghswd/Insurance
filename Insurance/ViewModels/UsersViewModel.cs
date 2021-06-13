namespace Insurance.ViewModels
{
    public class TherapistViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string IsBlocked { get; set; }
        public string IsActive { get; set; }
        public string RegisteredOn { get; set; }
    }
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Interest { get; set; }
        public string IsBlocked { get; set; }
        public string IsDeleted{ get; set; }
        public string RegisteredOn { get; set; }
    }
}