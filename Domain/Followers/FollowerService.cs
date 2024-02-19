using Domain.Abstractions;
using Domain.Users;

namespace Domain.Followers;

public sealed class FollowerService
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }

    public async Task<Result> StartFollowing(
        User user,
        User followed,
        DateTime createdOnUtc,
        CancellationToken cancellationToken)
    {
        //validate the user and follower
        if (user.Id == followed.Id)
        {
            return Result.Failure(FollowerErrors.Sameuser);
        }

        if (await _followerRepository.IsAlreadyFolowingAsync(user.Id, followed.Id, cancellationToken))
        {
            //throw new Exception($"Already Following {followed.Id}");
            //return $"Already Following {followed.Id}";
            //return new Error("Followers.AlreadyFollowing", $"Already Following {followed.Id}");
            return Result.Failure(FollowerErrors.AlreadyFollowing);

        }

        //create folower
        var follower = Follower.Create(user.Id, followed.Id, createdOnUtc);
        _followerRepository.Insert(follower);

        return Result.Success();
       
    }

    //public async Task<Error> StartFollowing(
    //    User user, 
    //    User followed, 
    //    DateTime createdOnUtc, 
    //    CancellationToken cancellationToken)
    //{
    //    //validate the user and follower
    //    if (user.Id == followed.Id)
    //    {
    //        //throw new Exception("Can't follow yourself");
    //        //return "Can't follow yourself";

    //        //return new Error("Followers.Sameuser", "Can't follow yourself");
    //        return FollowerErrors.Sameuser;
    //    }

    //    //if (!followed.HasPublicProfile)
    //    //{
    //    //    throw new Exception("Can't follow non public profile");
    //    //}
    //    //check if not following
    //    if (await _followerRepository.IsAlreadyFolowingAsync(user.Id, followed.Id, cancellationToken))
    //    {
    //        //throw new Exception($"Already Following {followed.Id}");
    //        //return $"Already Following {followed.Id}";
    //        //return new Error("Followers.AlreadyFollowing", $"Already Following {followed.Id}");
    //        return FollowerErrors.AlreadyFollowing;

    //    }

    //    //create folower
    //    var follower = Follower.Create(user.Id, followed.Id, createdOnUtc);
    //    _followerRepository.Insert(follower);

    //    //return string.Empty;
    //    return Error.None;
    //    //send notification. Move to domain events
    //}
}
