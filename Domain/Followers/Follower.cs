﻿using Domain.Abstractions;

namespace Domain.Followers;

public sealed class Follower : Entity
{
    private Follower(Guid userId, Guid followedId, DateTime createdOnUtc)
    {
        UserId= userId;
        FollowedId= followedId;
        CreatedOnUtc= createdOnUtc;
    }

    private Follower()
    { 
    }

    public Guid UserId { get; private set; }

    public Guid FollowedId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    //static factory method
    public static Follower Create(Guid userId, Guid followedId, DateTime createdOnUtc)
    {
        var follower = new Follower(userId, followedId, createdOnUtc);
        follower.Raise(new FollowerCreatedDomainEvent(follower.UserId, follower.FollowedId));

        return follower;
    }
}
