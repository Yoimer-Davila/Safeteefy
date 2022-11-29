namespace Safeteefy.API.Shared.Domain.Services.Communication;

public class Response<TEntity>
{
    protected Response(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    protected Response(TEntity resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public TEntity Resource { get; set; }

    public static Response<TEntity> Of(string message)
    {
        return new Response<TEntity>(message);
    }
    public static Response<TEntity> Of(TEntity entity)
    {
        return new Response<TEntity>(entity);
    }
}