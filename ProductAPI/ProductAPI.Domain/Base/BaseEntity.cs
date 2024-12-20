﻿namespace ProductAPI.Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        protected void UpdateTimestamp()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}