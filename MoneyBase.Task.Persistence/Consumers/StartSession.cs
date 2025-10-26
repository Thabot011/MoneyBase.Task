namespace MoneyBase.Persistence.Consumers
{
    public record StartSessionCommand(Guid ChatId);
    public record StartSessionResult(Guid ChatId, bool IsAssigned);
}
