using System.Collections.Generic;
using System.Linq;
using RolePlayCore;

namespace GamePieces
{
    internal class WeaponFactory : GamePieceDomainBase<Weapon>
    {
        public IWeapon CreateWeapon(WeaponType type, string name)
        {
            if (Items.Any(character => character.Name == name))
            {
                return null;
            }

            var weapon = new Weapon(type, name, GetNewId());
            Add(weapon);
            return weapon;
        }
    }
}