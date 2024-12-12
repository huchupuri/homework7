using System;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

//        Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
//метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
//на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        static void Task1()
        {
            Console.WriteLine("задание 1");

            List<BankAccount> accounts = new List<BankAccount>()
            {
                new BankAccount(1000, AccountType.debit),
                new BankAccount(2000, AccountType.debit),
                new BankAccount(3000, AccountType.debit)
            };

            foreach (BankAccount account in accounts) 
            {
                account.PrintAccountInfo();
            }

            int idSender, idReceiver;
            decimal amount;
            bool flagSender,flagReceiver, flagAmount;
            do
            {
                Console.Write("с какого счета (id) совершить перевод: ");
                flagSender = int.TryParse(Console.ReadLine(), out idSender);
                Console.Write("напишите кореектный id ползователя, которому хотите перевести деньги: ");
                flagReceiver = int.TryParse(Console.ReadLine(), out idReceiver);
                Console.Write("напишите сумму перевода: ");
                flagAmount = decimal.TryParse(Console.ReadLine(), out amount);
            }
            while (!(flagSender && flagReceiver && flagAmount && idSender >= 0
            && idSender <= accounts.Count() && idReceiver <= accounts.Count() && idReceiver > 0 && amount > 0));

            //проверкка на возможность перевода
            Console.WriteLine(accounts[idReceiver - 1].Transfer(accounts[idSender - 1], amount) ? "перевод выполнен" : "недостаточно средств");
            
            //вывод информации после перевода
            foreach (BankAccount account in accounts) account.PrintAccountInfo();   
        }
        static void Task2()
        {
            Console.WriteLine("\nзадание 2\n");

            Console.Write("введите строку: ");

            Console.WriteLine(ReverseString(Console.ReadLine()));
        }

        static void Task3()
        {
            Console.WriteLine("\nзадание 3\n");
            Console.Write("введите название файла: ");
            string fileName = Console.ReadLine();
            if (File.Exists($"Resource1\\{fileName}.txt"))
            {
                string content = File.ReadAllText($"Resource1\\{fileName}.txt");
                string upperContent = content.ToUpper();
                string outputFileName = "output.txt";

                File.WriteAllText(outputFileName, upperContent);

                Console.WriteLine($"Содержимое файла записано в '{outputFileName}'");
            }
            else Console.WriteLine("такого файла нет");
        }

//        Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
//метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
//IFormattable обеспечивает функциональные возможности форматирования значения объекта
//в строковое представление.)
        static void Task4()
        {
            Console.WriteLine("\nзадание 4\n");
            object value1 = 123.45; 
            object value2 = "Hello";
            object value3 = true;

            Console.WriteLine("проверка с is:");
            CheckFormattableWithIs(value1);
            CheckFormattableWithIs(value2);
            CheckFormattableWithIs(value3);

            Console.WriteLine("проверка с as:");
            CheckFormattableWithAs(value1);
            CheckFormattableWithAs(value2);
            CheckFormattableWithAs(value3);
        }

//        Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail
//адрес.Разделителем между ФИО и адресом электронной почты является символ #:
        static void Task5()
        {
            Console.WriteLine("\nзадание 5\n");
            Console.Write("Введите имя входного файла (users): ");
            string fileName = Console.ReadLine();

            if (!File.Exists($"Resource1\\{fileName}.txt"))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }

            string outputFileName = "emails.txt";

            try
            {
                string[] lines = File.ReadAllLines($"Resource1\\{fileName}.txt");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach (string line in lines)
                    {
                        string email = line;
                        SearchMail(ref email);
                        if (!string.IsNullOrEmpty(email))
                        {
                            writer.WriteLine(email);
                        }
                    }
                }

                Console.WriteLine($"Список адресов электронной почты сохранён в '{outputFileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

//        8.2 Список песен.В методе Main создать список из четырех песен.В
//цикле вывести информацию о каждой песне.Сравнить между собой первую и вторую
//песню в списке.Песня представляет собой класс с методами для заполнения каждого из
//полей, методом вывода данных о песне на печать, методом, который сравнивает между
//собой два объекта:
        static void Task6()
        {

            Console.WriteLine("\nзадание 6");
            List<Song> songs = new List<Song>
            {
                new Song ( "я устал", "1.Klas$" ),
                new Song ( "Much better", "Dainty" ),
                new Song ( "Cirilla.Gif", "Love God Beer Trap" ),
                new Song ( "Imagine", "John Lennon" ),
            };

            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].SetPrev(songs[i - 1]);
            }

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs[1].Equals(songs[0].prev))
            {
                Console.WriteLine("Первая и вторая песни одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }

        /// <summary>
        /// поиск почты
        /// </summary>
        static void SearchMail(ref string data)
        {
            data = data.Split(" # ")[^1];
        }


        /// <summary>
        /// проверка на IFormattable с is
        /// </summary>
        public static void CheckFormattableWithIs(object obj)
        {
            Console.WriteLine(obj is IFormattable ? 
                $"Объект типа {obj.GetType()} реализует интерфейс IFormattable." 
                : $"Объект типа {obj.GetType()} не реализует интерфейс IFormattable.");
        }

        /// <summary>
        /// проверка на IFormattable с as
        /// </summary>
        public static void CheckFormattableWithAs(object obj)
        {
            IFormattable formattable = obj as IFormattable;
            Console.WriteLine(formattable != null ?
                $"Объект типа {obj.GetType()} реализует интерфейс IFormattable."
                : $"Объект типа {obj.GetType()} не реализует интерфейс IFormattable.");
        }


        /// <summary>
        /// инвертирование строки
        /// </summary>
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}