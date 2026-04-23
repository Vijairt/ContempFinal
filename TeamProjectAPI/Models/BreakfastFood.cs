namespace TeamProjectAPI.Models
{
    public class BreakfastFood
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty; // American, Mexican, etc.
        public int Calories { get; set; }
        public bool IsVegetarian { get; set; }
        public string PreparationTime { get; set; } = string.Empty; // e.g., "5 mins", "20 mins"
    }
}
