using CSharpFunctionalExtensions;
using PetConnect.Domain.Volunteers;

namespace PetConnect.Domain.Pets
{
    public class DetailsForAssistance
    {
        private DetailsForAssistance()
        {
        }
        private DetailsForAssistance(string assistanceDetails, BankDetails bankDetails)
        {
            Id = Guid.NewGuid();
            AssistanceDetails = assistanceDetails;
            BankDetails = bankDetails;
            CreationDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Guid Id { get; private set; }
        public string AssistanceDetails { get; private set; } = default!;
        public BankDetails BankDetails { get; private set; } = default!;

        public Volunteer Volunteer { get; private set; } = default!;
        public string VolunteerName => Volunteer.Name;
        public string VolunteerPhoneNumber => Volunteer.PhoneNumber;
        public string VolunteerEmail => Volunteer.Email;
        public AssistanceStatus AssistanceStatus { get; private set; }
        public DateOnly CreationDate { get; private set; }

        public static Result<DetailsForAssistance> Create(string assistanceDetails, BankDetails bankDetails)
        {
            if (string.IsNullOrWhiteSpace(assistanceDetails))
                return Result.Failure<DetailsForAssistance>("Assistance details should not be empty");
            if (bankDetails == null)
                return Result.Failure<DetailsForAssistance>("Bank details should not be empty");

            var detailsForAssistance = new DetailsForAssistance(assistanceDetails, bankDetails);
            return Result.Success(detailsForAssistance);
        }
    }
}
