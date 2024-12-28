using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            ShowMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Ugadau.PlayGame();
                    break;
                case "2":
                    ShowAuthorInfo();
                    break;
                case "3":
                    int n;
                    
                    bool flag = true;
                    Console.Clear();
                    Console.WriteLine("Введите размер массива : ");
                    while (flag)
                    {
                        
                        string temp = Console.ReadLine();
                        if (int.TryParse(temp, out n))
                        {
                            Sort c3 = new Sort(n);
                            c3.FillArray();
                            c3.SortArray();
                            break;

                        }
                        
                        else
                        {
                            Console.WriteLine("Введите размер массива : ");

                            flag = false; 
                        }
                        flag = true;
                    }
                    
                    break;
                case "4":
                    PlaySnake.PlaySnakeGame();
                    break;
                case "5":
                    exitProgram = ConfirmExit();
                    break;
                default:
                    Console.WriteLine("Неверный ввод! Выберете один из вариантов: ");
                    break;
            }
        }
    }

    static void ShowMainMenu()
    {
        
        Console.WriteLine("1. Игра угадайка");
        Console.WriteLine("2. Создатель программы");
        Console.WriteLine("3. Сортировка массива");
        Console.WriteLine("4. Игра");
        Console.WriteLine("5. Выход");
        Console.Write("Чего вы хотите? (1/2/3/4/5): ");
        
    }

    

    static void ShowAuthorInfo()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("\nОб авторе:");
        Console.WriteLine("Канунников Ярослав Дмитриевич");
        Console.WriteLine("Дата рождения: 02.05.2006 (18 лет)");
        Console.WriteLine("Самарский университет, направление ИВТ");
        Console.WriteLine("№ Группы: 6101-090301D\n");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Нажмите любую кнопку, чтобы выйти в меню. ");
        Console.ReadKey();
    }
    static bool ConfirmExit()
    {
        bool exitConfirmed = false;
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine("Вы уверены, что хотите выйти? (д/н): ");
            string exitProgram = Console.ReadLine();
            valid = exitProgram.ToLower() == "д" || exitProgram.ToLower() == "н";

            if (valid)
            {
                exitConfirmed = exitProgram.ToLower() == "д";
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите 'д' или 'н'.");
            }
        }

        return exitConfirmed;

    }

}

