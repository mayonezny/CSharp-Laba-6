using System;
using System.Collections.Generic;
using DOTNET_TITSHARP_LABO_六.Crypto;

namespace DOTNET_TITSHARP_LABO_六.Passwords
{
    public class PasswordManager
    {
        private List<PasswordRecord> records = new List<PasswordRecord>();

        public void AddRecord(string label, string password)
        {   
            if (Verifier.VerifyPassword(password))
            {
                var encryptedPassword = EncryptionManager.Encrypt(password);
                records.Add(new PasswordRecord(label, encryptedPassword));
                Console.WriteLine("Пароль успешно добавлен.");
            }
            else
            {
                Console.WriteLine("Ошибка! Пароль не удовлетворяет условиям!");
            }
            
        }

        public void DeleteRecord(string label)
        {
            var record = records.Find(r => r.Label == label);
            if (record != null)
            {
                var decryptedPassword = EncryptionManager.Decrypt(record.EncryptedPassword);
                Console.WriteLine("Введите пароль, чтобы удалить запись, нажмите 1 чтобы выйти в главное меню");
                while (true)
                {
                    string input = Console.ReadLine();

                    if(input == decryptedPassword)
                    {
                        records.Remove(record);
                        Console.WriteLine("Запись удалена.");
                        break;
                    }
                    else if(input == "1")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль!");
                    }
                    
                }
                
            }
            else
            {
                Console.WriteLine("Запись не найдена.");
            }
        }

        public void DisplayRecords()
        {
            foreach (var record in records)
            {
                Console.WriteLine($"Метка: {record.Label}, Пароль: {record.EncryptedPassword}");
            }
        }
    }



}


