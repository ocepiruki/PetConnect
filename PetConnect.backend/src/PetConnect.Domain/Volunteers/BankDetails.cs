namespace PetConnect.Domain.Volunteers
{
    public class BankDetails // Value Object в дальнейшем
    {
        public string BankName { get; set; } = default!;
        public string BankAddress { get; set; } = default!;
        public string BankAccount { get; set; } = default!;
        public string BIC { get; set; } = default!;
        public string CorrespondentAccount { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
    }
}
