using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using static UnityEngine.Rendering.DebugUI;
using TMPro;
using UnityEngine.SceneManagement;

// Source: https://www.youtube.com/watch?v=pp8Vl4cKLdc, https://www.youtube.com/watch?v=u8llsk7FoYg&t=644s

public class LeaderBoardController : MonoBehaviour
{

    public TMP_InputField MemberID;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    public TextMeshProUGUI yourScore;
    private int playerScore = Mathf.RoundToInt(StateNameController.playerScore);
    public int ID;
    private string leaderboardKey = "summer_job";

    void Start()
    {
        yourScore.text = "Your Score: " + playerScore.ToString();

        LootLockerSDKManager.StartGuestSession( (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void ToMainMenu()
    {
        StateNameController.playerScore = 0;
        StateNameController.selectedWeapon = -1;
        StateNameController.bulletDamage = 0;
        StateNameController.fireRate = 0;
        StateNameController.damage = 0;
        StateNameController.coins = 0;
        SceneManager.LoadScene("Menu");
    }

    public void Credits()
    {
        StateNameController.playerScore = 0;
        StateNameController.selectedWeapon = -1;
        StateNameController.bulletDamage = 0;
        StateNameController.fireRate = 0;
        StateNameController.damage = 0;
        StateNameController.coins = 0;
        SceneManager.LoadScene("Credits");
    }

    public void SubmitScore()
    {

        LootLockerSDKManager.SubmitScore(MemberID.text, playerScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void FetcHighScores()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 15, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Players:\n";
                string tempPlayerScores = "Score:\n";
                LootLockerLeaderboardMember[] members = response.items;
             
                for (int i = 0; i < members.Length; i++)
                {       
                    tempPlayerNames += members[i].member_id;  
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
