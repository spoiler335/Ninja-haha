using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public CharacterController characterController;
	public Pickups pickups;
	public bool hardMode;

	private CameraController cameraController;
	private UIController UIController;

	

	void Start()
    {
		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		UIController = new UIController(transform.Find("UI"), characterController,pickups);

		if (hardMode)
		{
			int startHealth = characterController.MaxHealth / 2;
			Debug.Log(startHealth);
			characterController.SetHealth(startHealth);
		}
	}

	private void Update()
	{
		UIController.Update();
	}

	private void LateUpdate()
	{
		cameraController.LateUpdate();
	}
}
