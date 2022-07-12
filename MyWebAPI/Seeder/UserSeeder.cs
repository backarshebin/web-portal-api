using System;
using System.Linq;
using AutoMapper;
using System.Text.Json.Serialization;
using System.Text.Json;
using portal_dal;
using portal_domain;

namespace MyWebAPI
{
    public static class UserSeeder
    {
        public static void Initialize(PortalDbContext context)
        {

            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;
            }
            List<UserDTO> userList = new List<UserDTO>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            var path = Directory.GetCurrentDirectory();
            using (StreamReader r = new StreamReader(System.IO.Path.Join(path, "/Seeder/SampleData/users.json")))
            {
                string json = r.ReadToEnd();
                if (json != null)
                {
                    userList = JsonSerializer.Deserialize<List<UserDTO>>(json);
                }

            }
            List<User> users = mapper.Map<List<User>>(userList);

            foreach (User s in users.OrderBy(x => x.Id))
            {
                context.Users.Add(s);
            }
            context.SaveChanges();
        }
    }
}
