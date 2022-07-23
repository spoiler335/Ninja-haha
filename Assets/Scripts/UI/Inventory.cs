using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadInventory()
    {
        if(inventoryPanel != null)  
        {
            inventoryPanel.SetActive(true);
        }
    }

    public void closeInventory()
    {
        if(inventoryPanel != null)  
        {
            inventoryPanel.SetActive(false);
        }
    }
}
