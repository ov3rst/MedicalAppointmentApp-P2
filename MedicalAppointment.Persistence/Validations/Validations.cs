namespace MedicalAppointment.Persistence.Validations
{
    public static class Validations<TEntity>
    {
        public static bool ValidateEntityNull(TEntity entity) => entity is null;

        public static bool ValidateNumber(int num) => num <= 0;

        public static bool ValidateNumber(short num) => num <= 0;

        public static bool ValidateDate(DateTime date) => date <= DateTime.Now;
    }
}
