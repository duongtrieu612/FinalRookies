using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Enum;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Contracts.Dtos.AuthDtos;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class ArrangeData
    {
        public static List<User> GetSeedUsersData()
        {
            return new List<User>()
            {
                new User()
                {
                    FirstName = "An",
                    LastName = "Ngo Vo",
                    DateOfBirth = new DateTime(2000, 11, 31, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
                    FirstName = "Thuy",
                    LastName = "Dam Xuan",
                    DateOfBirth = new DateTime(2000, 05, 15, 0, 0, 0),
                    Gender = UserGenderEnum.Male,
                    JoinedDate = new DateTime(2022, 11, 10, 0, 0, 0),
                    Type = "Staff",
                },
                new User()
                {
                    FirstName = "Quan",
                    LastName = "Hoang",
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
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();


            //fix
            userManager.CreateAsync(Create(), "123456");

        }

    }
}