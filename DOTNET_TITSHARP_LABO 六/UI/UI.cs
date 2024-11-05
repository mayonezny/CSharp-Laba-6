using System;

namespace DOTNET_TITSHARP_LABO_六.UI
{
    public class UserInterface
    {
        private PasswordManager passwordManager = new PasswordManager();

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Выберите действие: (1) Добавить пароль, (2) Удалить запись, (3) Показать все записи, (4) Выход");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите метку: ");
                        string label = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();
                        passwordManager.AddRecord(label, password);
                        break;

                    case "2":
                        Console.Write("Введите метку записи, которую хотите удалить: ");
                        string deleteLabel = Console.ReadLine();
                        passwordManager.DeleteRecord(deleteLabel);
                        break;

                    case "3":
                        passwordManager.DisplayRecords();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }

}
