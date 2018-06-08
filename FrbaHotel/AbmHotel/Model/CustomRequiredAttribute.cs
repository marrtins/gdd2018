using System;
using System.ComponentModel.DataAnnotations;

namespace FrbaHotel.AbmHotel.Model
{
    internal class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute()
            :base()
        {
            this.ErrorMessage = "Este campo es requerido";
        }
    }
}