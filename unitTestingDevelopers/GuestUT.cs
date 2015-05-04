using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
namespace unitTestingDevelopers
{
    [TestClass]
    public class GuestUT
    {
        [TestMethod]
        public void registerTest()
        {
            bool ans = false;
            ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();
            Guest Nofar = new Guest();
            Nofar.register("benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            if (system.Members.ContainsKey("benshnof"))
            {
                ans = (system.Members["benshnof"] != null);
            }
            Assert.IsTrue(ans);
        }
    }
}
