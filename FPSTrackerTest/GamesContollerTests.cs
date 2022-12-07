using FPSTracker.Controllers;
using FPSTracker.Data;
using FPSTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FPSTrackerTest
{
    [TestClass]
    public class GamesContollerTests
    {
        private ApplicationDbContext context;
        GamesController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
            context = new ApplicationDbContext(options);
            for(int i = 20; i < 30; i++)
            {
                var game = new Game { GameId = i, GameName = "Game " + i.ToString(), GameSize = i * 2, Rating = "M" };
                context.Add(game);
            }
            context.SaveChanges();
            controller = new GamesController(context);
        }
        #region "Index Tests"
        [TestMethod]
        public void IndexLoadView()
        {
            //arrange
            //done in TestInitialize

            //act
            var result = (ViewResult)controller.Index().Result;

            //assert
            Assert.AreEqual("Index", result.ViewName);

        }
        [TestMethod]
        public void IndexLoadGame()
        {
            //act
            var result = (ViewResult)controller.Index().Result;
            List<Game> model = (List<Game>)result.Model;

            //assert
            CollectionAssert.AreEqual(context.Games.ToList(), model);
        }
        #endregion
        #region "Detail Tests"
        [TestMethod]
        public void DetailsNoIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Details(null).Result;

            //assert
            Assert.AreEqual("404",result.ViewName);
        }
        [TestMethod]
        public void DetailsNoGametableLoads404()
        {
            //arrange
            context.Games = null;

            //act
            var result = (ViewResult)controller.Details(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DetailsInvaildIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Details(500).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DetailsIdLoadsView()
        {
            //act
            var result = (ViewResult)controller.Details(25).Result;

            //assert
            Assert.AreEqual("Details", result.ViewName);
        }
        [TestMethod]
        public void DetailsIdLoadsGame()
        {
            //act
            var result = (ViewResult)controller.Details(25).Result;

            //assert
            Assert.AreEqual(context.Games.Find(25), result.Model);
        }
        #endregion
        #region "Delete Tests"
        [TestMethod]
        public void DeleteNoIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Delete(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DeleteNoGametableLoads404()
        {
            //arrange
            context.Games = null;

            //act
            var result = (ViewResult)controller.Details(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DeleteInvaildIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Delete(500).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void DeleteIdLoadsView()
        {
            //act
            var result = (ViewResult)controller.Delete(25).Result;

            //assert
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void DeleteIdLoadsGame()
        {
            //act
            var result = (ViewResult)controller.Delete(25).Result;

            //assert
            Assert.AreEqual(context.Games.Find(25), result.Model);
        }
        #endregion
        #region "Edit Tests"
        [TestMethod]
        public void EditNoIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Edit(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void EditNoGametableLoads404()
        {
            //arrange
            context.Games = null;

            //act
            var result = (ViewResult)controller.Edit(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void EditInvaildIdLoads404()
        {
            //act
            var result = (ViewResult)controller.Edit(500).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void EditIdLoadsView()
        {
            //act
            var result = (ViewResult)controller.Edit(25).Result;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }
        [TestMethod]
        public void EditIdLoadsGame()
        {
            //act
            var result = (ViewResult)controller.Edit(25).Result;

            //assert
            Assert.AreEqual(context.Games.Find(25), result.Model);
        }
        [TestMethod]
        public void EditGameAndIdLoadsVaildView()
        {
            //act
            controller.ModelState.AddModelError("", "No error");
            var result = (ViewResult)controller.Edit(25,context.Games.Find(25)).Result;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditGameIddAndIdNotMatchingLoads404()
        {
            //act
            controller.ModelState.AddModelError("", "No error");
            var result = (ViewResult)controller.Edit(23, context.Games.Find(28)).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }
        [TestMethod]
        public void EditInvalidGame()
        {
            //arrange
            var game = new Game { GameId = 55, GameSize = 10, Rating = "M" };

            //act
            controller.ModelState.AddModelError("GameName", "No Name");
            var result = (ViewResult)controller.Edit(55, game).Result;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
            Assert.AreEqual(game,result.Model);
        }
        #endregion
        #region "Create Tests"
        [TestMethod]
        public void CreateLoadView()
        {
            //act
            var result = (ViewResult)controller.Create();

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }
        [TestMethod]
        public void CreateValidGameLoadsGame()
        {
            //arrange
            var game = new Game { GameId = 55, GameName = "Game 55", GameSize = 10, Rating = "M" };

            //act
            controller.ModelState.AddModelError("", "No error");
            var result = (ViewResult)controller.Create(game).Result;

            //assert
            Assert.AreEqual(game, result.Model);
        }
        [TestMethod]
        public void CreateInvalidGame()
        {
            //arrange
            var game = new Game { GameId = 55, GameSize = 10, Rating = "M" };

            //act
            controller.ModelState.AddModelError("GameName", "No Name");
            var result = (ViewResult)controller.Create(game).Result;

            //assert
            Assert.AreEqual(game, result.Model);
            Assert.AreEqual("Create", result.ViewName);
        }

        #endregion
    }
}