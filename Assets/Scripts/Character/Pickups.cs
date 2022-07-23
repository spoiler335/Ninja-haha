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
			return stars/2;
		}

	}

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
			Animator anim = other.GetComponent<Animator>();
			stars++;
			anim.SetTrigger("pickedUp");
			Destroy(other.gameObject,2f);
		}

        if(other.CompareTag("Health"))
        {
            character.BoostHealth();
            Destroy(other.gameObject,0.1f);
        }

        if(other.CompareTag("Hazard"))
        {
            character.TakeDamage();
            Destroy(other.gameObject,0.1f);
        }	
	}

}
