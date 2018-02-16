using RolePlayCore;

namespace RolePlayRules
{
    public class WeaponAssignment
    {
        public WeaponAssignment(IPlayerCharacter character, IWeapon weapon)
        {
            Character = character;
            Weapon = weapon;
        }

        public IPlayerCharacter Character { get; }
        public IWeapon Weapon { get; }
    }
}