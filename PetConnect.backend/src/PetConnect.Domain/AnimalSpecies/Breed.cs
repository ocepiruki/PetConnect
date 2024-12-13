using CSharpFunctionalExtensions;

namespace PetConnect.Domain.AnimalSpecies
{
    public class Breed
    {
        private Breed()
        {
            
        }

        private Breed(string breedName)
        {
            Id = Guid.NewGuid();
            BreedName = breedName;
        }

        public Guid Id { get; private set; }
        public string BreedName { get; private set; } = default!;

        public static Result<Breed> Create(string breedName)
        {
            if (string.IsNullOrWhiteSpace(breedName))
                return Result.Failure<Breed>("Breed name should not be empty");

            var breed = new Breed(breedName);
            return Result.Success(breed);
        }
    }
}
