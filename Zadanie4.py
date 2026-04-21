class Permission:
    def __init__(self, name: str):
        self.name = name

    def __repr__(self):
        return f"Permission({self.name})"

    def __eq__(self, other):
        return isinstance(other, Permission) and self.name == other.name

    def __hash__(self):
        return hash(self.name)


class Role:
    def __init__(self, name: str):
        self.name = name
        self.permissions: Set[Permission] = set()

    def add_permission(self, permission: Permission):
        self.permissions.add(permission)

    def remove_permission(self, permission: Permission):
        self.permissions.discard(permission)

    def has_permission(self, permission: Permission) -> bool:
        return permission in self.permissions

    def __repr__(self):
        return f"Role({self.name})"


class User:
    def __init__(self, username: str):
        self.username = username
        self.roles: Set[Role] = set()
        self.direct_permissions: Set[Permission] = set()

    def add_role(self, role: Role):
        self.roles.add(role)

    def remove_role(self, role: Role):
        self.roles.discard(role)

    def add_permission(self, permission: Permission):
        self.direct_permissions.add(permission)

    def remove_permission(self, permission: Permission):
        self.direct_permissions.discard(permission)

    def has_permission(self, permission: Permission) -> bool:
        if permission in self.direct_permissions:
            return True

        for role in self.roles:
            if role.has_permission(permission):
                return True

        return False

    def __repr__(self):
        return f"User({self.username})"

if __name__ == "__main__":
    read = Permission("read")
    write = Permission("write")
    delete = Permission("delete")

    admin = Role("admin")
    writer = Role("writer")
    viewer = Role("viewer")

    admin.add_permission(read)
    admin.add_permission(write)
    admin.add_permission(delete)

    writer.add_permission(read)
    writer.add_permission(write)

    viewer.add_permission(read)

    user1 = User("User1")
    user2 = User("User2")

    user1.add_role(admin)
    user2.add_role(viewer)
    
    print(user2, "Czy może wpisać treść?", user2.has_permission(write))

    user2.add_permission(write)

    print(user1, "Czy może usuwać treści?", user1.has_permission(delete))
    print(user2, "Czy może wpisać treść?", user2.has_permission(write))
    print(user2, "Czy może usunąć treść?", user2.has_permission(delete))

    user1.remove_role(admin)
    print(user1, "Czy może usunąć treść po usunięciu roli?", user1.has_permission(delete))