using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RolePlayCore;

namespace RolePlayRules
{
    public class InventoryDomain
    {
        private readonly IList<WeaponAssignment> _weaponAssignments = new List<WeaponAssignment>();
        private readonly IEnumerable<WeaponAssignmentRule> _weaponAssignmentRules;

        public InventoryDomain()
        {
            _weaponAssignmentRules = new List<WeaponAssignmentRule>()
            {
                new WeaponAssignmentRule(CharacterType.Warrior, WeaponType.Sword),
                new WeaponAssignmentRule(CharacterType.Warrior, WeaponType.Daggger),
                new WeaponAssignmentRule(CharacterType.Wizard, WeaponType.Staff),
                new WeaponAssignmentRule(CharacterType.Wizard, WeaponType.Daggger),
                new WeaponAssignmentRule(CharacterType.WhiteWizard, WeaponType.Sword),
                new WeaponAssignmentRule(CharacterType.WhiteWizard, WeaponType.Staff),
                new WeaponAssignmentRule(CharacterType.WhiteWizard, WeaponType.Daggger),
            };
        }

        public WeaponAssignmentResult AssignWeapon(IPlayerCharacter character, IWeapon weapon)
        {
            if (_weaponAssignments.Any(rule => rule.Character == character && rule.Weapon == weapon))
            {
                return new WeaponAssignmentResult("This character already has this weapon");
            }

            if (_weaponAssignments.Any(rule => rule.Weapon == weapon))
            {
                return new WeaponAssignmentResult("Another character already has this weapon");
            }

            if (_weaponAssignmentRules.Any(rule =>
                rule.CharacterType == character.Type && rule.WeaponType == weapon.Type))
            {
                _weaponAssignments.Add(new WeaponAssignment(character, weapon));
                return WeaponAssignmentResult.Success;
            }

            else
            {
                return new WeaponAssignmentResult("Character may not carry this weapon");
            }
        }
    }
}
