namespace World404.Core
{
    using System;

    public interface IIdentifiable
    {
        Guid ID { get; }
    }
}