using CloudCustomers.api.Models;
namespace CloudCustomers.unittests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new()
        {
            new User
            {
                Name = "Test User 1",
                Email = "test.user.1@devenv.com",
                Address = new Address
                {
                    Street = "123 Test Street ",
                    City = "Test City",
                    ZipCode = "13521"
                }
            },
            new User
            {
                Name = "Test User 2",
                Email = "test.user.2@devenv.com",
                Address = new Address
                {
                    Street = "432 Test Street ",
                    City = "Test City",
                    ZipCode = "13521"
                }
            },
            new User
            {
                Name = "Test User 3",
                Email = "test.user.3@devenv.com",
                Address = new Address
                {
                    Street = "652 Test Street ",
                    City = "Test Town",
                    ZipCode = "23549"
                }
            }
        };
    }
}
