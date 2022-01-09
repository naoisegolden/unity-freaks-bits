using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Collectible collectible;

	private bool collected = false;

	void Awake()
	{
		player.OnDie += PlayerDie;
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

	private void CollectibleCollected()
	{
		collected = true;
	}
}