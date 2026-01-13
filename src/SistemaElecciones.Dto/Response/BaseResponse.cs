namespace SistemaElecciones.Dto.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}

public class ResponseBase<T> : BaseResponse
{
    public T? Data { get; set; }
}

public class BadRequestResponse
{
    public string Type { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Status { get; set; }
    public string Traceid { get; set; } = null!;
}
