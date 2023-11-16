namespace Core.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; } 

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string FullName
        {
            get
            {
                return FirstName +  " " + LastName; 
            }
        }
    }
}
