using DomainCore;

namespace GamePieces
{
    internal interface IGamePiece<T>
    {
        DomainId<T> Id { get; }
    }
}