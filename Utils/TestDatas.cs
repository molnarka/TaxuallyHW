namespace TaxuallyHW.Utils
{
    public static class TestDatas
    {
        public static TestUser GetTestUser()
        {
            return new()
            {
                FirstName = "Laszlo",
                LastName = "Molnar",
                Email = "laszlo.imre.molnar@gmail.com",
                Password = "T3stp@SSword"
            };
        }

        public static string GetRandomString(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 1; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
