using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combat;
using GamePieces;
using RolePlayCore;
using RolePlayRules;

namespace RolePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamePieceDomain = new GamePieceDomain();

            IPlayerCharacter warrior = gamePieceDomain.CreateCharacter(CharacterType.Warrior, "Buddy the Warrior");
            IPlayerCharacter wizard = gamePieceDomain.CreateCharacter(CharacterType.Wizard, "Ed the Wizard");
            IPlayerCharacter whiteWizard = gamePieceDomain.CreateCharacter(CharacterType.WhiteWizard, "The Wonderous Whitey");

            IWeapon sword = gamePieceDomain.CreateWeapon(WeaponType.Sword, "Sword of Might");
            IWeapon sword2 = gamePieceDomain.CreateWeapon(WeaponType.Sword, "Sword of the Magi");
            IWeapon staff = gamePieceDomain.CreateWeapon(WeaponType.Staff, "Cudgel of Shame");
            IWeapon dagger = gamePieceDomain.CreateWeapon(WeaponType.Daggger, "Dagger of Dagging");
            IWeapon dagger2 = gamePieceDomain.CreateWeapon(WeaponType.Daggger, "Shiv of Shadows");

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
            Console.WriteLine();

            IMonster dracula = gamePieceDomain.CreateNamedMonster(MonsterType.Vampire, "Dracula");
            IMonster wolfy = gamePieceDomain.CreateNamedMonster(MonsterType.Werewolf, "Wolfy McWolf");

            var combatDomain = new CombatDomain();
            Attack(warrior, dracula, combatDomain, LocationType.HolyGround);
            Attack(warrior, dracula, combatDomain, LocationType.Town);
            Attack(warrior, dracula, combatDomain, LocationType.Woods);
            Attack(warrior, wolfy, combatDomain, LocationType.HolyGround);
            Attack(warrior, wolfy, combatDomain, LocationType.Town);
            Attack(warrior, wolfy, combatDomain, LocationType.Woods);
            Attack(wizard, dracula, combatDomain, LocationType.HolyGround);
            Attack(wizard, dracula, combatDomain, LocationType.Town);
            Attack(wizard, dracula, combatDomain, LocationType.Woods);
            Attack(wizard, wolfy, combatDomain, LocationType.HolyGround);
            Attack(wizard, wolfy, combatDomain, LocationType.Town);
            Attack(wizard, wolfy, combatDomain, LocationType.Woods);
            Attack(whiteWizard, dracula, combatDomain, LocationType.HolyGround);
            Attack(whiteWizard, dracula, combatDomain, LocationType.Town);
            Attack(whiteWizard, dracula, combatDomain, LocationType.Woods);
            Attack(whiteWizard, wolfy, combatDomain, LocationType.HolyGround);
            Attack(whiteWizard, wolfy, combatDomain, LocationType.Town);
            Attack(whiteWizard, wolfy, combatDomain, LocationType.Woods);
            Console.ReadKey();
        }

        private static void Attack(IPlayerCharacter playerCharacter, IMonster monster, CombatDomain combatDomain, LocationType locationType)
        {
            Console.WriteLine("{0} [{1}] attacks {2} [{3}] at {4}", playerCharacter.Name, playerCharacter.Type, monster.Name, monster.Type, locationType,
                combatDomain.GetChanceOfAttack(playerCharacter, monster, locationType));
            Console.WriteLine("Odds: {0:P0}", combatDomain.GetChanceOfAttack(playerCharacter, monster, locationType));
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
