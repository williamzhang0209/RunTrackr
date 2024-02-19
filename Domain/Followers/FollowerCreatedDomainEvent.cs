using Domain.Abstractions;

namespace Domain.Followers;

public sealed record FollowerCreatedDomainEvent(Guid userId, Guid followedId) : IDomainEvent;
