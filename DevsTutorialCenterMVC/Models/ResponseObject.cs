using System.Net;

namespace DevsTutorialCenterMVC.Models;

public class ResponseObject<T>
{
    public bool IsSuccessful { get; set; }
    public int Code { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public string Error { get; set; }
    public IEnumerable<Error> Errors { get; set; } = Array.Empty<Error>();
}


public class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Message { get; }
    public string Code { get; }

    public static readonly IEnumerable<Error> None = Array.Empty<Error>();
    public static readonly Error NullValue = new("Error.NullValue", "the specified result value is null.");
}