using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	UIMenu[] _MenuList;
	UIMenu _topMenu;
	Stack<UIDefine.Menu> _menuIDStack;

	GameplayHUD _gameplayHUD;
	void Awake()
	{
		_MenuList = this.GetComponentsInChildren<UIMenu>();
		_menuIDStack = new Stack<UIDefine.Menu>();
		_gameplayHUD = this.GetComponentInChildren<GameplayHUD>();
		RegisterEvents();

		UIEvents.OPEN_MENU(UIDefine.Menu.MAIN);
	}
	void RegisterEvents()
	{
		UIEvents.OPEN_MENU += OpenMenu;
		UIEvents.CLOSE_MENU += CloseMenu;
		UIEvents.RESULT_TO_MAIN_MENU += OnResultToMainMenu;

		GameEvents.GAME_START += OnGameStart;
		GameEvents.GAME_OVER += OnGameOver;
	}
	void OnGameStart()
	{
		UIEvents.CLOSE_MENU.Raise();
		
		ShowHUD();
	}

	void OnGameOver()
	{
		UIEvents.OPEN_MENU.Raise(UIDefine.Menu.RESULT);
	}

	void OpenMenu(UIDefine.Menu menuID)
	{
		if(_topMenu != null)
		{
			_topMenu.Close();

			if(menuID == UIDefine.Menu.MAIN)
				_menuIDStack.Push(_topMenu.MenuTag);
		}
		_topMenu = GetMenu(menuID);
		_topMenu.Open();
	}
	void CloseMenu()
	{
		_topMenu.Close();
		_topMenu = null;

		if(_menuIDStack.Count > 0)
		{
			UIDefine.Menu previousMenuID = _menuIDStack.Pop();
			OpenMenu(previousMenuID);
		}
	}
	UIMenu GetMenu(UIDefine.Menu menuID)
	{
		for(int i = 0; i < _MenuList.Length; i++)
		{
			UIMenu child = _MenuList[i];
			if(child.MenuTag == menuID)
			{
				return child;
			}
		}
		return null;
	}
	void ShowHUD()
	{
		_gameplayHUD.Open();
	}
	void HideHUD()
	{
		_gameplayHUD.Close();
	}

	void OnResultToMainMenu()
	{
		HideHUD();
		_menuIDStack.Clear();
	}
}
