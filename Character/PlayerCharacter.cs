using DomainCore;
using RolePlayCore;

namespace GamePieces
{
    internal class PlayerCharacter : IPlayerCharacter, IGamePiece<PlayerCharacter>
    {
        public PlayerCharacter(CharacterType type, string name, DomainId<PlayerCharacter> id)
        {
            Type = type;
            Name = name;
            Id = id;
        }

        public CharacterType Type { get; }
        public string Name { get; }
        public DomainId<PlayerCharacter> Id { get; }
    }
}