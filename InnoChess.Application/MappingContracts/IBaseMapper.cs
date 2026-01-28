namespace InnoChess.Application.MappingContracts;

public interface IBaseMapper<in TRequest, out TResponse, TEntity>
{
    public TEntity FromRequestToEntity(TRequest request);
    public TResponse FromEntityToResponse(TEntity entity);
}