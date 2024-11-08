using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UpWatch.EntityFramework;

public static class ModelBuilderExtensions
{
    public static void ApplyGlobalSoftDeleteFilter(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            var isDeletedProperty = clrType.GetProperty("IsDeleted");

            if (isDeletedProperty == null || isDeletedProperty.PropertyType != typeof(bool)) continue;
            
            var parameter = Expression.Parameter(clrType, "e");
            var property = Expression.Property(parameter, "IsDeleted");
            var condition = Expression.Not(property);
            var lambda = Expression.Lambda(condition, parameter);

            entityType.SetQueryFilter(lambda);
        }
    }
}
