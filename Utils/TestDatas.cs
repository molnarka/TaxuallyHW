namespace TaxuallyHW.Utils
{
    public static class TestDatas
    {
        public static TestUser GetTestUser()
        {
            return new()
            {
                Email = "laszlo.imre.molnar@gmail.com",
                Password = "T3stp@SSword"
            };
        }
    }
}
