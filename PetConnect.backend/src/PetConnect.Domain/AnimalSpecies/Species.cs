using CSharpFunctionalExtensions;

namespace PetConnect.Domain.AnimalSpecies
{
    public class Species
    {
        private Species()
        {

        }

        private Species(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        private readonly List<Breed> _breeds = [];
        public IReadOnlyList<Breed> Breeds => _breeds;

        public static Result<Species> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Species>("Name should not be empty");

            var species = new Species(name);
            return Result.Success(species);
        }
    }
}
