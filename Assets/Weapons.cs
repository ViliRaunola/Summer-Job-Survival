using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=Dn_BUIVdAPg

public class Weapons : MonoBehaviour
{

    private int selectedWeapon = 0;
    private int previousWeapon = 0;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = playerStats.selectedWeapon;
        previousWeapon = selectedWeapon;
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (previousWeapon != selectedWeapon)
        {
            SelectWeapon();
            previousWeapon = selectedWeapon;
        }

    }

    public void UpdateSelectedWeapon()
    {
        selectedWeapon = playerStats.selectedWeapon;
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach( Transform weapon in transform)
        {
            if( i == selectedWeapon )
            {
                weapon.gameObject.SetActive(true);
            } else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
