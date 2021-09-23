using Infrastructure;
using Infrastructure.SortFiltering;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.InfrastructureRepository
{
    public abstract class NHCrudRepository<TEntity> : NHRepository, ICrudRepository<TEntity>
     where TEntity : Entity
    {
        //private readonly NHUnitOfWork unitOfWork;
        //public NHUnitOfWork NHUnitOfWork { get { return unitOfWork; } }

        //public NHCrudRepository(IUnitOfWork unitOfWork)
        //{
        //  Guard.That(unitOfWork).IsNotNull();

        //  this.unitOfWork = unitOfWork as NHUnitOfWork;
        //  Guard.That(this.unitOfWork).IsNotNull();
        //}

        public NHCrudRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> specification)
        {
            return NHUnitOfWork.Session.Query<TEntity>()
              .Where(specification);
        }

        public IEnumerable<TEntity> GetList()
        {
            return unitOfWork.Session.QueryOver<TEntity>().List();
        }

        public IEnumerable<TEntity> GetList(
          out int countAll,
          int skip,
          int limit,
          IEnumerable<SortItem> sort = null)
        {
            var entityList = unitOfWork.Session.QueryOver<TEntity>();
            countAll = entityList.RowCount();

            if (sort != null && sort.Count() > 0)
            {
                foreach (var sortItem in sort)
                    entityList.UnderlyingCriteria.AddOrder(new Order(sortItem.Property, sortItem.Direction == SortDirection.ASC));
            }
            else
                entityList.UnderlyingCriteria.AddOrder(new Order("Id", true));

            entityList.Skip(skip).Take(limit);

            return entityList.List();
        }

        public IEnumerable<TEntity> GetFilteredList(
          out int countAll,
          int? skip = null,
          int? limit = null,
          IEnumerable<FilterItem> filter = null,
          IEnumerable<SortItem> sort = null)
        {
            var entityList = unitOfWork.Session.QueryOver<TEntity>();

            if (sort != null && sort.Count() > 0)
            {
                foreach (var sortItem in sort)
                    entityList.UnderlyingCriteria.AddOrder(new Order(sortItem.Property, sortItem.Direction == SortDirection.ASC));
            }
            else
                entityList.UnderlyingCriteria.AddOrder(new Order("Id", true));

            if (filter != null)
            {
                foreach (var propertyFilter in filter)
                {
                    if (propertyFilter.Value == null
                      || (propertyFilter.Value != null && propertyFilter.Value is string && String.IsNullOrEmpty(propertyFilter.Value.ToString())))
                        continue;

                    switch (propertyFilter.Operator)
                    {
                        case FilterOperator.Eq:
                            entityList = entityList.Where(Restrictions.Eq(propertyFilter.Property, propertyFilter.Value));
                            break;
                        case FilterOperator.Like:
                            entityList = entityList.Where(Restrictions.Like(propertyFilter.Property, propertyFilter.Value.ToString(), MatchMode.Start));
                            break;
                        case FilterOperator.Lt:
                            entityList = entityList.Where(Restrictions.Lt(propertyFilter.Property, propertyFilter.Value));
                            break;
                        case FilterOperator.Gt:
                            entityList = entityList.Where(Restrictions.Gt(propertyFilter.Property, propertyFilter.Value));
                            break;
                        case FilterOperator.Lte:
                            entityList = entityList.Where(Restrictions.Le(propertyFilter.Property, propertyFilter.Value));
                            break;
                        case FilterOperator.Gte:
                            entityList = entityList.Where(Restrictions.Ge(propertyFilter.Property, propertyFilter.Value));
                            break;
                        case FilterOperator.Null:
                            entityList = entityList.Where(Restrictions.IsNull(propertyFilter.Property));
                            break;
                        case FilterOperator.NotNull:
                            entityList = entityList.Where(Restrictions.IsNotNull(propertyFilter.Property));
                            break;
                        case FilterOperator.In:
                            if (propertyFilter.Value != null)
                                entityList = entityList.Where(Restrictions.In(propertyFilter.Property, propertyFilter.Value.ToString().Split(',')));
                            break;
                        default:
                            throw new Exception("Not supported filter operator");
                    }
                }
            }

            countAll = entityList.RowCount();

            if (skip.HasValue && limit.HasValue)
                entityList.Skip(skip.Value).Take(limit.Value);

            return entityList.List();
        }

        public TEntity Get(Guid id)
        {
            return unitOfWork.Session.Get<TEntity>(id);
        }

        public TEntity Load(Guid id)
        {
            return unitOfWork.Session.Load<TEntity>(id);
        }

        public Guid Add(TEntity entity)
        {
            //return (Guid)unitOfWork.Session.Save(entity);
            unitOfWork.Session.Persist(entity);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            unitOfWork.Session./*SaveOr*/Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = unitOfWork.Session.Load<TEntity>(id);
            unitOfWork.Session.Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            unitOfWork.Session.Delete(entity);
        }

        public bool Exists(Guid id)
        {
            return unitOfWork.Session.Query<TEntity>()
              .Where(e => e.Id == id)
              .Count() > 0;
        }
    }
}
