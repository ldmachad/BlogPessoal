namespace blogpessoal.Security
{
    public class Settings
    {
        private static string secret = "456134b26a99f9f595bd0044128d75e0aae35bef23d30e5c737be9234bfde674";

        public static string Secret {get => secret; set => secret = value;}
    }
}