using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLogic : MonoBehaviour
{

    public TMP_Text hitPointText;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        SetHitPointsText();
    }

    public void SetHitPointsText()
    {
        hitPointText.text = playerStats.health.ToString() + "%";
        SetHitPointsColor();
    }

    private void SetHitPointsColor()
    {
        if (playerStats.health >= 75) 
        {
            hitPointText.color = Color.green;
        }else if( 25 <= playerStats.health && playerStats.health < 75) 
        {
            hitPointText.color = Color.yellow;
        }else if(playerStats.health < 25)
        {
            hitPointText.color = Color.red;
        }
    }
}
