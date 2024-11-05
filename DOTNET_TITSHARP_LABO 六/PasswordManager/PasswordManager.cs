using System;
using System.Collections.Generic;
using DOTNET_TITSHARP_LABO_六.Crypto;

namespace DOTNET_TITSHARP_LABO_六.PasswordManager
{
    public class PasswordManager
    {
        private List<PasswordRecord> records = new List<PasswordRecord>();

        public void AddRecord(string label, string password)
        {
            var encryptedPassword = EncryptionManager.Encrypt(password);
            records.Add(new PasswordRecord(label, encryptedPassword));
            Console.WriteLine("Пароль успешно добавлен.");
        }

        public void DeleteRecord(string label)
        {
            var record = records.Find(r => r.Label == label);
            if (record != null)
            {
                records.Remove(record);
                Console.WriteLine("Запись удалена.");
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
                var decryptedPassword = EncryptionManager.Decrypt(record.EncryptedPassword);
                Console.WriteLine($"Метка: {record.Label}, Пароль: {decryptedPassword}");
            }
        }
    }



}


