using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePieces;
using RolePlayCore;
using RolePlayRules;

namespace RolePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var characterDomain = new CharacterDomain();
            var warrior = characterDomain.CreateCharacter(CharacterType.Warrior, "Buddy the Warrior");
            var wizard = characterDomain.CreateCharacter(CharacterType.Wizard, "Ed the Wizard");
            var whiteWizard = characterDomain.CreateCharacter(CharacterType.WhiteWizard, "The Wonderous Whitey");

            var weaponsDomain = new WeaponDomain();
            var sword = weaponsDomain.CreateWeapon(WeaponType.Sword, "Sword of Might");
            var sword2 = weaponsDomain.CreateWeapon(WeaponType.Sword, "Sword of the Magi");
            var staff = weaponsDomain.CreateWeapon(WeaponType.Staff, "Cudgel of Shame");
            var dagger = weaponsDomain.CreateWeapon(WeaponType.Daggger, "Dagger of Dagging");
            var dagger2 = weaponsDomain.CreateWeapon(WeaponType.Daggger, "Shiv of Shadows");

            var inventoryDomain = new InventoryDomain();
            PickUpWeapon(inventoryDomain, warrior, sword);
            PickUpWeapon(inventoryDomain, warrior, sword);
            PickUpWeapon(inventoryDomain, warrior, staff);
            PickUpWeapon(inventoryDomain, warrior, dagger);
            PickUpWeapon(inventoryDomain, wizard, staff);
            PickUpWeapon(inventoryDomain, wizard, sword2);
            PickUpWeapon(inventoryDomain, wizard, dagger);
            PickUpWeapon(inventoryDomain, wizard, dagger2);
            PickUpWeapon(inventoryDomain, whiteWizard, sword2);
            Console.ReadKey();
        }

        private static void PickUpWeapon(InventoryDomain inventoryDomain, IPlayerCharacter character, IWeapon weapon)
        {
            Console.WriteLine("{0} [{1}] attempts to pick up {2} [{3}]", character.Name, character.Type, weapon.Name, weapon.Type);
            WeaponAssignmentResult result = inventoryDomain.AssignWeapon(character, weapon);
            if (result.IsSuccess)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed: {0}", result.Message);
            }
        }
    }
}
