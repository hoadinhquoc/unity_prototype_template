using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvents {

	public static Action GAME_START;
	public static Action GAME_OVER;
	public static Action GAME_PAUSE;
	public static Action GAME_REVIVE;

	public static Action<int> SCORE_INCREASE;
}
public class GameplayEvents{
	public static Action MC_DEATH;
	public static Action<Vector3> CAMERA_CHANGED_POSITION;
	public static Action<ControlAction> INPUT_CONTROL;
}
public class UIEvents{
	public static Action<UIDefine.Menu> OPEN_MENU;
	public static Action CLOSE_MENU;
	public static Action RESULT_TO_MAIN_MENU;
}
public static class ActionExt
{
	public static void Raise(this Action action)
	{
		if (action != null)
			action.Invoke();
	}
	public static void Raise<T1>(this Action<T1> action, T1 value1)
	{
		if (action != null)
			action.Invoke(value1);
	}

	public static void Raise<T1, T2>(this Action<T1, T2> action, T1 value1, T2 value2)
	{
		if (action != null)
			action.Invoke(value1, value2);
	}

	public static void Raise<T1, T2, T3>(this Action<T1, T2, T3> action, T1 value1, T2 value2, T3 value3)
	{
		if (action != null)
			action.Invoke(value1, value2, value3);
	}
}