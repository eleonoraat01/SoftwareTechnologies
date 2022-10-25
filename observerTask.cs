using System;

/*
 Използвайки шаблона Observer напишете програма, която да приема едно число
 и да изписва на екрана числото в Двочна, Осмична и Шестнадесетична бройна система.
 В Main метода напишете поне 3 числа и изпишете техните стойности в 
 Двочна, Осмична и Шестнадесетична бройна система.
*/

namespace Observer
{
    //Конкретния клас , който ще бъде променян
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;
        public int State {
            get { return state;  } 
            set { state = value; notifyAllObservers(); } 
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }
        }
    }

    //Абстрактен класа, който ще съобщава за промяна
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void update();
    }

    //Конкретен клас за промяна 1
    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Binary String: " + Convert.ToString(subject.State, 2));

        }
    }

    //Конкретен клас за промяна 2
    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Octal String: " + Convert.ToString(subject.State, 8));

        }
    }

    //Конкретен клас за промяна 3
    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("Hexa String: " + subject.State.ToString("X").ToUpper());

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);

            Console.WriteLine(("First state change: 15"));
            subject.State = 15;

            Console.WriteLine();

            Console.WriteLine(("Second state change: 10"));
            subject.State = 10;

            Console.WriteLine();

            Console.WriteLine(("Third state change: 12"));
            subject.State = 12;
        }
    }
}