using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DialogueManager))]
[RequireComponent(typeof(SceneTransitionManager))]
public class Game : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Minion minion;
	[SerializeField] private Collectible collectible;

	private SceneTransitionManager sceneTransitionManager;
	private DialogueManager dialogueManager;

	private bool collected = false;

	void Awake()
	{
		player.OnDie += PlayerDie;
		minion.OnFound += MinionFound;
		if (collectible) collectible.OnCollected += CollectibleCollected;

		dialogueManager = GetComponent<DialogueManager>();
		dialogueManager.OnEnd += DialogueEnd;

		sceneTransitionManager = GetComponent<SceneTransitionManager>();
	}

	private void RestartLevel()
	{
		sceneTransitionManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void NextLevel()
	{
		// WIP: fix this when more levels added
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		sceneTransitionManager.LoadScene("LevelTemplate");
	}

	private void PlayerDie()
	{
		Invoke(nameof(RestartLevel), .5f);
	}

	private void CollectibleCollected()
	{
		Debug.Log("Collectible collected");
		collected = true;
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