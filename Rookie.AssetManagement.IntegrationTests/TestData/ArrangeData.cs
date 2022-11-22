using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Data;
<<<<<<< HEAD
using Rookie.AssetManagement.DataAccessor.Enum;
=======
>>>>>>> b5be597 (Init intergarion test)
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Contracts.Dtos.AuthDtos;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
=======
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
>>>>>>> 0fb06d7 (Integration Test)

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
<<<<<<< HEAD
<<<<<<< HEAD
                    FirstName = "An",
                    LastName = "Ngo Vo",
=======
                    FirstName = "First Name 1",
                    LastName = "Last Name 1",
>>>>>>> 0fb06d7 (Integration Test)
                    DateOfBirth = new DateTime(2000, 11, 31, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
<<<<<<< HEAD
                    FirstName = "Thuy",
                    LastName = "Dam Xuan",
=======
                    FirstName = "First Name 2",
                    LastName = "Last Name 2",
>>>>>>> 0fb06d7 (Integration Test)
                    DateOfBirth = new DateTime(2000, 05, 15, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
<<<<<<< HEAD
                    FirstName = "Quan",
                    LastName = "Hoang",
=======
                    FirstName = "First Name 3",
                    LastName = "Last Name 3",
>>>>>>> 0fb06d7 (Integration Test)
                    DateOfBirth = new DateTime(2000, 02, 17, 0, 0, 0),
                    Gender = UserGenderEnum.Female,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                
                
<<<<<<< HEAD
=======
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

>>>>>>> 0fb06d7 (Integration Test)
            };
        }

        public static UserCreateDto GetCreateUserDto()
        {
            return new UserCreateDto() {

                FirstName = "Dat",
                LastName = "Ngo Minh",
                DateOfBirth = new DateTime(2000, 02, 17, 0, 0, 0),
                Gender = UserGenderEnumDto.Female,
                JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                Type = "Staff",

            };
        }

        public static User Create()
        {
            return new User
            {
                UserName = "adminhcm"
            };

        }

        public static LoginDto GetLogin()
        {
            return new LoginDto() {

                UserName = "adminhcm",
                Password = "123456"

            };
        }



        public static void InitUsersData(ApplicationDbContext dbContext, UserManager<User> userManager)
=======
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
>>>>>>> b5be597 (Init intergarion test)
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
<<<<<<< HEAD


            //fix
            userManager.CreateAsync(Create(), "123456");

        }

=======
        }

        public static UserQueryCriteriaDto GetUserQueryCriteriaDto()
        {
            return new UserQueryCriteriaDto()
            {
                Limit = 5,
                Page = 1
            };
        }
>>>>>>> b5be597 (Init intergarion test)
    }
}