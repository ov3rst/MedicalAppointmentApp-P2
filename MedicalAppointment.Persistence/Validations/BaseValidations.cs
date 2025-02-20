using MedicalAppointment.Domain.Base;
using System.Text.RegularExpressions;

namespace MedicalAppointment.Persistence.Validations
{
    public abstract class BaseValidations
    {
        public static OperationResult ValidateEntity<TEntity>(TEntity entity)
        {
            OperationResult result = new OperationResult();

            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula";
            }
            return result;
        }

        public static OperationResult ValidateString(string str)
        {
            OperationResult result = new();

            if (Regex.IsMatch(str, @"[\d]"))
            {
                result.Success = false;
                result.Message = "Esta propiedad no debe contener numeros";
            }

            return result;
        }

        public static OperationResult ValidateEmail(string str)
        {
            OperationResult result = new OperationResult();
            if (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                result.Success = false;
                result.Message = "El email es invalido";
            }

            return result;
        }

        public static OperationResult ValidateId(int id, string name = "id")
        {
            OperationResult result = new OperationResult();
            if (id <= 0)
            {
                result.Success = false;
                result.Message = $"El {name} es invalido";
            }

            return result;
        }

        public static OperationResult ValidateNumber(int num)
        {
            OperationResult result = new();

            if (Regex.IsMatch(num.ToString(), @"[A-Za-zñÑàèìòùÀÈÌÒÙ]"))
            {
                result.Success = false;
                result.Message = "Esta propiedad no debe contener numeros";
            }

            return result;
        }

        public static OperationResult ValidatePhone(string str)
        {
            OperationResult result = new();

            if (Regex.IsMatch(str, @"^(809|829|849)-\d{3}-\d{4}$"))
            {
                result.Success = false;
                result.Message = "El numero de telefono es invalido";
            }

            return result;
        }

        public static OperationResult ValidateDate(DateTime date)
        {
            OperationResult result = new OperationResult();

            if (date <= DateTime.Now)
            {
                result.Success = false;
                result.Message = "La fecha ingresada es invalida";
            }

            return result;
        }
    }
}
