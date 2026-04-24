// ============================================================
// PRESENTATION NOTE - TeamMember.cs
// This is a Model class. In Entity Framework Core, each model
// class maps directly to a table in the database.
// Each property in this class becomes a column in the table.
// ============================================================

namespace TeamProjectAPI.Models
{
    public class TeamMember
    {
        // PRESENTATION NOTE: Primary key - Entity Framework automatically
        // makes this the unique identifier and auto-increments it for each new record.
        public int Id { get; set; }

        // PRESENTATION NOTE: Stores the full name of the team member as a string.
        public string FullName { get; set; } = string.Empty;

        // PRESENTATION NOTE: Stores the date of birth as a DateTime value.
        // This satisfies the rubric requirement for a Birthdate column.
        public DateTime Birthdate { get; set; }

        // PRESENTATION NOTE: Stores the college major or program the student is enrolled in.
        public string CollegeProgram { get; set; } = string.Empty;

        // PRESENTATION NOTE: Stores the year in program - Freshman, Sophomore, Junior, or Senior.
        // This satisfies the rubric requirement for year in program.
        public string YearInProgram { get; set; } = string.Empty;

        // PRESENTATION NOTE: Stores the student's email address.
        public string Email { get; set; } = string.Empty;
    }
}
