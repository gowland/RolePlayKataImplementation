using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RolePlayCore;

namespace Combat
{
    public class CombatDomain
    {
        private readonly IList<ChanceOfAttackRule> rules = new List<ChanceOfAttackRule>();

        public CombatDomain()
        {
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Warrior, MonsterType.Vampire, null), 0.3));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Wizard, MonsterType.Vampire, null), 0.3));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.WhiteWizard, MonsterType.Vampire, null), 0.35));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Warrior, MonsterType.Vampire, LocationType.HolyGround), 0.95));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Wizard, MonsterType.Vampire, LocationType.HolyGround), 0.95));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.WhiteWizard, MonsterType.Vampire, LocationType.HolyGround), 1.0));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Warrior, MonsterType.Werewolf, null), 0.8));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Warrior, MonsterType.Werewolf, LocationType.Woods), 0.2));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.Wizard, MonsterType.Werewolf, null), 0.3));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.WhiteWizard, MonsterType.Werewolf, null), 0.35));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(CharacterType.WhiteWizard, null, null), 0.55));
            rules.Add(new ChanceOfAttackRule(new ChanceOfAttackCondition(null, null, null), 0.5));
        }

        public double GetChanceOfAttack(IPlayerCharacter character, IMonster monster, LocationType locationType)
        {
            var matchingRules = rules
                .Where(rule => rule.IsMatch(character.Type, monster.Type, locationType))
                .ToList();

            matchingRules.Sort();
            matchingRules.Reverse();

            return matchingRules.First().ChanceOfAttack;
        }

        private class ChanceOfAttackRule : IComparable<ChanceOfAttackRule>
        {
            public ChanceOfAttackRule(ChanceOfAttackCondition condition, double chanceOfAttack)
            {
                Condition = condition;
                ChanceOfAttack = chanceOfAttack;
            }

            public bool IsMatch(CharacterType characterType, MonsterType monsterType, LocationType locationType)
            {
                return Condition.IsMatch(characterType, monsterType, locationType);
            }

            public double ChanceOfAttack { get; }
            public ChanceOfAttackCondition Condition { get; }
            public int CompareTo(ChanceOfAttackRule other)
            {
                return Condition.CompareTo(other.Condition);
            }
        }

        private class ChanceOfAttackCondition : IComparable<ChanceOfAttackCondition>
        {
            public ChanceOfAttackCondition(CharacterType? characterType, MonsterType? monsterType, LocationType? locationType)
            {
                CharacterType = characterType;
                MonsterType = monsterType;
                LocationType = locationType;
            }

            public CharacterType? CharacterType { get; }
            public MonsterType? MonsterType { get; }
            public LocationType? LocationType { get; }

            public bool IsMatch(CharacterType characterType, MonsterType monsterType, LocationType locationType)
            {
                return IsMatchOrMineIsNull(characterType, CharacterType)
                       && IsMatchOrMineIsNull(monsterType, MonsterType)
                       && IsMatchOrMineIsNull(locationType, LocationType);
            }

            private bool IsMatchOrMineIsNull<T>(T theirs, T? mine) where T : struct
            {
                return !mine.HasValue || theirs.Equals(mine.Value);
            }

            public int CompareTo(ChanceOfAttackCondition other)
            {
                if (CompareTo(LocationType, other.LocationType, out int compareTo1)) return compareTo1;
                if (CompareTo(CharacterType, other.CharacterType, out int compareTo2)) return compareTo2;
                if (CompareTo(MonsterType, other.MonsterType, out int compareTo3)) return compareTo3;

                return 0;
            }

            private bool CompareTo<T>(T? mine, T? theirs, out int compareTo) where  T: struct 
            {
                if (mine.HasValue && !theirs.HasValue)
                {
                    {
                        compareTo = 1;
                        return true;
                    }
                }

                if (!mine.HasValue && theirs.HasValue)
                {
                    {
                        compareTo = -1;
                        return true;
                    }
                }

                compareTo = 0;
                return false;
            }
        }
    }
}
