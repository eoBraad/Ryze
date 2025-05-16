using Bogus;
using Bogus.DataSets;
using Ryze.Domain.Entities;
using Ryze.Domain.Enums;

namespace Ryze.TestUtils.EntityUtils;

public static class UserEntityUtil
{
    public static User CreateAdminUser()
    {
        var userFaker = new Faker<User>()
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.Password, f => f.Random.AlphaNumeric(10))
            .RuleFor(u => u.Gender, f => f.PickRandom<UserGender>())
            .RuleFor(u => u.BirthDate, f => f.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(20)));
        
        var user = userFaker.Generate();

        user.Role = UserRoles.GlobalAdmin;

        return user;
    }
}