using RolePlayCore;

namespace GamePieces
{
    public class GamePieceDomain
    {
        private readonly CharacterFactory _characterFactory;
        private WeaponFactory _weaponFactory;

        public GamePieceDomain()
        {
            _characterFactory = new CharacterFactory();
            _weaponFactory = new WeaponFactory();
        }

        public IPlayerCharacter CreateCharacter(CharacterType type, string name)
        {
            return _characterFactory.CreateCharacter(type, name);
        }

        public IWeapon CreateWeapon(WeaponType type, string name)
        {
            return _weaponFactory.CreateWeapon(type, name);
        }
    }
}