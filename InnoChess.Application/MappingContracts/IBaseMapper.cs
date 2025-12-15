namespace InnoChess.Application.MappingContracts;

public interface IBaseMapper<TRequest, TResponse, TEntity>
{
    public TEntity FromRequestToEntity(TRequest request);
    public TEntity FromResponseToEntity(TResponse response);
    public TRequest FromEntityToRequest(TEntity entity);
    public TResponse FromEntityToResponse(TEntity entity);
}