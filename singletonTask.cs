using System;

/*
 Много добре знаем от практиката, че когато искаме да свържем нашето приложение
към База от данни, се отваря така наречената Connection(връзка), която седи отворена
докато не се изпълнят дадените подадени заявки, след което бива затворена същата дадена
връзка към дадената БД. Използвайки шаблона Singleton напишете програма, която да създава само ЕДНА инстанция
от клас Database, който трябва да има функционалност за отваряне и затваряне на връзката, също и за изпълняване на SQL заявки (под формата на стрингове).
В Main метода намерете начин да проверите дали сте използвали шаблона правилно.
 */

namespace Singleton
{
    //Класа База от данни, който трябва да бъде инстанциран само веднъж
    public  class Database
    {
        private static Database _instance;
        private static bool isConnectionOpen;

        //private конструктор за да не се създава извън класа
        private Database() { }

        //Създаването става само чрез този метод
        //Който проверява ако вече е създадена само я връща
        public static Database GetInstance()
        {
            
            if (_instance == null)
            {
                openConnection();
                isConnectionOpen = true;
                _instance = new Database();
            }
            return _instance;
        }

        public void execute(string query)
        {
            Console.WriteLine("Изпълняване на заявка: " + query);
        }

        public static void openConnection()
        { 
            Console.WriteLine(
                 (isConnectionOpen) ?
                 "Връзката е вече отворена." :
                 "Отваряне на връзка към БД."
                );
        }
        
        public void closeConnection()
        {
            Console.WriteLine(
                isConnectionOpen ?
                "Затваряне на връзка към БД." :
                "Връзката не е отворена."
                );
           
            isConnectionOpen = false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
         
            Database s1 = Database.GetInstance();
            Database s2 = Database.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton шаблона работи, и двете променливи съдържат едина й съща инстанция.");

                s1.execute("Select * from employees");
                s2.execute("Select * from clients");

                s1.closeConnection();
            }
            else
            {
                Console.WriteLine("Singleton шаблона не е успешен, променливите съдържат различни инстанции.");
            }
        }
    }
}