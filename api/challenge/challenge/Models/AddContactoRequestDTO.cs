namespace challenge.Models
{
    public class AddContactoRequestDTO
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string comentario { get; set; }
    }
}
