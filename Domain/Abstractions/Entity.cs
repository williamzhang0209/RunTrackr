﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public abstract class Entity
{
	private readonly List<IDomainEvent> _domainEvents = new();

	protected Entity(Guid id)
	{
		Id= id;
	}

    protected Entity()
    {

    }

    public Guid Id { get; init; }

    public List<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected void Raise(IDomainEvent domainEvent)
	{ 
		_domainEvents.Add(domainEvent);
	}
}
