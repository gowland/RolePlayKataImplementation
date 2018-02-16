using System.Linq;
using RolePlayCore;

namespace GamePieces
{
    internal class CharacterFactory : GamePieceDomainBase<PlayerCharacter>
    {
        public IPlayerCharacter CreateCharacter(CharacterType type, string name)
        {
            if (Items.Any(character => character.Name == name))
            {
                return null;
            }

            var playerCharacter = new PlayerCharacter(type, name, GetNewId());

            Add(playerCharacter);

            return playerCharacter;
        }
    }
}