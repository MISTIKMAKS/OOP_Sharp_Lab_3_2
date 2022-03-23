using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    class Program
    {
        struct Note
        {
            public string last_name;
            public string name;
            public string telephone;
            public int day;
            public int month;
            public int year;
        };

        static void Create(Note[] n, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Person № {i + 1} :");
                Console.Write(" Name : ");
                n[i].name = Console.ReadLine();
                Console.Write(" Last Name : ");
                n[i].last_name = Console.ReadLine();
                Console.Write(" Telephone : ");
                n[i].telephone = Console.ReadLine();
                Console.Write(" Birthday Day : ");
                n[i].day = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Birthday Month : ");
                n[i].month = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Birthday Year : ");
                n[i].year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
            }
        }
        static void Print(Note[] n, int N)
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine("| № | Name | Last Name | Telephone | Day | Month | Year |");
            Console.WriteLine("-----------------------------------------------------------------------------");
            for (int i = 0; i < N; i++) {
                Console.WriteLine($"|{i+1,3}|{n[i].name,6}|{n[i].last_name,11}|{n[i].telephone,11}|{n[i].day,5}|{n[i].month,7}|{n[i].year,6}|");
            }
            Console.WriteLine("=============================================================================");
            Console.WriteLine("");
        }
        static void Menu(Note[] n, int N)
        {
            int choice;
            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please make your selection");
                Console.WriteLine("1 - Sort");
                Console.WriteLine("2 - Search");
                Console.WriteLine("3 - Quit");
                Console.WriteLine("--------------------------");
                Console.Write("Selection: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You Chosen 1 - Sort:");
                        Sort(n, N);
                        Print(n, N);
                        break;
                    case 2:
                        Console.WriteLine("You Chosen 2 - Binary Search:");
                        string btelephone;
                        int found;
                        Console.WriteLine("Enter Keys For Search:");
                        Console.Write(" Telephone: ");
                        btelephone = Console.ReadLine();
                        if ((found = Search(n, N, btelephone)) != -1)
                        {
                           Console.WriteLine($"Student Found On Position: {found + 1}");
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Goodbye! See Ya Later, Aligator!!!");
                        break;
                    default:
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Main Menu");
                        Console.WriteLine("Please make your selection");
                        Console.WriteLine("1 - Sort");
                        Console.WriteLine("2 - Search");
                        Console.WriteLine("3 - Quit");
                        Console.WriteLine("--------------------------");
                        Console.Write("Selection: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            } while (choice != 3);
        }
        static void Sort(Note[] n, int N)
        {
            Note tmp;
            for (int i0 = 0; i0 < N - 1; i0++) {
                for (int i1 = 0; i1 < N - i0 - 1; i1++) {
                    if (n[i1].year < n[i1 + 1].year) {
                        tmp = n[i1];
                        n[i1] = n[i1 + 1];
                        n[i1 + 1] = tmp;
                    }
                    else if (n[i1].year == n[i1 + 1].year)
                    {
                        if (n[i1].month < n[i1 + 1].month) {
                            tmp = n[i1];
                            n[i1] = n[i1 + 1];
                            n[i1 + 1] = tmp;
                        }
                        else if (n[i1].month == n[i1 + 1].month)
                        {
                            if (n[i1].day < n[i1 + 1].day) {
                                tmp = n[i1];
                                n[i1] = n[i1 + 1];
                                n[i1 + 1] = tmp;
                            }
                        }
                    }
                }
            }
        }
        static int Search(Note[] n, int N, string btelephone)
        {
            for (int i = 1; i <= N; i++)
            {
                if(n[i].telephone == btelephone)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int N;
            Console.Write("Insert N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Note[] n = new Note[N];

            Create(n, N);
            Print(n, N);
            Menu(n, N);
            Console.ReadKey();
        }
    }
}
