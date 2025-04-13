using System.ComponentModel.DataAnnotations;

namespace WebApp.Attributes
{
    public class YearAttribute : ValidationAttribute
    {
        private readonly int min;
        private readonly int max;

        public YearAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} nije u opsegu!";
        }
        public override bool IsValid(object? value)
        {
            return value is int year && year > min && year < max;
        }
    }
}
