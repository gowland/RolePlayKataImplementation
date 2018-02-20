using System.Linq;
using RolePlayCore;

namespace GamePieces
{
    internal class MonsterFactory : GamePieceDomainBase<Monster>
    {
        public IMonster CreateNamedMonster(MonsterType type, string name)
        {
            if (Items.Any(monster => monster.Name == name))
            {
                return null;
            }

            var namedMonster = new Monster(type, name, GetNewId());
            Add(namedMonster);
            return namedMonster;
        }
    }
}