namespace Domain.Followers;

public interface IFollowerRepository
{
    Task<bool> IsAlreadyFolowingAsync(Guid userId, Guid followedId, CancellationToken cancellationToken);

    //insert new follower
    void Insert(Follower follower);
}
