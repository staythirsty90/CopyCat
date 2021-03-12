using UnityEngine;

public class UIHandler : MonoBehaviour {

    //public Text text;
    //FirebaseAuth auth;
    //FirebaseUser user;
    //DatabaseReference reference;
    //ArrayList leaderBoard;
    //private const int MaxScores = 5;
    //private int score = 0;
    //private uint currentCoins = 0;
    //public delegate void ShowLeaderboardHandler(ArrayList leaderboard);
    //public event ShowLeaderboardHandler OnShowLeaderboard;

    //DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    //string databaseName = "Leaders";

    //void OnDestroy() {
    //    Debug.Log("UIHANDLER ON DESTORY");
    //    auth.StateChanged -= AuthStateChanged;
    //    auth = null;
    //    user = null;
    //    FirebaseDatabase.DefaultInstance.GetReference(databaseName).ValueChanged -= OnValueChanged;
    //}

    //void Start() {

    //    leaderBoard = new ArrayList();
    //    leaderBoard.Add("Firebase Top " + MaxScores.ToString() + " Scores");

    //    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
    //        dependencyStatus = task.Result;
    //        if (dependencyStatus == DependencyStatus.Available) {
    //            InitializeFirebaseAndLeaderboard();
    //        }
    //        else {
    //            Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
    //        }
    //    });

    //}

    //// Initialize the Firebase database:
    //void InitializeFirebaseAndLeaderboard() {
    //    FirebaseApp app = FirebaseApp.DefaultInstance;
    //    app.SetEditorDatabaseUrl("https://copy-cat-dc5e1.firebaseio.com/");
    //    if (app.Options.DatabaseUrl != null)
    //    {
    //        app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
    //    }
    //    StartListener();
    //    auth = FirebaseAuth.DefaultInstance;
    //    auth.StateChanged += AuthStateChanged;
    //    AuthStateChanged(this, null);
    //    reference = FirebaseDatabase.DefaultInstance.RootReference;
    //    if (user == null) {
    //        SigninAnonymously();
    //    }
    //}


    //void OnValueChanged(object sender2, ValueChangedEventArgs e2)
    //{
    //    if (e2.DatabaseError != null)
    //    {
    //        Debug.LogError(e2.DatabaseError.Message);
    //        return;
    //    }

    //    string title = leaderBoard[0].ToString();
    //    leaderBoard.Clear();
    //    leaderBoard.Add(title);
    //    if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
    //    {
    //        foreach (var childSnapshot in e2.Snapshot.Children)
    //        {
    //            if (childSnapshot.Child("score") == null || childSnapshot.Child("score").Value == null)
    //            {
    //                Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
    //                break;
    //            }
    //            else
    //            {
    //                if (user.UserId == childSnapshot.Child("id").Value.ToString())
    //                {
    //                    FindObjectOfType<Score>().LoadHighScore(int.Parse(childSnapshot.Child("score").Value.ToString()));
    //                }
    //                leaderBoard.Insert(1, childSnapshot.Child("score").Value.ToString());
    //            }
    //        }
    //    }
    //}

    //protected void StartListener() {
    //    Debug.Log("START LISTENER");
    //    FirebaseDatabase.DefaultInstance
    //      .GetReference(databaseName).OrderByChild("score")
    //      .ValueChanged += OnValueChanged;
    //}


    //public void ShowLeaderboard() {

    //    Debug.Log("SHOW LEADERBOARD");
    //    OnShowLeaderboard?.Invoke(leaderBoard);

    //}

    //// Track state changes of the auth object.
    //void AuthStateChanged(object sender, System.EventArgs eventArgs) {
    //    Debug.Log("AUTH STATE CHANGED");
    //    if (auth.CurrentUser != user) {
    //        bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
    //        user = auth.CurrentUser;
    //        if (signedIn) {
    //            if (text) {
    //                text.text = user.UserId;
    //            }
    //        }
    //    }
    //}

    //// Attempt to sign in anonymously.
    //public void SigninAnonymously() {
    //    Debug.Log("SIGN IN ANONYMOUSLY");
    //    auth.SignInAnonymouslyAsync().ContinueWith(task => {
    //        if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted) {
    //           // Debug.Log("User is now signed in.");
    //            user = task.Result;
    //        }
    //        else if (task.IsFaulted || task.IsCanceled) {
    //           // Debug.Log("User signin failed");
    //        }
    //    });
    //}

    //TransactionResult AddScoreToLeaderboardTransaction(MutableData mutableData) {
    //    Debug.Log("ADD SCORE TO LEADERBOARD TRANSACTION");
    //    List<object> leaders = mutableData.Value as List<object>;

    //    if (leaders == null) {
    //        leaders = new List<object>();
    //    }
    //    int index = -1;
    //    //int childScore;
    //    //int childCoins;
    //    for (int i = 0; i < leaders.Count; i++) {

    //        var data = (Dictionary<string, object>)leaders[i];
    //        string id = (string)data["id"];
    //        if (id.Equals(user.UserId)) {
    //            int s = int.Parse(data["score"].ToString());
    //            if (s >= score) {
    //                return TransactionResult.Abort();
    //            }
    //            index = i;
    //            break;
    //        }
    //    }
    //    if (index > -1) {
    //        leaders.RemoveAt(index);
    //        leaders.Add(new Dictionary<string, object> { ["id"] = user.UserId, ["score"] = score });
    //        mutableData.Value = leaders;
    //        return TransactionResult.Success(mutableData);
    //    }
    //    else {
    //        // user hasn't been on the leaderboard yet
    //        leaders.Add(new Dictionary<string, object> { ["id"] = user.UserId, ["score"] = score });
    //        mutableData.Value = leaders;
    //        return TransactionResult.Success(mutableData);
    //    }
    //}

    //public void AddScore(uint score) {
    //    this.score = (int)score;
    //    if (score == 0 ){//|| string.IsNullOrEmpty(email)) {
    //        return;
    //    }
    //    DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(databaseName);
    //    reference.RunTransaction(AddScoreToLeaderboardTransaction).ContinueWith(task => {
    //          if (task.Exception != null) {
    //              //Debug.Log(task.Exception.ToString());
    //          }
    //          else if (task.IsCompleted) {
    //              //Debug.Log("Transaction complete.");
    //          }
    //          else if (task.IsFaulted) {
    //             // Debug.Log("Transaction cancelled.");
    //          }
    //      });
    //}

}