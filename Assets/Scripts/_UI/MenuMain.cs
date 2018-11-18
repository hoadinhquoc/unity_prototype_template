using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : UIMenu {

	public void OnStartPressed()
	{
		GameEvents.GAME_START.Raise();
	}
}
