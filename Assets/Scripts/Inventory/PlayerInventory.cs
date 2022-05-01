using UnityEngine;

public class PlayerInventory : AbstractInventory
{
    //Hack:Debug only
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            foreach (var item in Storage.Items)
                Debug.Log($"{item.ItemData.Name} - {item.Amount}");
    }
}