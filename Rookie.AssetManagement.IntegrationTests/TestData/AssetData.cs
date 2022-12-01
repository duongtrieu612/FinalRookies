﻿using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
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
    public static class AssetData
    {
        public static List<Asset> GetSeedAssetsData()
        {
            return new List<Asset>()
            {
                new Asset()
                {
                    AssetCode = "LA000001",
                    AssetName = "Laptop Asus",
                    Category = new Category()
                    {
                        CategoryName = "Laptop",
                    },
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State =  new State()
                    {
                        StateName = "Assigned",
                    },
                    IsDeleted = false
                },
                new Asset()
                {
                    AssetCode = "MO000001",
                    AssetName = "Monitor",
                    Category = new Category()
                    {
                        CategoryName = "Monitor",
                    },
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State = new State()
                    {
                        StateName = "Available",
                    },
                    IsDeleted = false
                },
                new Asset()
                {
                    AssetCode = "PC000002",
                    AssetName = "PC 1",
                    Category = new Category()
                    {
                     CategoryName = "Personal Computer",
                    },
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State = new State()
                    {
                     StateName = "Available",
                    },
                    IsDeleted = false
                },
            };
        }
        public static List<AssetDto> GetAllAsset()
        {
            return new List<AssetDto>()
            {
                new AssetDto()
                {
                    AssetCode = "LA000001",
                    AssetName = "Laptop Asus",
                    Category = "Laptop",
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State =  "",
                },
                new AssetDto()
                {
                    AssetCode = "MO000001",
                    AssetName = "Monitor",
                    Category = "Monitor",
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State =  "",
                },
                new AssetDto()
                {
                   AssetCode = "PC000001",
                    AssetName = "Personal Computer",
                    Category = "Personal Computer",
                    Specification = "",
                    InstalledDate = new DateTime(),
                    State =  "",
                },
            };
        }
        public static List<State> GetSeedStatesData()
        {
            return new List<State>()
            {
                new State()
                {
                StateName = "Assigned",
                },
                new State()
                {
                 StateName = "Available",
                },
                new State()
                {
                 StateName = "Not Available",
                },
                 new State()
                {
                 StateName = "Waiting For Recycling",
                },
                  new State()
                {
                 StateName = "Recycled",
                },
            };
        }
        public static List<Category> GetSeedCategoriesData()
        {
            return new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Laptop",
                },
                new Category()
                {
                    CategoryName = "Monitor",
                },
                new Category()
                {
                    CategoryName = "Personal Computer",
                },
            };
        }
        public static AssetCreateDto GetCreateAssetDto()
        {
            return new AssetCreateDto()
            {
                AssetName = "Laptop Asus",
                Category = 1,
                Specification = "",
                InstalledDate = new DateTime(),
                State = 2
            };
        }

        public static void InitAssetsData(ApplicationDbContext dbContext)
        {
            var assets = GetSeedAssetsData();
            dbContext.Assets.AddRange(assets);
            dbContext.SaveChanges();

        }
        public static void InitCategoriesData(ApplicationDbContext dbContext)
        {
            var categories = GetSeedCategoriesData();
            dbContext.Categories.AddRange(categories);
            dbContext.SaveChanges();

        }
        public static void InitStatesData(ApplicationDbContext dbContext)
        {
            var states = GetSeedStatesData();
            dbContext.States.AddRange(states);
            dbContext.SaveChanges();

        }

        public static AssetUpdateDto GetAssetUpdateDto()
        {
            return new AssetUpdateDto()
            {
                Id = 3,
                AssetName = "Laptop Dell",
                Specification = "Laptop Dell",
                InstalledDate = new DateTime(2022, 11, 10, 0, 0, 0),
                State = 3,
            };
        }
    }
}
