using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject descriptionPanel;

    public Pickups pickups;
    public static int itemsCount;

    public static bool hasIron;
    public static bool hasHam;
    public static bool hasJewel;
    [SerializeField] GameObject warningText;
    [SerializeField] Transform plyaerTrans;
    [SerializeField] GameObject hamPrefab;
    [SerializeField] GameObject ironPrefab;
    [SerializeField] GameObject jewelPrefab;
    [SerializeField] GameObject handHam;
    [SerializeField] GameObject handIron;
    [SerializeField] GameObject handJewel;   
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

    [SerializeField] Image desImage;
    [SerializeField] TextMeshProUGUI desText;
 

    [SerializeField] TextMeshProUGUI inventoryCountText;

    Button hamBtton;
    Button ironButton;
    Button jewelButton;

    bool hasSelectedHam;
    bool hasSelectedIron;
    bool hasSelectedJewel;

    bool holdsHam;
    bool holdsIron;
    bool holdsJewel;



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

        hamBtton = hamImage.GetComponent<Button>();
        ironButton = ironImage.GetComponent<Button>();
        jewelButton = jewelImage.GetComponent<Button>();

        hamBtton.enabled  = false;
        ironButton.enabled  = false;
        jewelButton.enabled  = false;

        handHam.SetActive(false);
        handIron.SetActive(false);
        handJewel.SetActive(false);

        holdsHam = false;
        holdsIron = false;
        holdsJewel = false;

        warningText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        checkHam();
        checkIron();
        checkJewel();
        inventoryCountText.text =  "Inventory (" + itemsCount + " / " + 100 + ")";
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

    
    void checkHam()
    {
        if(pickups.hamCount <=0)
        {
            hasHam = false;
        }
        if(hasHam)
        {
            hamImage.sprite = hamSprite;
            hamText.enabled = true;
            hamCountText.enabled=true;
            hamCountText.text = pickups.hamCount.ToString();
            hamBtton.enabled = true;
        }

        else
        {
            hamImage.sprite = empty;
            hamText.enabled = false;
            hamCountText.enabled=false;
            hamBtton.enabled = false;
        }
    }

    void checkIron()
    {
        if(pickups.ironCount <=0)
        {
            hasIron = false;
        }

        if(hasIron)
        {
            ironImage.sprite = ironSprite;
            ironText.enabled = true;
            ironCountText.enabled=true;
            ironCountText.text = pickups.ironCount.ToString();
            ironButton.enabled = true;
        }

        else
        {
            ironImage.sprite = empty;
            ironText.enabled = false;
            ironCountText.enabled=false;
            ironButton.enabled = false;
        }
    }

    void checkJewel()
    {
        if(pickups.jewelCount <=0)
        {
            hasJewel = false;
        }

        if(hasJewel)
        {
            jewelImage.sprite = jewelSprite;
            jewelText.enabled = true;
            jewelCountText.enabled=true;
            jewelCountText.text = pickups.jewelCount.ToString();
            jewelButton.enabled = true;
        }

        else
        {
            jewelImage.sprite = empty;
            jewelText.enabled = false;
            jewelCountText.enabled=false;
            jewelButton.enabled = false;
        }
    }

    public void loadHamDes()
    {
        descriptionPanel.SetActive(true);
        desImage.sprite = hamSprite;
        desText.text = "Ham \n\n A Leg of Ham is very Tasty Snack but Also Can be Used as a weapon";
        hasSelectedHam = true; 
        hasSelectedIron = false;
        hasSelectedJewel = false;
    }

    public void loadIronDes()
    {
        descriptionPanel.SetActive(true);
        desImage.sprite = ironSprite;
        desText.text = "Iron \n\n A Iron piece Can be Used to Build Weapons";
        hasSelectedHam = false; 
        hasSelectedIron = true;
        hasSelectedJewel = false;
    }

    public void loadJewelDes()
    {
        descriptionPanel.SetActive(true);
        desImage.sprite = jewelSprite;
        desText.text = "Jewel \n\n A Jewel piece can be Used sharpen Waepons";
        hasSelectedHam = false; 
        hasSelectedIron = false;
        hasSelectedJewel = true;
    }

    public void Equip()
    {
        if(hasSelectedHam)
        {
            handHam.SetActive(true);
            handIron.SetActive(false);
            handJewel.SetActive(false);
            holdsHam = true;
            holdsIron = false;
            holdsJewel = false;
        }

        if(hasSelectedIron)
        {
            handHam.SetActive(false);
            handIron.SetActive(true);
            handJewel.SetActive(false);
            holdsHam = false;
            holdsIron = true;
            holdsJewel = false;
        }

        if(hasSelectedJewel)
        {
            handHam.SetActive(false);
            handIron.SetActive(false);
            handJewel.SetActive(true);
            holdsHam = false;
            holdsIron = false;
            holdsJewel = true;
        }
    }

    public void Drop()
    {
        if(!holdsHam && !holdsIron && !holdsJewel)
        {
            warningText.SetActive(true);
            warningText.GetComponent<TextMeshProUGUI>().text = "Hold Something To Drop";
            Invoke("disableWarningText",2f);
        }

        if(holdsHam)
        {
            Instantiate(hamPrefab, plyaerTrans.position + new Vector3(2f,0,2f), plyaerTrans.rotation);
            --pickups.hamCount;
            holdsHam = false;
            handHam.SetActive(false);
            --itemsCount;
            if(pickups.hamCount<=0)
            {
                hasHam = false;
            }
        }

        else if(holdsIron)
        {
            Instantiate(ironPrefab, plyaerTrans.position + new Vector3(2f,0,2f), plyaerTrans.rotation);
            --pickups.ironCount;
            holdsIron = false;
            handIron.SetActive(false);
            --itemsCount;
            if(pickups.ironCount<=0)
            {
                hasIron = false;
            }
        }

        else if(holdsJewel)
        {
            Instantiate(jewelPrefab, plyaerTrans.position + new Vector3(2f,0,2f), plyaerTrans.rotation);
            --pickups.jewelCount;
            holdsJewel = false;
            handJewel.SetActive(false);
            --itemsCount;
            if(pickups.jewelCount<=0)
            {
                hasJewel = false;
            }
        }
    }

    void disableWarningText()
    {
        warningText.SetActive(false);
    }
}
