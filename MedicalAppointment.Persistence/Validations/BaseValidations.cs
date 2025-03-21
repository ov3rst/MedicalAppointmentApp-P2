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

        public static OperationResult ValidateString(string str, int length = int.MaxValue, bool allowedToBeEmpty = false)
        {
            OperationResult result = new();

            if (!allowedToBeEmpty) result = ValidateEmptyString(str);

            if (!result.Success || allowedToBeEmpty && string.IsNullOrEmpty(str)) return result;

            result = ValidateLength(str, length);

            if (result.Success && Regex.IsMatch(str, @"[\d]"))
            {
                result.Success = false;
                result.Message = "Esta propiedad no debe contener numeros";
            }

            return result;
        }

        public static OperationResult ValidateOnlyLetterAndNumber(string str, int length = int.MaxValue, bool allowedToBeEmpty = false)
        {
            OperationResult result = ValidateLength(str, length);
            if (!result.Success || allowedToBeEmpty && string.IsNullOrEmpty(str)) return result;

            if (!Regex.IsMatch(str, @"^[a-zA-Z0-9 ]+$"))
            {
                result.Success = false;
                result.Message = "La dirección es invalida";
            }

            return result;
        }

        public static OperationResult ValidateUrl(string str, bool allowedToBeEmpty = false)
        {
            OperationResult result = new();
            if (allowedToBeEmpty && string.IsNullOrEmpty(str)) return result;

            if (!Regex.IsMatch(str, @"^(https?:\/\/)?([\w\-]+(\.[\w\-]+)+)(\/[\w\-._~:/?#[\]@!$&'()*+,;=]*)?$"))
            {
                result.Success = false;
                result.Message = "La URL es invalida";
            }

            return result;
        }

        private static OperationResult ValidateEmptyString(string str)
        {
            OperationResult result = new();

            if (string.IsNullOrEmpty(str))
            {
                result.Success = false;
                result.Message = "Esta propiedad no puede estar vacia";
            }

            return result;
        }

        public static OperationResult ValidateEmail(string str)
        {
            OperationResult result = new();

            if (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                result.Success = false;
                result.Message = "El email es invalido";
            }

            return result;
        }

        public static OperationResult ValidateId(int id, string name = "id", bool allowedToBeEmpty = false)
        {
            OperationResult result = new OperationResult();
            if (allowedToBeEmpty) return result;

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

            if (!Regex.IsMatch(num.ToString(), @"[A-Za-zñÑàèìòùÀÈÌÒÙ]"))
            {
                result.Success = false;
                result.Message = "Esta propiedad no debe contener numeros";
            }

            return result;
        }

        public static OperationResult ValidatePhone(string str, bool allowedToBeEmpty = false)
        {
            OperationResult result = new();
            if (allowedToBeEmpty && string.IsNullOrEmpty(str)) return result;

            if (!Regex.IsMatch(str, @"^(809|829|849)-\d{3}-\d{4}$"))
            {
                result.Success = false;
                result.Message = "El número de teléfono es invalido";
            }

            return result;
        }

        public static OperationResult ValidateDate(DateTime date)
        {
            OperationResult result = new();

            if (date <= DateTime.Now)
            {
                result.Success = false;
                result.Message = "La fecha ingresada es invalida";
            }

            return result;
        }

        public static OperationResult ValidateTime(TimeOnly time)
        {
            OperationResult result = new();

            if (time <= TimeOnly.FromDateTime(DateTime.Now))
            {
                result.Success = false;
                result.Message = "La hora ingresada es invalida";
            }

            return result;
        }

        public static DateTime ToDateTime(DateOnly dateOnly) => new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);

        private static OperationResult ValidateLength(string str, int length)
        {
            OperationResult result = new();
            if (str.Length > length)
            {
                result.Success = false;
                result.Message = "El limite de carácteres es mayor al permitido";
            }

            return result;
        }

        public static OperationResult ValidateDecimal(decimal? num, bool allowedToBeEmpty = false)
        {
            OperationResult result = new();
            if (allowedToBeEmpty && num is 0 || num is null) return result;

            if (Regex.IsMatch(num.ToString()!, @"^\d{8}(\.\d{1,2})?$"))
            {
                result.Success = false;
                result.Message = "El numero de telefono es invalido";
            }

            return result;
        }

        private static bool IsNullable<T>(T prop) => Nullable.GetUnderlyingType(typeof(T)) is not null;
    }
}
