using CSharpFunctionalExtensions;
using PetConnect.Domain.Volunteers;

namespace PetConnect.Domain.Pets
{
    public class Pet
    {
        private Pet()
        {

        }

        private Pet(string nickname, string description)
        {
            Id = Guid.NewGuid();
            Nickname = nickname;
            Description = description;
            CreationDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Guid Id { get; private set; }
        public string Nickname { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public SpeciesAndBreed SpeciesAndBreed { get; private set; }
        public string AnimalColor { get; private set; } = default!;
        public string HealthInfo { get; private set; } = default!;
        public string petAddress { get; private set; } = default!;
        public string petWeight { get; private set; } = default!;
        public string petHeight { get; private set; } = default!;
        public DateOnly petBirthDate { get; private set; } = default!;
        public string petGender { get; private set; } = default!;
        public Guid VolunteerId { get; private set; }
        public Volunteer Volunteer { get; private set; } = default!;
        public string VolunteerName => Volunteer.Name;
        public string VolunteerPhoneNumber => Volunteer.PhoneNumber;
        public string VolunteerEmail => Volunteer.Email;
        public bool IsVaccinated { get; private set; }
        public bool IsChipped { get; private set; }
        public bool IsSterilized { get; private set; }
        public AssistanceStatus AssistanceStatus { get; private set; }
        public string DetailsForAssistance { get; private set; } = default!;
        public DateOnly CreationDate { get; private set; }

        public static Result<Pet> Create(string nickname, string description)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return Result.Failure<Pet>("Nickname should not be empty");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Pet>("Description should not be empty");

            var pet = new Pet(nickname, description);

            return Result.Success(pet);
        }

        public Result<SpeciesAndBreed> CreateSpeciesAndBreed(string species, string breed)
        {
            return SpeciesAndBreed.Create(species, breed);
        }
    }
}
