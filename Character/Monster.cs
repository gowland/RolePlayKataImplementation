using DomainCore;
using RolePlayCore;

namespace GamePieces
{
    internal class Monster : IMonster, IGamePiece<Monster>
    {
        public Monster(MonsterType type, string name, DomainId<Monster> id)
        {
            Type = type;
            Name = name;
            Id = id;
        }

        public MonsterType Type { get; }
        public string Name { get; }
        public DomainId<Monster> Id { get; }
    }
}