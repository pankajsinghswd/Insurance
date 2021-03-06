namespace Insurance.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName_en { get; set; }
        public string FullName_local { get; set; }
        public string PhoneNumber { get; set; }
        public string Interest_en { get; set; }
        public string Interest_local { get; set; }
        public string IsBlocked { get; set; }
        public string IsDeleted{ get; set; }
        public string RegisteredOn { get; set; }
    }
}