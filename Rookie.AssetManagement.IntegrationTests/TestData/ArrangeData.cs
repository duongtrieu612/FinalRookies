using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;

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
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                },
                new User()
                {
                    FirstName = "First Name 2",
                    LastName = "Last Name 2",
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                },
                new User()
                {
                    FirstName = "First Name 3",
                    LastName = "Last Name 3",
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                },
                new User()
                {
                    FirstName = "First Name 4",
                    LastName = "Last Name 4",
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                },
                new User()
                {
                    FirstName = "First Name 5",
                    LastName = "Last Name 5",
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                },
                new User()
                {
                    FirstName = "First Name 6",
                    LastName = "Last Name 6",
                    DateOfBirth = "",
                    Gender = "",
                    JoinedDate = "",
                    Type = ""
                }
            };
        }

        public static void InitUsersData(ApplicationDbContext dbContext)
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }

        public static UserQueryCriteriaDto GetUserQueryCriteriaDto()
        {
            return new UserQueryCriteriaDto()
            {
                Limit = 5,
                Page = 1
            };
        }
    }
}