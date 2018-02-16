namespace RolePlayCore
{
    public interface IPlayerCharacter
    {
        CharacterType Type { get; }
        string Name { get; }
    }
}