namespace LibraryDomain.ValueObject
{ public class Password
    {
        public string HashedPassword { get; private set; }

        public Password(string password)
        {
            if (!IsValid(password))
            {
                throw new ArgumentException("Senha inválida.");
            }
            HashedPassword = password;
        }

        private Password()
        {
            
        }
        public static bool IsValid(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }
        
        public override string ToString() => HashedPassword;   
    }
}
