using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Kingdom.Model
{
    internal class Cat :Animal
    {
        private string Color
        {
            get; set;
        }
        private string Description { get; set; }
        //private AnimalStatusEnum AnimalStatus { get; set; }

        public Cat(string name, int id, GenderEnum gender, AnimalTypeEnum type, string color,string description, AnimalStatusEnum animalStatus) : base(name, id, gender, type, animalStatus)
        {
           Color= color;
           Description= description;
        }
    }
}
