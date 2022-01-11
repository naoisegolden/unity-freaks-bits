using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Minion minion;
	[SerializeField] private Collectible collectible;

	private DialogueManager dialogueManager;

	private bool collected = false;

	void Awake()
	{
		player.OnDie += PlayerDie;
		minion.OnFound += MinionFound;
		if (collectible) collectible.OnCollected += CollectibleCollected;

		dialogueManager = GetComponent<DialogueManager>();
		if (dialogueManager == null) Debug.LogError("Missing DialogueManager component in Game script game object.");
		dialogueManager.OnEnd += DialogueEnd;
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void NextLevel()
	{
		// WIP: fix this when more levels added
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene("Start");
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
	}

	private void DialogueEnd()
	{
		Invoke(nameof(DisappearMinion), 1.0f);
		Invoke(nameof(DisappearPlayer), 1.3f);
		Invoke(nameof(NextLevel), 2.0f);
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