using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject descriptionPanel;

    public Pickups pickups;
    public static int itemsCount;

    public static bool hasIron;
    public static bool hasHam;
    public static bool hasJewel;

    [SerializeField] Image hamImage;
    [SerializeField] Text hamText;
    [SerializeField] Text hamCountText;
    [SerializeField] Image ironImage;
    [SerializeField] Text ironText;
    [SerializeField] Text ironCountText;
    [SerializeField] Image jewelImage;
    [SerializeField] Text jewelText;
    [SerializeField] Text jewelCountText;

    [SerializeField] Sprite empty;
    [SerializeField] Sprite hamSprite;
    [SerializeField] Sprite ironSprite;
    [SerializeField] Sprite jewelSprite;



    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        descriptionPanel.SetActive(false);
        hamImage.sprite = empty;
        ironImage.sprite = empty;
        jewelImage.sprite = empty;
        hamText.enabled = false;
        ironText.enabled = false;
        jewelText.enabled = false;
        hamCountText.enabled = false;
        ironCountText.enabled = false;
        jewelCountText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkCount();
        checkHam();
        checkIron();
        checkJewel();
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

    void checkCount()
    {

    }
    void checkHam()
    {
        if(hasHam)
        {
            hamImage.sprite = hamSprite;
            hamText.enabled = true;
            hamCountText.enabled=true;
            hamCountText.text = pickups.hamCount.ToString();
        }

        else
        {

        }
    }

    void checkIron()
    {
        if(hasIron)
        {
            ironImage.sprite = ironSprite;
            ironText.enabled = true;
            ironCountText.enabled=true;
            ironCountText.text = pickups.ironCount.ToString();
        }

        else
        {

        }
    }

    void checkJewel()
    {
        if(hasJewel)
        {
            jewelImage.sprite = jewelSprite;
            jewelText.enabled = true;
            jewelCountText.enabled=true;
            jewelCountText.text = pickups.jewelCount.ToString();
        }

        else
        {

        }
    }
}
