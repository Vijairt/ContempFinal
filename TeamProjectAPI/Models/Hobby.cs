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

        // READ operation - accepts an optional id from the query string.
        // If no id is provided or id is 0, it returns the first 5 records from the database.
        // If a valid id is provided, it looks up that specific record.
        // Returns 404 Not Found if the record does not exist.

        // CREATE operation - accepts an object in the request body as JSON.
        // Adds the new record to the database and saves the changes.
        // Returns 201 Created with the newly created record and its location.

        // DELETE operation - accepts the id in the URL.
        // Looks up the record in the database by id.
        // Returns 404 Not Found if the record does not exist.
        // Removes the record from the database and returns 204 No Content on success.

        // UPDATE operation - accepts the id in the URL and the updated object in the request body.
        // First checks that the id in the URL matches the id in the body to prevent mismatch errors.
        // Finds the existing record in the database and updates its values.
        // Returns 404 Not Found if no matching record exists, or 204 No Content on success.
    }
}
