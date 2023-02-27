using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Kingdom.Model
{
    internal class Dog : Animal
    {
        private string Color
        {
            get; set;
        }   
        private bool Heritage { get; set; }
        //private AnimalStatusEnum AnimalStatus { get; set; }

        public Dog(string name, int id, GenderEnum gender, AnimalTypeEnum type,string color, bool heritage, AnimalStatusEnum animalStatus): base(name, id, gender, type, animalStatus)
        {
            Color = color;
            Heritage = heritage;
        }
    }
}
