using System.Collections.Generic;
using System.Linq;
using RolePlayCore;

namespace GamePieces
{
    public class CharacterDomain
    {
        private readonly IList<PlayerCharacter> _characters = new List<PlayerCharacter>();
        private int _counter;

        public IPlayerCharacter CreateCharacter(CharacterType type, string name)
        {
            if (_characters.Any(character => character.Name == name))
            {
                return null;
            }

            var playerCharacter = new PlayerCharacter(type, name, ++_counter);
            _characters.Add(playerCharacter);
            return playerCharacter;
        }
    }

    public abstract class GamePieceDomainBase<T>
    {
        private readonly IList<T> _characters = new List<T>();
        private int _counter;

        public IPlayerCharacter CreateCharacter(CharacterType type, string name)
        {
            if (_characters.Any(character => character.Name == name))
            {
                return null;
            }

            var playerCharacter = new PlayerCharacter(type, name, ++_counter);
            _characters.Add(playerCharacter);
            return playerCharacter;
        }
    }
}