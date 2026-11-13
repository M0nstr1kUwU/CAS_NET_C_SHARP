using System.Text.RegularExpressions;

namespace ValidationLibrary;

public static class ContactValidator
{
    // ФИО: русские/латинские буквы, пробелы и дефисы.
    public static bool IsFullNameValid(string value) =>
        !string.IsNullOrWhiteSpace(value) &&
        Regex.IsMatch(value.Trim(), @"^[\p{L}]+(?:[ -][\p{L}]+){1,2}$");

    // Возраст: только цифры, допустимый диапазон 0..120.
    public static bool IsAgeValid(string value) =>
        int.TryParse(value, out int age) && age >= 0 && age <= 120 &&
        Regex.IsMatch(value, @"^\d+$");

    // Принятый в этом учебном примере формат: +7 (999) 123-45-67.
    public static bool IsPhoneValid(string value) =>
        Regex.IsMatch(value ?? "", @"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$");

    public static bool IsEmailValid(string value) =>
        !string.IsNullOrWhiteSpace(value) &&
        Regex.IsMatch(value, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
}
