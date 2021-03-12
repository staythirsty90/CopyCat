public class UIGrowOnGameInitialzed : UIGrow, IOnGameInitialized, IOnUpdate {
    public void OnGameInitialized() {
        CopyCat.Updater.AddToUpdate(this);
    }

    void IOnUpdate.OnUpdate() {
        OnUpdate();
    }
}
