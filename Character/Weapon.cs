using DomainCore;
using RolePlayCore;

namespace GamePieces
{
    internal class Weapon : IWeapon, IGamePiece<Weapon>
    {
        public Weapon(WeaponType type, string name, int id)
        {
            Type = type;
            Name = name;
            Id = new DomainId<Weapon>(id);
        }

        public WeaponType Type { get; }
        public string Name { get; }
        public DomainId<Weapon> Id { get; }
    }
}