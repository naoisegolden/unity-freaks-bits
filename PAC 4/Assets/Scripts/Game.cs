using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	[SerializeField] private Player player;

	void Awake()
	{
		player.OnDie += PlayerDie;
	}

	private void PlayerDie()
	{
		Invoke(nameof(RestartLevel), .5f);
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}