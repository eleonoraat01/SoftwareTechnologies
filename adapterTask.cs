using System;

/*
  Като използвате шаблона за дизайн Adapter направете клас Bird (Птица), чиито обекти
  трябва да имат функционалност за fly(летене) и makeSound(правене на звук). Също така
  създайте клас ToyDuck(Пате играчка), чиито обекти трябва да има функционалност за squeak(цвърчене)
  Да приемем, че не ви достигат обекти ToyDuck и бихте искали да използвате обекти Bird на тяхно място.
  Птиците имат подобна функционалност, но имплементират различен интерфейс, така че не можем да ги използваме директно.
  Така че използвайте модел на адаптер. Нашият клиент да бъде ToyDuck, а адаптираният ще бъде Bird.
 */

namespace Adapter
{
    //Интерфейс, чиито функционалности ще бъдат имплементирани от Конкретен клас 1
    interface Bird
    {
        void fly();
        void makeSound();
    }

    //Конкретен клас 1
    class Sparrow : Bird
    {
        public void fly()
        {
            Console.WriteLine("Летене");
        }

        public void makeSound()
        {
            Console.WriteLine("Цвър цвър");
        }
    }

    //Интерфейс, чиито функционалности ще бъдат имплементирани от Конкретен клас 2
    interface ToyDuck
    {
        void squeak();
    }

    //Конкретен клас 2
    class PlasticToyDuck : ToyDuck
    {
        public void squeak()
        {
            Console.WriteLine("Квак квак");
        }
    }

    //Класа Адаптер, който ще превърне класа Bird в класа ToyDuck
    class BirdAdapter : ToyDuck
    {
        Bird bird;

        public BirdAdapter(Bird bird)
        {
            this.bird = bird;
        }

        public void squeak()
        {
            bird.makeSound();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sparrow sparrow = new Sparrow();
            ToyDuck toyDuck = new PlasticToyDuck();

            ToyDuck birdAdapter = new BirdAdapter(sparrow);

            Console.WriteLine("Sparrow: ");
            sparrow.fly();
            sparrow.makeSound();

            Console.WriteLine();

            Console.WriteLine("ToyDuck...");
            toyDuck.squeak();

            Console.WriteLine();


            Console.WriteLine("BirdAdapter...");
            birdAdapter.squeak();
        
        }
    }
}