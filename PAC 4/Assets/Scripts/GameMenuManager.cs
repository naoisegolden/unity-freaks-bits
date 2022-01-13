using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
	[SerializeField] private Button pauseButton;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button homeButton;
	[SerializeField] private Button restartButton;
	[SerializeField] private Animator animator;

	public Action OnPause;
	public Action OnResume;
	public Action OnHome;
	public Action OnRestart;

	private bool isOpen = false;

	void Start()
	{
		pauseButton.onClick.AddListener(Open);
		resumeButton.onClick.AddListener(Close);
		homeButton.onClick.AddListener(() => OnHome?.Invoke());
		restartButton.onClick.AddListener(() => OnRestart?.Invoke());
	}

	private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			if (isOpen) { Close(); }
			else { Open(); }
		}

	}

	private void Open()
	{
		isOpen = true;
		animator.SetBool("IsOpen", true);
		pauseButton.gameObject.SetActive(false);
		OnPause?.Invoke();
	}

	private void Close()
	{
		isOpen = false;
		animator.SetBool("IsOpen", false);
		pauseButton.gameObject.SetActive(true);
		OnResume?.Invoke();
	}
}
