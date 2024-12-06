﻿namespace SocialNetworkBE.Test;

using Microsoft.AspNetCore.Identity;
using Moq;

public static class MockHelpers
{
    public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
    {
        var store = new Mock<IUserStore<TUser>>();
        return new Mock<UserManager<TUser>>(
            store.Object,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null
        );
    }

    public static Mock<RoleManager<TRole>> MockRoleManager<TRole>() where TRole : class
    {
        var store = new Mock<IRoleStore<TRole>>();
        return new Mock<RoleManager<TRole>>(
            store.Object,
            null,
            null,
            null,
            null
        );
    }
}