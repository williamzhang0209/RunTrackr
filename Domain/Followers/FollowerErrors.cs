using Domain.Abstractions;

namespace Domain.Followers;

public static class FollowerErrors
{
    public static readonly Error Sameuser = new Error("Followers.Sameuser", "Can't follow yourself");
    public static readonly Error AlreadyFollowing = new Error("Followers.AlreadyFollowing", "AlreadyFollowing");

}