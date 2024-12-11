namespace GigApp.Models;

public class Result
{
    internal Result(bool succeeded, string error)
    {
        Succeeded = succeeded;
        Error = error;
    }

    public bool Succeeded { get; init; }

    public string Error { get; init; }

    public static Result Success()
    {
        return new Result(true, String.Empty);
    }

    public static Result Failure(string error)
    {
        return new Result(false, error);
    }
}