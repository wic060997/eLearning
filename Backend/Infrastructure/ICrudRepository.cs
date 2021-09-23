using Infrastructure.SortFiltering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface ICrudRepository<TEntity> : IRepository
        where TEntity : Entity
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> specification);

        /// <summary>
        /// Pobiera listę wszystkich obiektów.
        /// </summary>
        /// <returns>Lista obiektów</returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// Pobiera stronicowaną listę obiektów z opcjonalnym filtrowaniem i sortowaniem.
        /// </summary>
        /// <param name="countAll">Ilość wszystkich obiektów</param>
        /// <param name="skip">Ile pominąć rekordów</param>
        /// <param name="limit">Rozmiar strony</param>
        /// <param name="sort">Sortowanie</param>
        /// <returns>Lista obiektów</returns>
        IEnumerable<TEntity> GetList(
          out int countAll,
          int skip,
          int limit,
          IEnumerable<SortItem> sort = null
        );

        /// <summary>
        /// Pobiera obiekty według zadanego filtra z ewentualnym sortowaniem elementów.
        /// </summary>
        /// <param name="countAll">Ilość wszystkich obiektów</param>
        /// <param name="skip">Ile pominąć rekordów</param>
        /// <param name="limit">Rozmiar strony</param>
        /// <param name="filter">Kryteria</param>
        /// <param name="sort">Sortowanie</param>
        /// <returns>Lista encji domenowych</returns>
        IEnumerable<TEntity> GetFilteredList(
          out int countAll,
          int? skip = null,
          int? limit = null,
          IEnumerable<FilterItem> filter = null,
          IEnumerable<SortItem> sort = null);

        /// <summary>
        /// Pobiera encję domenową po wskazanym identyfikatorze wykonując pełne załadowanie z warstwy danych.
        /// </summary>
        /// <param name="id">Identyfikator obiektu</param>
        /// <returns>Encja domenowa</returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Pobiera referencję (obiekt proxy) do encji domenowej po wskazanym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator obiektu</param>
        /// <returns>Encja domenowa</returns>
        TEntity Load(Guid id);

        /// <summary>
        /// Dodaje encję domenową.
        /// </summary>
        /// <param name="entity">Encja domenowa</param>
        /// <returns>Identyfikator dodanej encji domenowej</returns>
        Guid Add(TEntity entity);

        /// <summary>
        /// Zapisuje zamiany na istniejącej encji domenowej.
        /// </summary>
        /// <param name="entity">Encja domenowa</param>
        void Update(TEntity entity);

        /// <summary>
        /// Usuwa encję domenową po wskazanym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator obiektu</param>
        void Delete(Guid id);

        /// <summary>
        /// Usuwa przekazaną encję domenową.
        /// </summary>
        /// <param name="entity">Encja domenowa</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Sprawdza czyencja o podanym identyfikatorze istnieje.
        /// </summary>
        /// <param name="id">Identyfikator obiektu</param>
        /// <returns>True oznacza, że obiekt istnieje</returns>
        bool Exists(Guid id);
    }
}
