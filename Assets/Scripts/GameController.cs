using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public CharacterController characterController;
	public bool hardMode;

	private CameraController cameraController;
	private CollectableController collectableController;
	private UIController UIController;

	

	void Start()
    {
		cameraController = new CameraController(transform.Find("Camera").GetComponent<Camera>(), characterController);
		collectableController = new CollectableController(transform.Find("Collectables"), characterController);
		StarController starController = GetComponent<StarController>();
		UIController = new UIController(transform.Find("UI"), characterController, starController);

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
