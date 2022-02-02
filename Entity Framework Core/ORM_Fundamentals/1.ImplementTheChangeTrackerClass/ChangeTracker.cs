using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;

namespace _1.ImplementTheChangeTrackerClass
{
    internal class ChangeTracker<T>
        where T: class , new()
    {
        private readonly List<T> allEntities;

        private readonly List<T> added;

        private readonly List<T> remove;
        public ChangeTracker(IEnumerable<T> entities)
        {
            added = new List<T>();
            remove = new List<T>();
            allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => remove.AsReadOnly();

        public void Add(T item) => added.Add(item);
        public void Remove(T item) => remove.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            List<T> modifitedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties().Where(x => x.HasAttribute<KeyAttribute>()).ToArray();

            foreach (var proxyEntity in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifitedEntities.Add(entity);
                }
            }
            return modifitedEntities;
        }

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new List<T>();

            var proprtiesToClone = typeof(T).GetProperties().Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType)).ToArray();
            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();
                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        private static bool IsModified(T entity , T proxyEntity)
        {
            var monitoredProperties = typeof(T).GetProperties().Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType));

            var modifiedProperties = monitoredProperties.Where(x => !Equals(x.GetValue(entity), x.GetValue(proxyEntity))).ToArray();

            var isModified = monitoredProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primeyKeys, T entity)
        {
            return primeyKeys.Select(x => x.GetValue(entity));
        }
    }
}
