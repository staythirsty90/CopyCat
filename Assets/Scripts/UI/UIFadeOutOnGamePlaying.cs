﻿public class UIFadeOutOnGamePlaying : UIMonoBehaviour, IOnGamePlaying {
    public void OnGamePlaying() {
        StartCoroutine(CrossFade(thisImage, thisImage.color.a, delay));
    }
}
