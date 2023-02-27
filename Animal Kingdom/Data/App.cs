using Animal_Kingdom.Data;

namespace Animal_Kingdom.Data
{


    internal class App
    {
        Shelter shelter = new Shelter();
        internal void Run()
        {
            Console.WriteLine("Welcome to Animal Kingdom!");
            shelter.Menu();
        }
       



    }
}