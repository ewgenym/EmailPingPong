namespace EmailPingPong.Core.Events
{
	public interface IEventPublisher
	{
		void Publish<T>(T @event) where T : IDomainEvent;
	}
}