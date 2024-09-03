namespace challenge.Models.Domain
{
    public class Contacto
    {
        public Guid id { get; set; }
        
        public required string Nombre { get; set; }

        public required string Apellido { get; set; }
        public required string Email { get; set; }
       
        public required string comentario { get; set; }
        //public string? comentario { get; set; }

    }
}
