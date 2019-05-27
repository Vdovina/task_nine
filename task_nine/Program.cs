using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_nine
{
    class Program
    {
        static void Main(string[] args)
        {
            BiList list = new BiList();
            int option = 0;
            do
            {
                Console.WriteLine(@"
1. Заполнить список.
2. Добавить элемент.
3. Удалить элемент.
4. Найти.
5. Очистить список.");
                option = MenuOption();
                switch (option)
                {
                    case 1: // заполнить
                        Console.Write("Введите количество элементов в списке:   ");
                        int size = 0;
                        bool ok = false;
                        while (!ok)
                        {
                            size = EnterANumber();
                            if (size > 0) ok = true;
                            else Console.WriteLine("Введите натуральное число!");
                        }
                        list = new BiList(size);
                        Show(list);
                        break;
                    case 2: // добавить
                        Console.Write("Введите добавляемый элемент:   ");
                        list.Add(EnterANumber());
                        Show(list);
                        break;
                    case 3: // удалить
                        if (list.IsEmpty) Console.WriteLine("Список пуст!");
                        else
                        {
                            Console.Write("Введите элемент, который желаете удалить:   ");
                            int deleted = list.Remove(EnterANumber());
                            if (deleted == 0) Console.WriteLine("Элемент не был найден.");
                            else Show(list);
                        }
                        break;
                    case 4: // найти
                        if (list.IsEmpty) Console.WriteLine("Список пуст!");
                        else
                        {
                            Console.Write("Введите искомый элемент:   ");
                            int searched = EnterANumber();
                            var s = list.Search(searched);
                            if (s == -1) Console.WriteLine("Элемент не был найден.");
                            else Console.WriteLine("Номер искомого элемента:   " + (s+1));
                        }
                        break;
                    case 5: // очистить
                        list.Clear();
                        if (list.IsEmpty) Console.WriteLine("Список пуст!");
                        break;
                }
            } while (option <= 5);
        }

        public static int EnterANumber() //ввод a number
        {
            bool ok = false;
            int number = 0;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число!");
                }
            } while (!ok);
            return number;
        }


        public static int MenuOption()
        {
            int option = 0;
            bool alright = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Пункт:    ");
                Console.ResetColor();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option < 1 || option > 5) Console.WriteLine("Error!");
                    else alright = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error!");
                    alright = false;
                }
            } while (!alright);

            return option;
        }


        public static void Show(BiList list)
        {
            foreach (int element in list)
            {
                Console.Write(element + "\t");
            }
        }
    }
}
