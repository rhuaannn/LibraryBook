using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.ValueObject
{
    public class Email
    {
        public string Address { get;  set; }

        public Email(string address)
        {
            if (!IsValid(address))
            {
                throw new ArgumentException("Endereço de e-mail inválido.");
            }
            Address = address;
        }

        public Email() { }

        public static bool IsValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && new EmailAddressAttribute().IsValid(email);
        }

        public override string ToString() => Address;
    }

}
