using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using System.ComponentModel.DataAnnotations;
namespace TarefasApi.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {
            ErrorMessage = "A data deve ser no futuro.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true; // deixa o [Required] cuidar disso

            DateTime data;
            bool convertido = DateTime.TryParse(value.ToString(), out data);

            return convertido && data > DateTime.Now;
        }
    }
}
