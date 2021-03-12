public interface IOnUpdate {
    void OnUpdate();
    float TimeSinceUpdating { get; set; }
    bool RemoveThisFromUpdater { get; set; }
}