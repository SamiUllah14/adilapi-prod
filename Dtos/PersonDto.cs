namespace adilapi
{
    public class PersonDto
    {
        public int Id { get; set; } // Add Id if needed in the response
        public string? Name { get; set; } // Nullable string
        public string? Address { get; set; } // Nullable string
        public string? MobileNumber { get; set; } // Nullable string
        public string? Password { get; set; } // Password added as nullable string
    }
}
