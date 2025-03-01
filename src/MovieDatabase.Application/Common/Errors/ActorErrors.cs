namespace MovieDatabase.Application.Common.Errors;

public static class ActorErrors
{
    public static Error NotFound(Guid actorId) => new(
        "404",
        $"Actor with ID {actorId} not found.");

    public static readonly Error CreationFailed = new(
        "400",
        "An error occurred while creating the actor.");

    public static readonly Error DeletionFailed = new(
        "400",
        "An error occurred while deleting the actor.");

    public static readonly Error UpdateFailed = new(
        "400",
        "An error occurred while updating the actor.");
}
