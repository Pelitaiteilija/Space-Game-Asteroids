/// <summary>
/// Interface for GameEvent listeners that react when a subscribed event is raised
/// </summary>
public interface IGameEventListener
{
    /// <summary>
    /// Called when a subscribed event is raised
    /// </summary>
    void OnEventRaised();
}
