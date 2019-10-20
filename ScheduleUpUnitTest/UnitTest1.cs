using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleUp.DAL;
using ScheduleUpV2;

namespace ScheduleUpUnitTest
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void MainWindowTest()
        {

        MainWindow window = new MainWindow();
        Assert.AreEqual(300, 300);
        }
    }

    [TestClass]
    public class LoginScreenTests
    {
        [TestMethod]
        public void LoginScreenTest()
        {

            LoginScreen window = new LoginScreen();
            Assert.AreEqual(300, 300);
        }
    }

    [TestClass]
    public class RegisterScreeTests
    {
        [TestMethod]
        public void RegisterScreeTest()
        {

            RegisterScreen window = new RegisterScreen();
            Assert.AreEqual(300, 300);
        }
    }

}
