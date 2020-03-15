using FChat.DataAccess;
using FChat.DataService.Services;
using FChat.DataService.ViewModels;
using FChat.Testing.DbContext;
using FChat.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestingFChat
{
    [TestClass]
    public class UserControllerTest: DataContextBase
    {
        [TestMethod]
        public void GetUserByName_CheckUniqueness()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result =  controller.GetUser("Metodi");

            var expected = new UserViewModel() { Name = "Metodi" };

            Assert.IsInstanceOfType(result, typeof(UserViewModel));

            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void GetUserByName_CheckNullEntry()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result = controller.GetUser("");

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetUserByName_CheckNotFound()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result = controller.GetUser("NotFoundInTheDB");

            Assert.AreEqual(null, result);
        }


        [TestMethod]
        public void GetUsers_CheckCount()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result = controller.GetUsers();

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, result.Count());
        }

        [TestMethod]
        public void GetById_CheckNotFound()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result = controller.GetById(10);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetById_CheckFound()
        {
            var controller = new UserController(new UserService(new DataAccessService(context)), mapper);

            var result = controller.GetById(3);

            Assert.IsNotNull(result);
        }

    }
}
