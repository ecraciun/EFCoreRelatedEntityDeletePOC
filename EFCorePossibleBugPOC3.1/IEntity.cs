﻿namespace EFCorePossibleBugPOC3._1
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IEntityWithChild : IEntity
    {
        int? MiddleId { get; set; }
        Middle Middle { get; set; }
    }
}