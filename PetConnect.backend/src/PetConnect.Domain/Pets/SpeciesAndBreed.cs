using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Domain.Pets
{
    public readonly struct SpeciesAndBreed
    {
        public string Species { get; }
        public string Breed { get; }

        private SpeciesAndBreed(string species, string breed)
        {
            Species = species;
            Breed = breed;
        }

        public static Result<SpeciesAndBreed> Create(string species, string breed)
        {
            if (string.IsNullOrWhiteSpace(species))
                return Result.Failure<SpeciesAndBreed>("Species should not be empty");
            if (string.IsNullOrWhiteSpace(breed))
                return Result.Failure<SpeciesAndBreed>("Breed should not be empty");

            var speciesAndBreed = new SpeciesAndBreed(species, breed);
            return Result.Success(speciesAndBreed);
        }

        public override string ToString() => $"{Species}, {Breed}";
    }
}
