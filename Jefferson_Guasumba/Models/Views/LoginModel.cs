using System.ComponentModel.DataAnnotations;

namespace Jefferson_Guasumba.Models.Views
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor ingrese su Usuario") ]

        public string? Usuario { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor ingrese su Contraseña")]

        public string? Password { get; set; }

    }
}
