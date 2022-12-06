using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.Contracts.Dtos.CategoryDtos;
using Rookie.AssetManagement.Contracts.Dtos.StateDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public class AssignmentData{
        public static List<Assignment> GetSeedAssignmentsData(){
            return new List<Assignment>(){
                new Assignment()
                {
                    Asset = new Asset(){
                        
                        AssetCode = "MO000001",
                        AssetName = "Personal Computer xyz",
                    },
                     AssignedTo= new User(){
                        
                        UserName = "damthuy",
                    },
                    AssignedBy = new User(){
                        
                        UserName = "admin",
                    },
                    AssignedDate = new DateTime(),
                    State = new State(){
                        Id = 1,
                        StateName = "Accepted"
                    },
                    IsDeleted = false,
                    Note = "abc"
                },
                new Assignment(){
                    Asset = new Asset (){
                        
                        AssetCode = "MO000002",
                        AssetName = "Personal Computer xyz2",
                    }, 
                    AssignedTo= new User(){
                        
                        UserName = "binhnv",
                    },
                    AssignedBy = new User(){
                        
                        UserName = "admin",
                    },
                    AssignedDate = new DateTime(),
                    State = new State(){
                        Id = 1,
                        StateName = "Accepted"
                    },
                    IsDeleted = false,
                    Note = "abc"
                }
            };
        }

        public static List<State> GetSeedStatesData()
        {
             return new List<State>()
            {
                new State()
                {
                StateName = "Accepted",
                },
                new State()
                {
                StateName = "Waiting for Acceptance",
                }
        };}

    public static List<User> GetSeedUsersData()
        {
             return new List<User>()
            {
                new User()
                {       
                UserName="admin"               
                },
                new User()
                {              
                UserName="damthuy"       
                },
                new User()
                {               
                UserName="binhnv"       
                }
        };}

    public static List<Asset> GetSeedAssetsData()
        {
             return new List<Asset>()
            {
                new Asset()
                {
                    AssetCode = "MO000001",
                    AssetName = "Personal Computer xyz",
                },
                new Asset()
                {
                    AssetCode = "MO000002",
                    AssetName = "Personal Computer xyz2",
                }
        };}
        public static List<AssignmentDto> GetAllAssignments(){
            return new List<AssignmentDto>()
            {
                new AssignmentDto(){
                    AssetCode = "MO000001",
                    AssetName = "Personal Computer xyz",
                    AssignedTo = "damthuy",
                    AssignedBy = "admin",
                    AssignedDate = new DateTime(),
                    State = "",
                },
                new AssignmentDto(){
                    AssetCode = "MO000002",
                    AssetName = "Personal Computer xyz2",
                    AssignedTo = "binhnv",
                    AssignedBy = "admin",
                    AssignedDate = new DateTime(),
                    State = "",
                },

            };
        }

        public static void InitAssignmentsData(ApplicationDbContext dbContext)
        {
            var assignments = GetSeedAssignmentsData();          
            var state = dbContext.States.FirstOrDefault(s => s.Id == 1);
            foreach (var assignment in assignments)
            {
                assignment.State = state;
            }
            dbContext.Assignments.AddRange(assignments);
            dbContext.SaveChanges();

        }
        public static void InitAssetsData(ApplicationDbContext dbContext)
        {
            var assets = GetSeedAssetsData();
            dbContext.Assets.AddRange(assets);
            dbContext.SaveChanges();

        }
        public static void InitUsersData(ApplicationDbContext dbContext)
        {
            var users = GetSeedUsersData();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

        }
        public static void InitStatesData(ApplicationDbContext dbContext)
        {
            var states = GetSeedStatesData();
            dbContext.States.AddRange(states);
            dbContext.SaveChanges();

        }
    }
}