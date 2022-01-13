using UnityEngine;
using UnityEngine.SceneManagement;

struct GameData
{
	// Parameterless constructor are only available in C# 10 and up,
	// so I added a bogus parameter.
	// See https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#limitations-with-the-design-of-a-structure-type
	public GameData(string someValue)
	{
		isPaused = false;
		isBonusCollected = false;
	}
	public bool isPaused;
	public bool isBonusCollected;
}

[RequireComponent(typeof(GameMenuManager))]
[RequireComponent(typeof(DialogueManager))]
[RequireComponent(typeof(SceneTransitionManager))]
[RequireComponent(typeof(CameraManager))]
public class Game : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Minion minion;
	[SerializeField] private Collectible bonus;
	[SerializeField] private Animator bonusIndicator;
	[SerializeField] private string nextLevel;

	// Script dependencies
	private GameMenuManager menuManager;
	private DialogueManager dialogueManager;
	private SceneTransitionManager sceneTransitionManager;
	private CameraManager cameraManager;

	// Game data
	private GameData game = new GameData("unused");

	void Awake()
	{
		// Dependencies
		menuManager = GetComponent<GameMenuManager>();
		dialogueManager = GetComponent<DialogueManager>();
		sceneTransitionManager = GetComponent<SceneTransitionManager>();
		cameraManager = GetComponent<CameraManager>();

		// Character actions
		player.OnDie += PlayerDie;
		minion.OnFound += MinionFound;

		// Collectible actions
		if (bonus) bonus.OnCollected += BonusCollected;

		// UI actions
		menuManager.OnPause += () => Invoke(nameof(Pause), 0.5f); // FIXME: Wait for open animation 
		menuManager.OnResume += Resume;
		menuManager.OnHome += OnHome;
		menuManager.OnRestart += OnRestart;
		dialogueManager.OnEnd += DialogueEnd;
	}

	private void HomeScene()
	{
		sceneTransitionManager.LoadScene("Home");
	}

	private void RestartLevel()
	{
		sceneTransitionManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void NextLevel()
	{
		sceneTransitionManager.LoadScene(nextLevel);
	}

	private void PauseGame(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
		game.isPaused = pause;
	}
	private void Pause() => PauseGame(true);
	private void Resume() => PauseGame(false);

	private void OnHome()
	{
		Resume();
		DisappearPlayer();
		DisappearMinion();
		HomeScene();
	}

	private void OnRestart()
	{
		Resume();
		DisappearPlayer();
		DisappearMinion();
		RestartLevel();
	}

	private void PlayerDie()
	{
		cameraManager.Shake();

		Invoke(nameof(RestartLevel), .5f);
	}

	private void BonusCollected()
	{
		game.isBonusCollected = true;
		bonusIndicator.SetBool("IsCollected", true);
	}

	private void MinionFound()
	{
		dialogueManager.StartDialogue();
		player.Stop();
	}

	private void DialogueEnd()
	{
		Invoke(nameof(NextLevel), 0.5f);
		Invoke(nameof(DisappearMinion), 1.5f);
		Invoke(nameof(DisappearPlayer), 1.7f);
	}

	private void DisappearMinion()
	{
		minion.Disappear();
	}

	private void DisappearPlayer()
	{
		player.Disappear();
	}
}