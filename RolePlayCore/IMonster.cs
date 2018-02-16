namespace RolePlayCore
{
    public interface IMonster
    {
        MonsterType Type { get; }
        string Name { get; }
    }
}