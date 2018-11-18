using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResult : UIMenu {

	public void OnResultPressed()
	{
		UIEvents.OPEN_MENU.Raise(UIDefine.Menu.MAIN);
		UIEvents.RESULT_TO_MAIN_MENU.Raise();
	}
}
