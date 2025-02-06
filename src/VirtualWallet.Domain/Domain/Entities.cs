using System;
using System.Collections.Generic;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Domain.Domain;

public interface ITxRequest
{
}

public interface IAggregateRoot
{
}

public abstract class RootBaseModel : BaseEntity, IAggregateRoot
{
    public HashSet<EventBase> DomainEvents { get; private set; }
}