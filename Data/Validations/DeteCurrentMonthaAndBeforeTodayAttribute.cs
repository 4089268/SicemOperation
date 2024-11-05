using System;
using System.ComponentModel.DataAnnotations;

namespace SicemOperation.Data.Validations;

public class DeteCurrentMonthaAndBeforeTodayAttribute : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime fecha)
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);

            // Check if the date is in the current month and before today
            if (fecha >= firstOfMonth && fecha <= today)
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult("La fecha debe estar dentro del mes actual y debe ser anterior u hoy.");
            }
        }

        return new ValidationResult("Fecha no válida.");
    }
}