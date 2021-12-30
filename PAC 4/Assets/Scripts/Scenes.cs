using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
	[SerializeField] private string NextScene;

	public void OpenNextScene()
	{
		SceneManager.LoadScene(NextScene);
	}

}