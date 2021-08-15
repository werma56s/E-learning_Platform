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
        public void TestMethodCheckCorrectPasswordInTermsOfSecurity()
        {
            string textToCheck = "P@ssw0rd";
            bool actualResult = ELearningPlatform.SecurityPassword.CheckPassword(textToCheck);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "Password not correctly - haven't needed items - lower case letter, upper case lette, one numeric value, one special case characters, minimum length 7");
        }
        [TestMethod]
        public void TestMethodCheckFailedPasswordInTermsOfSecurity()
        {
            string textToCheck = "toptop123";
            bool actualResult = ELearningPlatform.SecurityPassword.CheckPassword(textToCheck);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult, "Password correct - have all needed items - lower case letter, upper case lette, one numeric value, one special case characters, minimum length 7");
        }
        [TestMethod]
        public void TestMethodCheckLoginWhetherExistInDatabase()
        {
            string loginToCheck = "user12";
            bool actualResult = ELearningPlatform.Register.CheckLogin(loginToCheck);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "Login not egxist in database");
        }
        [TestMethod]
        public void TestMethodCheckLoginWhetherNotExistInDatabase()
        {
            string loginToCheck = "user1";
            bool actualResult = ELearningPlatform.Register.CheckLogin(loginToCheck);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult, "Login is egxist in database");
        }
        [TestMethod]
        public void TestMethodCheckSHA256()
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
        public void TestMethodCheckUserWhenExistInDatabase()
        {
            string login = "user1", password = "user1Q!@";
            bool actualResult = ELearningPlatform.Login.CheckUser(login, password);
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult, "This data not exist in database");
        }
        [TestMethod]
        public void TestMethodCheckUserWhenUserNotExistInDatabase()
        {
            string login = "user2", password = "user2Q!";
            bool actualResult = ELearningPlatform.Login.CheckUser(login, password);
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, actualResult, "This data exist in database");
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
        public void TestMethodGetRoleFromNotExistingUser()
        {
            string login = "user20", password = "user20Q!@"; //not exist this user
            int actualResult = ELearningPlatform.Login.GetRole(login, password);
            int expectedResult = -1;
            Assert.AreEqual(expectedResult, actualResult, "Wrong Role data");
        }

        [TestMethod]
        public void CheckInternetConnetion()
        {

            bool actualResult = History.CheckConnectionIntenet();
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, actualResult, "you don't have internet connection");
        }
    }
}
