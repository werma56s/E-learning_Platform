using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELearningPlatform;
using System.Linq;
using System.Security.Cryptography;
using ELearningPlatform.Panels.Creator;
using ELearningPlatform.Panels.User;

namespace TestELearningPlatform
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCheckPassword()
        {
            string textToCheck = "P@ssw0rd";
            bool actualResult = ELearningPlatform.SecurityPassword.CheckPassword(textToCheck);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "Text not correctly");
        }
        [TestMethod]
        public void TestMethodCheckPassword2()
        {
            string textToCheck = "toptop123";
            bool actualResult = ELearningPlatform.SecurityPassword.CheckPassword(textToCheck);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult, "Text correctly");
        }
        [TestMethod]
        public void TestMethodCheckLogin()
        {
            string loginToCheck = "user12";
            bool actualResult = ELearningPlatform.Register.CheckLogin(loginToCheck);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "Login not egxist in database");
        }
        [TestMethod]
        public void TestMethodCheckLogin2()
        {
            string loginToCheck = "user1";
            bool actualResult = ELearningPlatform.Register.CheckLogin(loginToCheck);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult, "Login is egxist in database");
        }
        [TestMethod]
        public void TestMethodSHA256Chack()
        {
            string source = "toptop123";
            string hash;
            bool actualResult;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = ELearningPlatform.SecurityPassword.GetHash(sha256Hash, source);
                actualResult = ELearningPlatform.SecurityPassword.VerifyHash(sha256Hash, source, hash);
            }
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "Wrong hash");
        }
        [TestMethod]
        public void TestMethodChackUser()
        {
            string login = "user1", password = "user1Q!@";
            bool actualResult = ELearningPlatform.Login.CheckUser(login, password);
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "This data not exist in database");
        }
        [TestMethod]
        public void TestMethodChackUser2()
        {
            string login = "user2", password = "user2Q!";
            bool actualResult = ELearningPlatform.Login.CheckUser(login, password);
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, actualResult, "This data not exist in database");
        }

        [TestMethod]
        public void TestMethodGetRole()
        {
            string login = "user1", password = "user1Q!@";
            int actualResult = ELearningPlatform.Login.GetRole(login, password);
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult, "Wrong Role data");
        }
        [TestMethod]
        public void TestMethodGetRole2()
        {
            string login = "user20", password = "user20Q!@"; //not exist this user
            int actualResult = ELearningPlatform.Login.GetRole(login, password);
            int expectedResult = -1;
            Assert.AreEqual(expectedResult, actualResult, "Wrong Role data");
        }

        [TestMethod]
        public void Check_internet_connetion()
        {

            bool actualResult = History.CheckConnectionIntenet();
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "you don't have intenet connetion");
        }
    }
}
