namespace RolePlayCore
{
    public interface IWeapon
    {
        WeaponType Type { get; }
        string Name { get; }
    }
}