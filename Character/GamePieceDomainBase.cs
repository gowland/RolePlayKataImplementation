using System.Collections.Generic;
using DomainCore;

namespace GamePieces
{
    public abstract class GamePieceDomainBase<T>
    {
        private readonly IList<T> _characters = new List<T>();
        private int _counter;

        public DomainId<T> GetNewId()
        {
            return new DomainId<T>(++_counter);
        }

        public void Add(T newItem)
        {
            _characters.Add(newItem);
        }

        public IEnumerable<T> Items => _characters;
    }
}