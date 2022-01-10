using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Minion minion;
	[SerializeField] private Collectible collectible;

	private bool collected = false;

	void Awake()
	{
		player.OnDie += PlayerDie;
		minion.OnCollected += MinionCollected;
		if (collectible) collectible.OnCollected += CollectibleCollected;
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void PlayerDie()
	{
		Invoke(nameof(RestartLevel), .5f);
	}

	private void MinionCollected()
	{
		Debug.Log("Minion collected");
	}

	private void CollectibleCollected()
	{
		Debug.Log("Collectible collected");
		collected = true;
	}
}