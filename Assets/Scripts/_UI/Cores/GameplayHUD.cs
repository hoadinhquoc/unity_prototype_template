using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHUD : MonoBehaviour {

	[SerializeField]GameObject _Display;
	// Use this for initialization
	void Awake () {
		RegisterEvents();
	}
	void RegisterEvents()
	{
		
	}
	[HideInInspector]
	public void Open()
	{
		_Display.SetActive(true);
	}

	[HideInInspector]	
	public void Close()
	{
		_Display.SetActive(false);
	}

	public void OnGameOverPressed()
	{
		GameEvents.GAME_OVER.Raise();
	}
	public void OnMCDeathPressed()
	{
		GameplayEvents.MC_DEATH.Raise();
	}
}
