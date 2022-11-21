using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
<<<<<<< HEAD
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Enum;
=======
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
>>>>>>> b5be597 (Init intergarion test)
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Tests;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using System.Collections.Generic;

namespace Rookie.AssetManagement.IntegrationTests
{
<<<<<<< HEAD
    public class UserControllerShould : IClassFixture<SqliteInMemoryFixture>
=======
    public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
>>>>>>> b5be597 (Init intergarion test)
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly UsersController _userController;

<<<<<<< HEAD
        public UserControllerShould(SqliteInMemoryFixture fixture)
=======
        public AssetControllerShould(SqliteInMemoryFixture fixture)
>>>>>>> b5be597 (Init intergarion test)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userRepository = new BaseRepository<User>(_dbContext);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

<<<<<<< HEAD
            _userService = new UserService(_userRepository, _mapper);
            _userController = new UsersController(_userService);
=======
            _userService = new userService(_userRepository, _mapper);
            _userController = new usersController(_userService);
>>>>>>> b5be597 (Init intergarion test)
        }

        [Fact]
        public async Task AddUsersAsync_Success()
        {
            //Arrange
<<<<<<< HEAD
<<<<<<< HEAD
            var userRequest = ArrangeData.GetCreateUserDto();
=======
            var userRequest = UserArrangeData.GetCreateUserDto();
>>>>>>> 0fb06d7 (Integration Test)

            // Act
            var result = await _userController.AddUser(userRequest);

            // Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<UserDto>(actionResult.Value);

            Assert.Equal(returnValue.FirstName, userRequest.FirstName);
=======
            var newUserId = 7;


            // Act
            var result = await _userController.AddAsync();


            // Assert
            result.Should().NotBeNull();
            
>>>>>>> b5be597 (Init intergarion test)
        }
        [Fact]
        public async Task AddAsyncShouldThrowExceptionAsync()
        {
<<<<<<< HEAD
            await Assert.ThrowsAsync<ArgumentNullException>(() => _userController.AddUser(null));
        }

=======
            Func<Task> act = async () => await _userController.AddAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        
>>>>>>> b5be597 (Init intergarion test)
    }
}