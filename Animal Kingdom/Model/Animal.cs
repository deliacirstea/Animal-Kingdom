using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Kingdom.Model
{
    internal class Animal
    {

        public string Name { get; set; }
        public int Id { get; set; }
        public GenderEnum Gender { get; set; }

        public AnimalTypeEnum Type { get; set; }
        public AnimalStatusEnum AnimalStatus{ get; set; }

        public Animal(string name , int id, GenderEnum gender, AnimalTypeEnum type, AnimalStatusEnum animalStatus) 
        {
            Name = name;
            Id = id;
            Gender = gender;
            Type = type;
            AnimalStatus = animalStatus;
        }

        
    }
}
