using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Kingdom.Model
{
    internal class Parrot : Animal
    {
        private string Color
        {
            get; set;
        }
        private double Wingspan { get; set; }
        //private AnimalStatusEnum AnimalStatus { get; set; }

        public Parrot(string name, int id, GenderEnum gender, AnimalTypeEnum type, string color, double wingspan, AnimalStatusEnum animalStatus) : base(name, id, gender, type, animalStatus)
        {
            Color= color;
            Wingspan= wingspan;
        }
    }
}
