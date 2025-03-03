namespace LibraryDomain.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
