using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class AppUsuario : IdentityUser
    {
        //[Key]
        public string Nombre { get; set; }

        public string Password { get; set; }
    }
}
