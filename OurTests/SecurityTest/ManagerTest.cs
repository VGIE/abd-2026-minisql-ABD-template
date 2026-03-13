using DbManager.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTests.SecurityTest
{
    public class ManagerTest
    {
        [Fact]
        public void ProfileByNameTest()
        {
            Profile p = new Profile();
            p.Name = "a";
            Manager manager = new Manager("b");
            Assert.False(p==manager.ProfileByName("a"));
            manager.AddProfile(p);
            Assert.False(p == manager.ProfileByName("a"));

        }

        [Fact]
        public void IsUserAdminTest() 
        {
            Profile p = new Profile();
            p.Name = "a";
            Manager manager = new Manager("b");
            Assert.False(manager.IsUserAdmin());
            manager.AddProfile(p);
            Assert.False(manager.IsUserAdmin());
             
        }

        [Fact]

        public void IsPasswordCorrectTest() 
        { 
            User user = new User("AraGo", "abcd");
            Manager manager = new Manager("AraGo");
            Profile p = new Profile();
            p.Name= "AraGo";
            p.Users.Add(user);
            manager.AddProfile(p);
            Assert.False(manager.IsPasswordCorrect("AraG", "adcd"));
            Assert.False(manager.IsPasswordCorrect("AraGo", "dcd"));
           // Assert.True(manager.IsPasswordCorrect("AraGo", "abcd"));
           //No va el profile by name

        }

    }
}
