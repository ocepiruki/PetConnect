using CSharpFunctionalExtensions;
using PetConnect.Domain.Pets;

namespace PetConnect.Domain.Volunteers
{
    public class Volunteer
    {
        private Volunteer()
        {
            
        }

        private Volunteer(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;

        private readonly List<Pet> _pets = [];
        public IReadOnlyList<Pet> Pets => _pets;

        public int GetNumberOfPetsThatFoundHome()
        {
            return _pets.Count(p => p.AssistanceStatus == AssistanceStatus.FoundHome);
        }

        public int GetNumberOfPetsLookingForHomes()
        {
            return _pets.Count(p => p.AssistanceStatus == AssistanceStatus.LookingForHome);
        }

        public int GetNumberOfPetsOnTreatment()
        {
            return _pets.Count(p => p.AssistanceStatus == AssistanceStatus.NeedsHelp);
        }

        private readonly List<SocialNetwork> _socialNetworks = [];
        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
        public DetailsForAssistance DetailsForAssistance { get; private set; } = default!;

        public static Result<Volunteer> Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Volunteer>("Name should not be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Volunteer>("Description should not be empty");
            
            var volunteer = new Volunteer(name, description);

            return Result.Success(volunteer);
        }
    }
}
