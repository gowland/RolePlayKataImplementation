using DomainCore;
using RolePlayCore;

namespace GamePieces
{
    internal class Weapon : IWeapon, IGamePiece<Weapon>
    {
        public Weapon(WeaponType type, string name, DomainId<Weapon> id)
        {
            Type = type;
            Name = name;
            Id = id;
        }

        public WeaponType Type { get; }
        public string Name { get; }
        public DomainId<Weapon> Id { get; }
    }
}