using DomainCore;
using RolePlayCore;

namespace GamePieces
{
    internal class PlayerCharacter : IPlayerCharacter, IGamePiece<PlayerCharacter>
    {
        public PlayerCharacter(CharacterType type, string name, int id)
        {
            Type = type;
            Name = name;
            Id = new DomainId<PlayerCharacter>(id);
        }

        public CharacterType Type { get; }
        public string Name { get; }
        public DomainId<PlayerCharacter> Id { get; }
    }
}