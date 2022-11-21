using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
>>>>>>> 69c2661 (Init intergarion test)
=======
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Enum;
>>>>>>> 621820f (Integration Test)
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
<<<<<<< HEAD
<<<<<<< HEAD
    public class UserControllerShould : IClassFixture<SqliteInMemoryFixture>
=======
    public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
>>>>>>> b5be597 (Init intergarion test)
=======
    public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
>>>>>>> 69c2661 (Init intergarion test)
=======
    public class UserControllerShould : IClassFixture<SqliteInMemoryFixture>
>>>>>>> 40ce46f (Integration Test)
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly UsersController _userController;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public UserControllerShould(SqliteInMemoryFixture fixture)
=======
        public AssetControllerShould(SqliteInMemoryFixture fixture)
>>>>>>> b5be597 (Init intergarion test)
=======
        public AssetControllerShould(SqliteInMemoryFixture fixture)
>>>>>>> 69c2661 (Init intergarion test)
=======
        public UserControllerShould(SqliteInMemoryFixture fixture)
>>>>>>> 40ce46f (Integration Test)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userRepository = new BaseRepository<User>(_dbContext);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            _userService = new UserService(_userRepository, _mapper);
            _userController = new UsersController(_userService);
=======
            _userService = new userService(_userRepository, _mapper);
            _userController = new usersController(_userService);
>>>>>>> b5be597 (Init intergarion test)
=======
            _userService = new userService(_userRepository, _mapper);
            _userController = new usersController(_userService);
>>>>>>> 69c2661 (Init intergarion test)
=======
            _userService = new UserService(_userRepository, _mapper);
            _userController = new UsersController(_userService);
>>>>>>> 621820f (Integration Test)
        }

        [Fact]
        public async Task AddUsersAsync_Success()
        {
            //Arrange
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
>>>>>>> 69c2661 (Init intergarion test)
            var newUserId = 7;

=======
            var userRequest = UserArrangeData.GetCreateUserDto();
>>>>>>> 621820f (Integration Test)

            // Act
            var result = await _userController.AddUser(userRequest);

            // Assert
            result.Should().NotBeNull();
<<<<<<< HEAD
            
<<<<<<< HEAD
>>>>>>> b5be597 (Init intergarion test)
=======
>>>>>>> 69c2661 (Init intergarion test)
=======

            var actionResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<UserDto>(actionResult.Value);

            Assert.Equal(returnValue.FirstName, userRequest.FirstName);
>>>>>>> 621820f (Integration Test)
        }
        [Fact]
        public async Task AddAsyncShouldThrowExceptionAsync()
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            await Assert.ThrowsAsync<ArgumentNullException>(() => _userController.AddUser(null));
        }

=======
=======
>>>>>>> 69c2661 (Init intergarion test)
            Func<Task> act = async () => await _userController.AddAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        
<<<<<<< HEAD
>>>>>>> b5be597 (Init intergarion test)
=======
>>>>>>> 69c2661 (Init intergarion test)
=======
            await Assert.ThrowsAsync<ArgumentNullException>(() => _userController.AddUser(null));
        }

>>>>>>> 621820f (Integration Test)
    }
}