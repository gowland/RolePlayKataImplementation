using RolePlayCore;

namespace RolePlayRules
{
    public class WeaponAssignmentRule
    {
        public WeaponAssignmentRule(CharacterType characterType, WeaponType weaponType)
        {
            CharacterType = characterType;
            WeaponType = weaponType;
        }

        public CharacterType CharacterType { get; }
        public WeaponType WeaponType { get; }
    }
}