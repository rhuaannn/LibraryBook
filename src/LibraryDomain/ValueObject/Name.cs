using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.ValueObject
{
    public class Name
    {
        public string FullName { get; private set; }

        public Name(string name)
        {
            if (!IsValid(name))
            {
                throw new ArgumentException("Nome inválido.");
            }
            FullName = name;
        }

        private Name() { }

        public static bool IsValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 2;
        }

        public override string ToString() => FullName;
    }
}