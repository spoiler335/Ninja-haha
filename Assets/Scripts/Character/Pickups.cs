using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
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
            other.GetComponent<BoxCollider>().enabled=false;
            if(!Inventory.hasIron)
            {
                Inventory.hasIron = true;
            }
            ++ironCount;
            Destroy(other.gameObject,0.1f);
        }	

        if(other.CompareTag("Ham"))
        {
            other.GetComponent<CapsuleCollider>().enabled=false;
            if(!Inventory.hasHam)
            {
                Inventory.hasHam = true; 
            }
            ++hamCount;
            Destroy(other.gameObject,0.1f);
        }

        if(other.CompareTag("Jewel"))
        {
            other.GetComponent<CapsuleCollider>().enabled=false;
            if(!Inventory.hasJewel)
            {
            Inventory.hasJewel = true;
            }
            ++jewelCount;
            Destroy(other.gameObject,0.1f);
        }
	}



}
