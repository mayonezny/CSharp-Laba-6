using System.Text.RegularExpressions;

namespace DOTNET_TITSHARP_LABO_六.Crypto
{
    public class Verifier
    {
        public static bool VerifyPassword(string input)
        {
            if (input.Length < 8)
            {
                Console.WriteLine("Ошибка: Пароль должен содержать минимум 8 символов.");
                return false;
            }

            if (!Regex.IsMatch(input, @"[A-Z]"))
            {
                Console.WriteLine("Ошибка: Пароль должен содержать как минимум одну заглавную букву.");
                return false;
            }

            Console.WriteLine("Пароль соответствует требованиям.");
            return true;
        }
    }
}
