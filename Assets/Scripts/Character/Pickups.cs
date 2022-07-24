using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickups : MonoBehaviour
{
    int stars=0;
	public int Star
	{
		get
		{
			return stars;
		}

	}

    public int hamCount=0;
    public int ironCount=0;
    public int jewelCount=0;
    [SerializeField] GameObject warningText;
    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        warningText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag("Star"))
		{
            other.GetComponent<BoxCollider>().enabled=false;
			Animator anim = other.GetComponent<Animator>();
			stars++;
			anim.SetTrigger("pickedUp");
			Destroy(other.gameObject,2f);
		}

        if(other.CompareTag("Health"))
        {
            other.GetComponent<BoxCollider>().enabled=false;
            character.BoostHealth();
            Destroy(other.gameObject,0.1f);
        }

        if(other.CompareTag("Hazard"))
        {
            other.GetComponent<BoxCollider>().enabled=false;
            character.TakeDamage();
            Destroy(other.gameObject,0.1f);
        }

        if(other.CompareTag("Iron"))
        {
            if(Inventory.itemsCount < 100)
            {
                other.GetComponent<BoxCollider>().enabled=false;
                if(!Inventory.hasIron)
                {
                    Inventory.hasIron = true;
                }
                ++ironCount;
                ++Inventory.itemsCount;
                Destroy(other.gameObject,0.1f);
            }
            else
            {
                warningText.SetActive(true);
                warningText.GetComponent<Text>().text= "Inventory is full Cannot Add Items.";
                Invoke("disableWarningText",2f);
            }
        }	

        if(other.CompareTag("Ham"))
        {
            if(Inventory.itemsCount < 100)
            {
                other.GetComponent<CapsuleCollider>().enabled=false;
                if(!Inventory.hasHam)
                {
                    Inventory.hasHam = true; 
                }
                ++hamCount;
                ++Inventory.itemsCount;
                Destroy(other.gameObject,0.1f);
            }
            else
            {
                warningText.SetActive(true);
                warningText.GetComponent<TextMeshProUGUI>().text= "Inventory is full Cannot Add Items.";
                Invoke("disableWarningText",2f);
            }
        }

        if(other.CompareTag("Jewel"))
        {
            if(Inventory.itemsCount < 100)
            {
                other.GetComponent<CapsuleCollider>().enabled=false;
                if(!Inventory.hasJewel)
                {
                Inventory.hasJewel = true;
                }
                ++jewelCount;
                ++Inventory.itemsCount;
                Destroy(other.gameObject,0.1f);
            }
            else
            {
                warningText.SetActive(true);
                warningText.GetComponent<Text>().text= "Inventory is full Cannot Add Items.";
                Invoke("disableWarningText",2f);
            }
        }
	}

    void disableWarningText()
    {
        warningText.SetActive(false);
    }



}
