using Animal_Kingdom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Animal_Kingdom.Model;

namespace Animal_Kingdom.Data
{
    internal class Shelter
    {
        public List<Animal> Animals;
        private static readonly string filePath = "C:\\Users\\Admin\\source\\repos\\Animal Kingdom\\Animal Kingdom\\Files\\animals.json";
        public static string exportPath = "";

        public Shelter()
        {
            Animals = LoadAnimals();
        }

        private List<Animal>? LoadAnimals()
        {
            var text = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(text))
            {
                return JsonSerializer.Deserialize<List<Animal>>(text);
            }
            else { return new List<Animal>(); }
        }

        internal virtual void WriteToFile()
        {
            var content = JsonSerializer.Serialize(Animals);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
        internal virtual void WriteToFile(List<Animal> content, string userPath)
        {
            var exportList = JsonSerializer.Serialize(content);
            File.WriteAllText(userPath, exportList, Encoding.UTF8);
        }

        public void Menu()
        {
            Console.WriteLine("Make a choice: ");
            Console.WriteLine("1.       Add a new Pet");
            Console.WriteLine("2.       List all Animals in the Shelter");
            Console.WriteLine("3.       List all pets Up for Adoption");
            Console.WriteLine("4.       Create a new List for Export");
            Console.WriteLine("Esc      Exit the Program");
            Console.Write("\n: ");

            while (true)
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        AddAnimal();
                        break;
                    case ConsoleKey.D2:
                        ListAnimals();
                        break;
                    case ConsoleKey.D3:
                        ListSortedAnimals();
                        break;
                    case ConsoleKey.D4:
                        CreateExport();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                }
            }

        }

        private void CreateExport()
        {
            Console.WriteLine("Please enter a export filepath:");
            exportPath = Console.ReadLine();
            var exportList = Animals.Where(e => e.AnimalStatus != AnimalStatusEnum.UnAdoptable).ToList().OrderBy(b => b.Id).ToList();
            WriteToFile(exportList, exportPath);
            Console.WriteLine($"Sorted list of animals that are adoptable has been created at {exportPath}.");
            Menu();
        }

        private void ListSortedAnimals()
        {
            var adoptableAnimals = Animals.Where(e => e.AnimalStatus != AnimalStatusEnum.UnAdoptable || e.AnimalStatus != AnimalStatusEnum.SignedForAdoption).ToList();
            foreach (var item in adoptableAnimals)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.AnimalStatus);
            }
            Menu();
        }

        private void ListAnimals()
        {
            int counter = 1;
            foreach (Animal animal in Animals)
            {
                Console.WriteLine($"{counter} : {animal.Id}:{animal.Name}{animal.AnimalStatus}");
                counter++;
            }
            Menu();
        }

        public void AddAnimal()
        {


            while (true)
            {
                Console.WriteLine("Which type of animal do you wanna add: ");
                Console.WriteLine("1.       Dog");
                Console.WriteLine("2.       Cat");
                Console.WriteLine("3.       Parrot");
                Console.WriteLine("4.       Go back to the Menu");

                Console.Write("\n: ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        AddNew(AnimalTypeEnum.Dog);
                        break;
                    case ConsoleKey.D2:
                        AddNew(AnimalTypeEnum.Cat);
                        break;
                    case ConsoleKey.D3:
                        AddNew(AnimalTypeEnum.Parrot);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Menu();
                        break;


                }
            }
        }

        private void AddNew(AnimalTypeEnum typeOfAnimal)
        {
            Console.WriteLine($"Adding a new {typeOfAnimal} :");
            //get the name
            Console.WriteLine("What is the Pet's name? :");
            var name = Console.ReadLine();
            //get the id
            Console.Write("What is the ID? :");
            var id = Convert.ToInt32(Console.ReadLine());
            //Get the color
            Console.WriteLine("What is the Color?:");
            var color = Console.ReadLine();

            //Create a new Type Object for Gender and Select the Gender
            GenderEnum gender = GetGender();


            //Console.WriteLine("What is the Gender:\n" + 
            //    "1. Male\n" + 
            //    "2. Female\n" + 
            //    "3. Unknown");
            //if (Console.ReadKey().Key == ConsoleKey.D1) gender = GenderEnum.Male;
            //if (Console.ReadKey().Key == ConsoleKey.D2) gender = GenderEnum.Female;
            //if (Console.ReadKey().Key == ConsoleKey.D3) gender = GenderEnum.Unknown;

            //Create a new Type Object for Status and Select the Status
            AnimalStatusEnum status = GetStatus();

            //Console.WriteLine("What is the Animal Status? :\n" + 
            //    "1. Up For Adoption\n" +
            //    "2. Signed for Adoption\n" +
            //    "3. No Child Household\n" +
            //    "4. Un-Adoptable");
            //if (Console.ReadKey().Key == ConsoleKey.D1) status = AnimalStatusEnum.UpForAdoption;
            //if (Console.ReadKey().Key == ConsoleKey.D2) status = AnimalStatusEnum.SignedForAdoption;
            //if (Console.ReadKey().Key == ConsoleKey.D3) status = AnimalStatusEnum.NoChildHousehold;
            //if (Console.ReadKey().Key == ConsoleKey.D4) status = AnimalStatusEnum.UnAdoptable;

            if (typeOfAnimal == AnimalTypeEnum.Dog)
            {
                Console.WriteLine($"Does your {typeOfAnimal} have a heritage?\n" +
                    $"true or false:");
                var heritage = Convert.ToBoolean(Console.ReadLine());
                var newAnimal = new Dog(name, id, gender, typeOfAnimal, color, heritage, status);
                Animals.Add(newAnimal);

            }
            if (typeOfAnimal == AnimalTypeEnum.Cat)
            {
                Console.WriteLine($"Add a description to your {typeOfAnimal}:\n");
                var description = Console.ReadLine();
                var newAnimal = new Cat(name, id, gender, typeOfAnimal, color, description, status);
                Animals.Add(newAnimal);

            }
            if (typeOfAnimal == AnimalTypeEnum.Parrot)
            {
                Console.WriteLine($"What is the wingspan of your {typeOfAnimal}\n");
                var wingspan = Convert.ToDouble(Console.ReadLine());
                var newAnimal = new Parrot(name, id, gender, typeOfAnimal, color, wingspan, status);
                Animals.Add(newAnimal);
            }
            WriteToFile();
        }

        private AnimalStatusEnum GetStatus()
        {
            AnimalStatusEnum status;

            Console.WriteLine("What is the Animal Status? :\n" +
               "1. Up For Adoption\n" +
               "2. Signed for Adoption\n" +
               "3. No Child Household\n" +
               "4. Un-Adoptable");

            Console.Write("\n: ");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    status = AnimalStatusEnum.UpForAdoption;
                    return status;

                case ConsoleKey.D2:
                    status = AnimalStatusEnum.SignedForAdoption;
                    return status;

                case ConsoleKey.D3:
                    status = AnimalStatusEnum.NoChildHousehold;
                    return status;

                case ConsoleKey.D4:
                    status = AnimalStatusEnum.UnAdoptable;
                    return status;
                default:
                    status = AnimalStatusEnum.UpForAdoption;
                    return status;

            }

        }

        private GenderEnum GetGender()
        {
            GenderEnum gender;

            Console.WriteLine("Make a choice: ");
            Console.WriteLine("1.      Male");
            Console.WriteLine("2.      Female");
            Console.WriteLine("3.       Unknown");

            Console.Write("\n: ");



            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    gender = GenderEnum.Male;
                    return gender;

                case ConsoleKey.D2:
                    gender = GenderEnum.Female;
                    return gender;

                case ConsoleKey.D3:
                    gender = GenderEnum.Unknown;
                    return gender;

                default:
                    gender = GenderEnum.Unknown;
                    return gender;

            }

        }


    }
}
