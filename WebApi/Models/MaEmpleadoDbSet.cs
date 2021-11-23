using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Models;

namespace WebApi.Models
{
    public class MaEmpleadoDbSet : DbSet<MaEmpleado>
    {
        public MaEmpleadoDbSet()
            :base()
        {
            Console.WriteLine($"{nameof(MaEmpleadoDbSet)}");
        }


        public override ValueTask<EntityEntry<MaEmpleado>> AddAsync(MaEmpleado entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override void AddRange(IEnumerable<MaEmpleado> entities)
        {
            base.AddRange(entities);
        }

        public override void AddRange(params MaEmpleado[] entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(IEnumerable<MaEmpleado> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override Task AddRangeAsync(params MaEmpleado[] entities)
        {
            return base.AddRangeAsync(entities);
        }

        public override IAsyncEnumerable<MaEmpleado> AsAsyncEnumerable()
        {
            return base.AsAsyncEnumerable();
        }

        public override IQueryable<MaEmpleado> AsQueryable()
        {
            return base.AsQueryable();
        }

        public override EntityEntry<MaEmpleado> Attach(MaEmpleado entity)
        {
            return base.Attach(entity);
        }

        public override void AttachRange(IEnumerable<MaEmpleado> entities)
        {
            base.AttachRange(entities);
        }

        public override void AttachRange(params MaEmpleado[] entities)
        {
            base.AttachRange(entities);
        }

        public override IEntityType EntityType => base.EntityType;

        public override MaEmpleado Find(params object[] keyValues)
        {
            return base.Find(keyValues);
        }

        public override ValueTask<MaEmpleado> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return base.FindAsync(keyValues, cancellationToken);
        }

        public override ValueTask<MaEmpleado> FindAsync(params object[] keyValues)
        {
            return base.FindAsync(keyValues);
        }

        public override EntityEntry<MaEmpleado> Remove(MaEmpleado entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<MaEmpleado> entities)
        {
            base.RemoveRange(entities);
        }

        public override void RemoveRange(params MaEmpleado[] entities)
        {
            base.RemoveRange(entities);
        }

        public override EntityEntry<MaEmpleado> Update(MaEmpleado entity)
        {
            return base.Update(entity);
        }

        public override void UpdateRange(IEnumerable<MaEmpleado> entities)
        {
            base.UpdateRange(entities);
        }

        public override void UpdateRange(params MaEmpleado[] entities)
        {
            base.UpdateRange(entities);
        }

        public override LocalView<MaEmpleado> Local => base.Local;

        public override EntityEntry<MaEmpleado> Add(MaEmpleado entity)
        {
            return base.Add(entity);
        }
    }
}
