using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class OpenBoard : MonoBehaviour
{
    [SerializeField] private const string leaderBoard = "CgkIpYS97KMdEAIQAQ";
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(succes => {
            if(succes){
                Debug.Log("Connect!");
            }else{
                Debug.LogError("Not Connect");
            }
        });
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
    public void Exit()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
}