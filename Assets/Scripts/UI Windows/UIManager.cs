﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Class used for managing UI windows.
/// </summary>
public class UIManager : MonoBehaviour
{
	/// <summary>
	/// Invoked when game is started.
	/// </summary>
	public event Action GameStarted;

	/// <summary>
	/// Invoked when game is finished.
	/// </summary>
	public event Action GameFinished;

#pragma warning disable 0649
	[SerializeField]
	private Tshirts tshirts;
#pragma warning restore 0649

#pragma warning disable 0649
	[SerializeField]
	private StartWindow startWindow;
#pragma warning restore 0649

#pragma warning disable 0649
	[SerializeField]
	private EndWindow endWindow;
#pragma warning restore 0649

	private void Awake()
	{
		tshirts.GameFinished += ShowEndScreen;
		startWindow.StartGameButtonClicked += InformAboutGameStart;
		ShowStartScreen();
	}

	private void OnDestroy()
	{
		try
		{
			tshirts.GameFinished -= ShowEndScreen;
		}
#pragma warning disable 168
		catch (NullReferenceException e) { }
#pragma warning restore 168		

		try
		{
			startWindow.StartGameButtonClicked -= InformAboutGameStart;
		}
#pragma warning disable 168
		catch (NullReferenceException e) { }
#pragma warning restore 168
	}

	private void ShowEndScreen()
	{
		endWindow.Show();
		InformAboutGameStop();
	}

	private void ShowStartScreen()
	{
		startWindow.Show();
	}

	private void InformAboutGameStart()
	{
		GameStarted?.Invoke();
	}

	private void InformAboutGameStop()
	{
		GameFinished?.Invoke();
	}
}
