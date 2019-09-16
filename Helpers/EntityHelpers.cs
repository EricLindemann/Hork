using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hork_Api.Helpers
{
    public static class EntityHelpers
    {
        public static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, IAuditable
        {
            entity.Property(d => d.CreatedOn).ValueGeneratedOnAdd();
            entity.Property(d => d.UpdatedOn).ValueGeneratedOnAddOrUpdate();

            entity.Property(d => d.CreatedOn).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
            entity.Property(d => d.CreatedOn).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            entity.Property(d => d.UpdatedOn).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
            entity.Property(d => d.UpdatedOn).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

            return entity;
        }
        
    }
}