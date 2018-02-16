using System;
using RolePlayCore;

namespace Combat
{
    public class CombatDomain
    {
        public double GetChanceOfAttack(IPlayerCharacter character, IMonster monster, LocationType locationType)
        {
            return 0.5;
        }
    }
}
