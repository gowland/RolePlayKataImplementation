using RolePlayCore;

namespace GamePieces
{
    public class GamePieceDomain
    {
        private readonly CharacterFactory _characterFactory;
        private readonly WeaponFactory _weaponFactory;
        private readonly MonsterFactory _monsterFactory;

        public GamePieceDomain()
        {
            _characterFactory = new CharacterFactory();
            _weaponFactory = new WeaponFactory();
            _monsterFactory = new MonsterFactory();
        }

        public IPlayerCharacter CreateCharacter(CharacterType type, string name)
        {
            return _characterFactory.CreateCharacter(type, name);
        }

        public IWeapon CreateWeapon(WeaponType type, string name)
        {
            return _weaponFactory.CreateWeapon(type, name);
        }

        public IMonster CreateNamedMonster(MonsterType type, string name)
        {
            return _monsterFactory.CreateNamedMonster(type, name);
        }
    }
}