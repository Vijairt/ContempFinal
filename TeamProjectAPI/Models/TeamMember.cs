namespace TeamProjectAPI.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string CollegeProgram { get; set; } = string.Empty;
        public string YearInProgram { get; set; } = string.Empty; // Freshman, Sophomore, Junior, Senior
        public string Email { get; set; } = string.Empty;
    }
}
