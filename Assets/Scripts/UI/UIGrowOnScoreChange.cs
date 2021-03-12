using UnityEngine;

public class UIGrowOnScoreChange : UIGrow, IOnScorePoint {
    public int threshold = 10;

    protected override void Awake() {
        base.Awake();
    }
    public void OnScorePoint(int score) {
        if (score % threshold == 0) {
            //grow
            CopyCat.Updater.AddToUpdate(this);
        }
    }
}
