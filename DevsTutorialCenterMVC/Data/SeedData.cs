using DevsTutorialCenterMVC.Data.Entities;

namespace DevsTutorialCenterMVC.Data
{
    public static class SeedData
	{
		public static IList<string> Roles { get; set; } = new List<string> { "admin", "editor", "decadev" };
		public static IList<AppUser> Users { get; set; } = new List<AppUser> {
			new AppUser
            {
				Id = "148d2f6f-af7a-423a-baa2-f01d434d9b3a",
				Email = "tester1@example.com",
				UserName = "tester1@example.com",
				FirstName = "Tester",
				LastName = "One"
            },
            new AppUser
            {
                Id = "1db045d1-3844-48a9-856f-b70ab674eafc",
                Email = "tester2@example.com",
                UserName = "tester2@example.com",
                FirstName = "Tester",
                LastName = "Two"
            },
            new AppUser
            {
                Email = "tester3@example.com",
                UserName = "tester3@example.com",
                FirstName = "Tester",
                LastName = "Three",
                Id = "0ae8ae01-1c9b-4a23-a995-b3f7197b29a3"
            },
            new AppUser
            {
                Email = "tester4@example.com",
                UserName = "tester4@example.com",
                FirstName = "Tester",
                LastName = "Four",
                Id = "1ebe6087-5788-4281-8401-ee0e4ce5031d"
            },
            new AppUser
            {
                Email = "tester5@example.com",
                UserName = "tester5@example.com",
                FirstName = "Tester",
                LastName = "Five",
                Id = "902258f9-b3c2-42d0-b420-59d383a269dc"
            },
            new AppUser
            {
                Email = "tester6@example.com",
                UserName = "tester6@example.com",
                FirstName = "Tester",
                LastName = "Six",
                Id = "92d57368-0133-4fa6-b85c-2c5dd03cd802"
            }
        };
    }
}

