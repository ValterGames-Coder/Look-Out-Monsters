using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobGiveMoney : MonoBehaviour
{
    private RewardedAd rewarded;
    private const string rewardedUtils = "ca-app-pub-4721480223801357/3940613732";

    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnEnable()
    {
        rewarded = new RewardedAd(rewardedUtils);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewarded.LoadAd(adRequest);

        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void OnDisable()
    {
        rewarded.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    public void HandleUserEarnedReward(object sender, Reward agrs){
        player.money += 10;
    }
    public void ShowAd(){
        if(rewarded.IsLoaded()) rewarded.Show();
    }
}
