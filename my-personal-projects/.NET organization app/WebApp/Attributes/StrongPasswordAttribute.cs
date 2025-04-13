using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class StrongPasswordAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var password = value as string;

        if (string.IsNullOrEmpty(password))
            return false;

        return password.Length >= 6
            && Regex.IsMatch(password, @"[A-Z]")    // at least 1 uppercase character
            && Regex.IsMatch(password, @"[0-9]");   // at least one digit digit
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be at least 6 characters long, contain one uppercase letter and one number.";
    }
}
