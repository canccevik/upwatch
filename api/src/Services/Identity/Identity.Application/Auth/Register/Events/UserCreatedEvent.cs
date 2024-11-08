namespace Identity.Application.Auth.Register.Events;

public class UserCreatedEvent
{
    public Guid Id { get; set; }
    public string Email { get; set; }
}
