namespace LitecartWebTests

{
    public class AccountData
    {
        public AccountData(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Username={Username}, Password={Password}";
        }
    }
}

