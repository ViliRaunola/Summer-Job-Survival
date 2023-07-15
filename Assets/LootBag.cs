using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Reference: https://www.youtube.com/watch?v=KjvvRmG7PBM
public class LootBag : MonoBehaviour
{

    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        if (possibleItems.Count > 0)
        {
            Loot smallestChangeLoot = possibleItems[0];
            for (int i = 1; i < possibleItems.Count; i++)
            {
                if (possibleItems[i].dropChance < smallestChangeLoot.dropChance) smallestChangeLoot = possibleItems[i];
            }
            return smallestChangeLoot;
        }

        return null;
    }

    public void CreateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            // Can add here more stuff if wanted :D
            
            lootGameObject.name = droppedItem.name;
        }
    }
}
