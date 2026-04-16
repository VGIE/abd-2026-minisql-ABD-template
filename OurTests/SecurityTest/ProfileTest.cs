using DbManager;
using DbManager.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OurTests.SecurityTest
{
    public class ProfileTest
    {
        [Fact]
        public void GrantPrivilegeTest()
        {
            Profile p = new Profile();

            Assert.True(p.GrantPrivilege("t", Privilege.Update));
            Assert.True(p.GrantPrivilege("t", Privilege.Delete));
            Assert.False(p.GrantPrivilege("t", Privilege.Delete));

        }

        [Fact]
        public void RevokePrivilegeTest()
        {
            Profile p = new Profile();

            Assert.False(p.RevokePrivilege("t", Privilege.Select));
            p.GrantPrivilege("t", Privilege.Select);
            Assert.True(p.RevokePrivilege("t", Privilege.Select));
            Assert.False(p.RevokePrivilege("t", Privilege.Select));
        }

        [Fact]
        public void IsGrantedPrivilegeTest()
        {
            Profile p = new Profile();

            Assert.False(p.IsGrantedPrivilege("t", Privilege.Select));
            p.GrantPrivilege("t", Privilege.Select);
            Assert.True(p.IsGrantedPrivilege("t", Privilege.Select));
            p.RevokePrivilege("t", Privilege.Select);
            Assert.False(p.IsGrantedPrivilege("t", Privilege.Select));
        }

        [Fact]
        public void AddUser()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            Profile profile = new Profile();
            profile.Name = "userProfile";
            db.SecurityManager.Profiles.Add(profile);

            AddUser query = new AddUser("user", "1234", "userProfile");
            string result = query.Execute(db);

            Assert.Equal(Constants.AddUserSuccess, result);
            Assert.NotNull(db.SecurityManager.UserByName("user"));
        }

        [Fact]
        public void DeleteUser()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            Profile profile = new Profile();
            profile.Name = "userProfile";

            User user = new User("user", "1234");
            profile.Users.Add(user);

            db.SecurityManager.Profiles.Add(profile);

            DeleteUser query = new DeleteUser("user");
            string result = query.Execute(db);

            Assert.Equal(Constants.DeleteUserSuccess, result);
            Assert.Null(db.SecurityManager.UserByName("user"));
        }

        [Fact]
        public void DeleteNonExistentUser()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            DeleteUser query = new DeleteUser("user");
            string result = query.Execute(db);

            Assert.Equal(Constants.UserDoesNotExistError, result);
        }

        [Fact]
        public void AddProfilePrivileges()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            Profile profile = new Profile();
            profile.Name = "userProfile";
            db.SecurityManager.Profiles.Add(profile);


            db.SecurityManager.GrantPrivilege("userProfile", "People", Privilege.Select);

            bool privilege = db.SecurityManager.IsGrantedPrivilege(Database.AdminUsername, "People", Privilege.Select);

            Assert.True(privilege);
        }

        [Fact]
        public void AddProfilePrivilegesWithNormalUser()
        {
            string normalUsername = "user";
            string normalPassword = "1234";
            Database db = new Database(normalUsername, normalPassword);

            Profile profile = new Profile();
            profile.Name = "userProfile";
            User user = new User(normalUsername, normalPassword);
            profile.Users.Add(user);

            db.SecurityManager.Profiles.Add(profile);

            profile.GrantPrivilege("People", Privilege.Select);

            bool privilege = db.SecurityManager.IsGrantedPrivilege(normalUsername, "People", Privilege.Select);

            Assert.True(privilege);
        }
        [Fact]
        public void DropSecurityProfile()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            Profile profile = new Profile();
            profile.Name = "userProfile";
            db.SecurityManager.Profiles.Add(profile);

            DropSecurityProfile query = new DropSecurityProfile("userProfile");
            string result = query.Execute(db);

            Assert.Equal(Constants.DropSecurityProfileSuccess, result);
            Assert.Null(db.SecurityManager.ProfileByName("userProfile"));
        }

        [Fact]
        public void DropSecurityProfileDoesNotExist()
        {
            Database db = new Database(Database.AdminUsername, Database.AdminPassword);

            DropSecurityProfile query = new DropSecurityProfile("userProfile");
            string result = query.Execute(db);

            Assert.Equal(Constants.SecurityProfileDoesNotExistError, result);
        }
    }
}
