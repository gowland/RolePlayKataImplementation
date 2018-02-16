using System.Collections.Generic;
using System.Linq;
using RolePlayCore;

namespace GamePieces
{
    public class WeaponDomain
    {
        private readonly IList<Weapon> _weapons = new List<Weapon>();
        private int _weaponCounter;

        public IWeapon CreateWeapon(WeaponType type, string name)
        {
            if (_weapons.Any(character => character.Name == name))
            {
                return null;
            }

            var weapon = new Weapon(type, name, ++_weaponCounter);
            _weapons.Add(weapon);
            return weapon;
        }
    }

    public abstract class GamePieceFactory<T>
    {
        private readonly IList<Weapon> _weapons = new List<Weapon>();
        private int _weaponCounter;

        public IWeapon CreateWeapon(WeaponType type, string name)
        {
            if (_weapons.Any(character => character.Name == name))
            {
                return null;
            }

            var weapon = new Weapon(type, name, ++_weaponCounter);
            _weapons.Add(weapon);
            return weapon;
        }
    }
}