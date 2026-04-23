namespace TeamProjectAPI.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Outdoor, Indoor, Creative, etc.
        public string Description { get; set; } = string.Empty;
        public int SkillLevel { get; set; } // 1-5
        public bool RequiresEquipment { get; set; }
    }
}
