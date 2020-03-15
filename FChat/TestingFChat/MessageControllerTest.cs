using FChat.DataAccess;
using FChat.DataModel.Enums;
using FChat.DataService.Services;
using FChat.DataService.ViewModels;
using FChat.Testing.DbContext;
using FChat.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;


namespace FChat.Testing
{
    [TestClass]
    public class MessageControllerTest : DataContextBase
    {
        [TestMethod]
        public void GetAll_CheckCount()
        {
            var controller = new MessageController(new MessageService(new DataAccessService(context)), mapper);

            var result = controller.GetAll(GroupType.Family);

            var expected = 6;

            Assert.IsInstanceOfType(result, typeof(IEnumerable<MessageViewModel>));

            Assert.IsNotNull(result);

            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public void AddMessage_CheckNullEntry()
        {
            var controller = new MessageController(new MessageService(new DataAccessService(context)), mapper);

            var result = controller.AddMessage(null);

            var expected = BadRequest();

            Assert.IsNotNull(result);

            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void AddMessage_CheckValidEntry()
        {
            var controller = new MessageController(new MessageService(new DataAccessService(context)), mapper);

            var result = controller.AddMessage(new MessageViewModel()
            {
                Message = "Hello",
                User = new UserViewModel() { Id = 1, Name = "Ivan" },
                GroupTypeId = 1,
                CreatedOn = DateTime.Now
            });

            var expected = Ok();

            Assert.IsNotNull(result);

            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void AddMessage_CheckInvalidEntry()
        {
            var controller = new MessageController(new MessageService(new DataAccessService(context)), mapper);

            var result = controller.AddMessage(new MessageViewModel()
            {
                Message = "Hello",
                User = null,
                GroupTypeId = 1,
                CreatedOn = DateTime.Now
            });

            var expected = BadRequest();

            Assert.IsNotNull(result);

            Assert.AreEqual(expected.StatusCode, result.StatusCode);
        }
    }
}
