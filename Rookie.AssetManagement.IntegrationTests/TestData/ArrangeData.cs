using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Enum;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class UserArrangeData
    {
        public static List<User> GetSeedUsersData()
        {
            return new List<User>()
            {
                new User()
                {
                    FirstName = "First Name 1",
                    LastName = "Last Name 1",
                    DateOfBirth = new DateTime(2000, 11, 31, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
                    FirstName = "First Name 2",
                    LastName = "Last Name 2",
                    DateOfBirth = new DateTime(2000, 05, 15, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
                    FirstName = "First Name 3",
                    LastName = "Last Name 3",
                    DateOfBirth = new DateTime(2000, 02, 17, 0, 0, 0),
                    Gender = UserGenderEnum.Female,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                
                
            };
        }

        public static UserCreateDto GetCreateUserDto()
        {
            return new UserCreateDto() {

                FirstName = "First Name 4",
                LastName = "Last Name 4",
                DateOfBirth = new DateTime(2000, 02, 17, 0, 0, 0),
                Gender = UserGenderEnumDto.Female,
                JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                Type = "Staff",

            };
        }

        public static void InitUsersData(ApplicationDbContext dbContext)
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }

    }
}