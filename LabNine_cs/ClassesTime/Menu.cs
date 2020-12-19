using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Time
{
    public class Menu
    {
        private Time[] forOperations = new Time[2];
        private TimeArray timeArray;
        private int mainChoice = 0, exitInSixAndSevenIndexMenu = 0;
        private int one = 0; int two = 1;

        public int MenuForTime()
        {
            Console.WriteLine("\t\t\t\t\tКласс Time");
            try
            {
                exitInSixAndSevenIndexMenu = 0;
                Console.WriteLine(@"Выберите индекс действия:
1.  Создать объекты типа Time для демонстрации работы перегруженных операторов и методов;
2.  Оператоs +-;
3.  Инкремент и декремент;
4.  Добавление минут к объекту через статический метод и через объект класса;
5.  Вывод объектов типа Time;
6.  Конструктор с параметрами типа TimeArray(добавление случайных значений);
7.  Конструктор с параметрами типа TimeArray(добавление значений введенных с клавиатуры);
8.  Поиск среднего-арифметического типа Time;
9.  Вывод коллекции;
10. Выход.");
                mainChoice = int.Parse(Console.ReadLine());
                switch (mainChoice)
                {
                    case 1: MenuIndexOne();
                        break;
                    case 2: MenuIndexTwo();
                        break;
                    case 3: MenuIndexThree();
                        break;
                    case 4: MenuIndexFour();
                        break;
                    case 5: 
                        for (int i = 0; i < forOperations.Length; i++)
                        {
                            if (forOperations[i] != null)
                                Time.WriteTime(forOperations[i]);
                            else
                            {
                                Console.WriteLine("\nОбъекты пусты.\n");
                                break;
                            }
                        }
                                
                        break;
                    case 6: MenuIndexSix();
                        break;
                    case 7: MenuIndexSeven();
                        break;
                    case 8:
                        if (timeArray != null)
                        TimeArray.AverageArithmetic(timeArray);
                        else
                            Console.WriteLine("\nДля начала создайте коллекцию.\n");
                        break;
                    case 9:
                        if (timeArray != null)
                            timeArray.WriteTimeArray();
                        else
                            Console.WriteLine("\nКоллекция пуста.\n");
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("\nНет действий под данным индексом, повторите ввод...\n");
                        break;
                }
            }
            catch(FormatException fex)
            {
                Console.WriteLine($"{fex.Message}");
            }
            catch(OverflowException ofx)
            {
                Console.WriteLine($"\n{ofx.Message}");
            }

            if (mainChoice == 10)
                return 0;

            return MenuForTime();
        }

        private void MenuIndexOne()
        {
            for (int i = 0; i < forOperations.Length; i++)
            {
                try
                {
                    Console.Write($"Количество минут в {i + 1}-м объекта: ");
                    int minutes = int.Parse(Console.ReadLine());
                    for (int j = 0; j < 1; j++)
                    {
                        try
                        {
                            Console.Write($"Количество часов в {i + 1}-м объекта: ");
                            int hours = int.Parse(Console.ReadLine());
                            forOperations[i] = new Time(minutes, hours);
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine(fex.Message);
                            j -= 1;
                        }
                        catch (OverflowException ofx)
                        {
                            Console.WriteLine(ofx.Message);
                            j -= 1;
                        }
                    }

                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                    i -= 1;
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                    i -= 1;
                }
            }
            Console.WriteLine("\nСозданны два объекта типа Time\n");
            for (int i = 0; i < forOperations.Length; i++)
            {
                Console.WriteLine($"{i + 1}-й:");
                Time.WriteTime(forOperations[i]);
            }
        }
        
        private void MenuIndexTwo()
        {
            if (forOperations[one] != null && forOperations[two] != null)
            {
                int choice;
                do
                {
                    try
                    {
                        Console.WriteLine("\nВыберите индекс оператора\n1.) Оператор +;\n2.) Оператор -;\n3.) Назад..");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            ChoiceOperandsPlus();
                        }
                        else if (choice == 2)
                        {
                            ChoiceOperandsMinus();
                        }
                        else if (choice == 3)
                            break;
                        else
                            Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine(fex.Message);
                    }
                    catch (OverflowException ofx)
                    {
                        Console.WriteLine(ofx.Message);
                    }
                } while (true);
            }
            else
                Console.WriteLine("\nДля начала создайте объекты.\n");
        }
        private void ChoiceOperandsPlus()
        {
            for (int i = 0; i < forOperations.Length - 1; i++)
            {
                try
                {
                    Console.WriteLine("\nВыберите\n1.) Прибавить к левостороннему операнду;\n2.) Прибавить к правостороннему операнду;\n3.) Назад..");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                        Time.WriteTime(forOperations[i] += forOperations[i + 1]);
                    else if (choice == 2)
                        Time.WriteTime(forOperations[i + 1] += forOperations[i]);
                    else if (choice == 3)
                        break;
                    else
                        Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                    i -= 1;
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                    i -= 1;
                }
            }
        }
        private void ChoiceOperandsMinus()
        {
            for (int i = 0; i < forOperations.Length - 1; i++)
            {
                try
                {
                    Console.WriteLine("\nВыберите\n1.) Отнять от левостороннего операнда;\n2.) Отнять от правостороннего операнда;\n3.) Назад..");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                        Time.WriteTime(forOperations[i] -= forOperations[i + 1]);
                    else if (choice == 2)
                        Time.WriteTime(forOperations[i + 1] -= forOperations[i]);
                    else if (choice == 3)
                        break;
                    else
                        Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                    i -= 1;
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                    i -= 1;
                }
            }
        }

        private void MenuIndexThree()
        {
            if (forOperations[one] != null && forOperations[two] != null)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nВыбериете\n1.) Инкремент или декремент к левому операнду; 2.) Инкермент или декремент к правому операнду;\n3.) Назад..");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                            LeftOrRightInkrementOrDekrement();
                        else if (choice == 2)
                            LeftOrRightInkrementOrDekrement(1);
                        else if (choice == 3)
                            break;
                        else
                            Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine(fex.Message);
                    }
                    catch (OverflowException ofx)
                    {
                        Console.WriteLine(ofx.Message);
                    }
                } while (true);
            }
            else
                Console.WriteLine("\nДля начала создайте объекты.\n");
        }
        private void LeftOrRightInkrementOrDekrement(int i = 0)
        {
            do
            {
                try
                {
                    Console.WriteLine("\nВыбор\n1.) Инкремент;\n2.) Декремент;\n3.) Назад..");
                    int choiceLeftOperand = int.Parse(Console.ReadLine());
                    if (choiceLeftOperand == 1)
                    {
                        forOperations[i]++;
                        Time.WriteTime(forOperations[i]);
                    }
                    else if (choiceLeftOperand == 2)
                    {
                        forOperations[i]--;
                        Time.WriteTime(forOperations[i]);
                    }
                    else if (choiceLeftOperand == 3)
                        break;
                    else
                        Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                }
            } while (true);
        }
        
        private void MenuIndexFour()
        {
            if (forOperations[one] != null && forOperations[two] != null)
            {
                int i = 0;
                int j = 1;
                do
                {
                    try
                    {
                        Console.WriteLine("\nВыберите\n1.) Прибавить минуты к левому операнду;\n2.) Прибавить минуты к правому операнду;\n3.) Назад..");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                            AppMin(forOperations[i]);
                        else if (choice == 2)
                            AppMin(forOperations[j]);
                        else if (choice == 3)
                            break;
                        else
                            Console.WriteLine("\nНет действия под данным индексом, повторите ввод...");
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine(fex.Message);
                    }
                    catch (OverflowException ofx)
                    {
                        Console.WriteLine(ofx.Message);
                    }
                } while (true);
            }
            else
                Console.WriteLine("\nДля начала создайте объекты.\n");
        }
        private void AppMin(Time leftOrRight)
        {
            do
            {
                try
                {
                    Console.Write("\nСколько минут добавить к объекту: ");
                    int minutes = int.Parse(Console.ReadLine());
                    Time.AppendMinutes(leftOrRight, minutes);
                    Time.WriteTime(leftOrRight);
                    Console.WriteLine("\nВведите 1, если достаточно, либо любую другую цифру, если нет..");
                    int yesOrNo = int.Parse(Console.ReadLine());
                    if (yesOrNo == 1)
                        break;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                }
            } while (true);
        }

        private void MenuIndexSix()
        {
            int from, to;
            do
            {
                try
                {
                    Console.Write("\nВведите количество элементов в массиве типа Time: ");
                    int size = int.Parse(Console.ReadLine());
                    Console.Write("\nВведите диапазон случайных чисел\n");
                    while (true)
                    {
                        try
                        {
                            Console.Write("\nОт: ");
                            from = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine(fex.Message);
                        }
                        catch (OverflowException ofx)
                        {
                            Console.WriteLine(ofx.Message);
                        }
                    }
                    while (true)
                    {
                        try
                        {
                            Console.Write("\nДо: ");
                            to = int.Parse(Console.ReadLine());
                            if (to < from)
                               throw new Exception("\nЗначение MaxValue не может быть меньше значения MinValue.\n");
                                break;
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine(fex.Message);
                        }
                        catch (OverflowException ofx)
                        {
                            Console.WriteLine(ofx.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    timeArray = new TimeArray(from, to, size);
                    ChoiceForMenuIndexSixAndSeven();
                    if (exitInSixAndSevenIndexMenu == 1)
                        break;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
        private void ChoiceForMenuIndexSixAndSeven()
        {
            do
            {
                try
                {
                    timeArray.WriteTimeArray();
                    Console.WriteLine("\n1.) Создать новую коллекцию;\n2.) Назад в меню..\n");
                    int oneOrTwo = int.Parse(Console.ReadLine());
                    if (oneOrTwo == 1)
                        break;
                    else if (oneOrTwo == 2)
                    {
                        exitInSixAndSevenIndexMenu = 1;
                        break;
                    }
                    else
                        Console.WriteLine("\nНет действий под данным индексом..");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                }
            } while (true);
        }

        private void MenuIndexSeven()
        {
            do
            {
                try
                {
                    Console.Write("\nВведите количество элементов в массиве типа Time: ");
                    int size = int.Parse(Console.ReadLine());
                    timeArray = new TimeArray(size);
                    ChoiceForMenuIndexSixAndSeven();
                    if (exitInSixAndSevenIndexMenu == 1)
                    break;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
                catch (OverflowException ofx)
                {
                    Console.WriteLine(ofx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
    }
}
