using UnityEngine;

public class RenderLeaderboard : MonoBehaviour {

    //#if UNITY_EDITOR
    private void Awake() {
        gameObject.SetActive(false);
    }
    //#endif


    ////#if !UNITY_EDITOR
    //    //public List<GameObject> disable;
    //    public Text textPrefab;
    //    public Transform leaderboardParent;
    //    List<Text> texts = new List<Text>();
    //    // Use this for initialization
    //    bool isShowing = false;
    //    UIHandler handler;

    //    private void Awake() {
    //        handler = FindObjectOfType<UIHandler>();
    //        for (int i = 0; i < 5; i++) {
    //            //textGameObjects.Add(new GameObject("leaderboard text "));
    //            texts.Add( Instantiate(textPrefab));
    //            texts[i].transform.SetParent(leaderboardParent);
    //            //if (isShowing) texts[i].enabled = false;


    //        }
    //       // hideLeaderBoard();
    //        //for (int i = 0; i < disable.Count; i++) {
    //        //    disable[i].SetActive(false);
    //        //}
    //    }

    //    private void Start() {
    //        handler.OnShowLeaderboard += UIHandler_OnShowLeaderboard;
    //        CopyCat.OnGameRestart += hideLeaderBoard;
    //        //CopyCat.OnGameRestart += reset;

    //        CopyCat.OnGameBegin += hideLeaderBoard;
    //        CopyCat.OnGamePlaying += hideLeaderBoard;
    //        hideLeaderBoard();
    //    }


    //    private void reset() {
    //        handler.OnShowLeaderboard -= UIHandler_OnShowLeaderboard;
    //        CopyCat.OnGameRestart -= hideLeaderBoard;
    //        CopyCat.OnGameRestart -= reset;

    //        CopyCat.OnGameBegin -= hideLeaderBoard;
    //        CopyCat.OnGamePlaying -= hideLeaderBoard;


    //    }

    //    private void UIHandler_OnShowLeaderboard(ArrayList leaderboard) {
    //        if (isShowing) {
    //            hideLeaderBoard();
    //        }
    //        else {
    //            showLeaderBoard(leaderboard);
    //        }

    //    }

    //    private void showLeaderBoard(ArrayList leaderboard) {
    //        for (int i = 1; i < leaderboard.Count; i++) {
    //            texts[i-1].text = "#" + i + ". " + leaderboard[i].ToString();
    //            texts[i-1].enabled = true;
    //        }
    //        gameObject.SetActive(true);
    //        //for (int i = 0; i < disable.Count; i++) {
    //        //    disable[i].SetActive(true);
    //        //}
    //        isShowing = true;
    //    }

    //    private void hideLeaderBoard() {
    //        gameObject.SetActive(false);
    //        for (int i = 0; i < 5; i++) {
    //            texts[i].enabled = false;
    //        }
    //        isShowing = false;
    //        //for (int i = 0; i < disable.Count; i++) {
    //        //    disable[i].SetActive(false);
    //        //}
    //        return;
    //    }
    ////#endif
}
