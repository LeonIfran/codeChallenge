using challenge.Data;
using challenge.Models;
using challenge.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContactoDbContext dbContext;

        public ContactosController(ContactoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllContactos()
        {
           var contactos = dbContext.Contactos.ToList();
            return Ok(contactos);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactoRequestDTO request)
        {
            var domainModelContacto = new Contacto
            {
                id = Guid.NewGuid(),
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,
                comentario = request.comentario
            };

            dbContext.Contactos.Add(domainModelContacto);
            dbContext.SaveChanges();

            return Ok(domainModelContacto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
           var contacto = dbContext.Contactos.Find(id);

            if(contacto is not null)
            {
                dbContext.Contactos.Remove(contacto);
                dbContext.SaveChanges();
            }

            return Ok();
        }

    }
}
