using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPanelApp
{
    public class Permission
    {
        public string Name {get;set;}

        public Permission(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Role
    {
        public string Name {get;set;}
        private List<Permission> permissions = new List<Permission>();

        public Role(string name)
        {
            Name = name;
        }

        public void AddPermission(Permission permission)
        {
            if (!permissions.Contains(permission))
            {
                permissions.Add(permission);
            }
        }

        public void RemovePermission(Permission permission)
        {
            permissions.Remove(permission);
        }

        public List<Permission> GetPermissions()
        {
            return permissions;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class User
    {
        public string Username {get;set;}
        private List<Role> roles = new List<Role>();

        public User(string username)
        {
            Username = username;
        }

        public void AddRole(Role role)
        {
            if (!roles.Contains(role))
            {
                roles.Add(role);
            }
        }

        public void RemoveRole(Role role)
        {
            roles.Remove(role);
        }

        public List<Role> GetRoles()
        {
            return roles;
        }

        public bool HasPermission(string permissionName)
        {
            return roles
                .SelectMany(r => r.GetPermissions())
                .Any(p => p.Name == permissionName);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Użytkownik: {Username}");

            foreach (var role in roles)
            {
                Console.WriteLine($"  Rola: {role.Name}");
                foreach (var perm in role.GetPermissions())
                {
                    Console.WriteLine($"    Uprawnienie: {perm.Name}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Permission read = new Permission("READ");
            Permission write = new Permission("WRITE");
            Permission delete = new Permission("DELETE");

            Role admin = new Role("Admin");
            admin.AddPermission(read);
            admin.AddPermission(write);
            admin.AddPermission(delete);

            Role writer = new Role("Writer");
            writer.AddPermission(read);
            writer.AddPermission(write);

            Role viewer = new Role("Viewer");
            viewer.AddPermission(read);

            User user1 = new User("User1");
            User user2 = new User("User2");

            user1.AddRole(admin);
            user2.AddRole(viewer);

            user1.DisplayInfo();
            user2.DisplayInfo();

            Console.WriteLine();
            Console.WriteLine($"Czy User1 ma DELETE? {user1.HasPermission("DELETE")}");
            Console.WriteLine($"Czy User2 ma WRITE? {user2.HasPermission("WRITE")}");

            user1.RemoveRole(admin);
            Console.WriteLine("\nPo usunięciu roli Admin:");
            user1.DisplayInfo();
        }
    }
}