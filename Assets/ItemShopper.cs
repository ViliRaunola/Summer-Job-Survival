using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopper : MonoBehaviour
{
    public GameObject itemMenu;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            itemMenu.SetActive(true);
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemMenu.SetActive(false);
        }
    }
}
