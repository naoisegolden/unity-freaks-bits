using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : MonoBehaviour
{
	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 2.0f;

	public void UnityLoadScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}
	public void LoadScene(string scene)
	{
		StartCoroutine(LoadSceneCoroutine(scene));
	}

	private IEnumerator LoadSceneCoroutine(string scene)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(scene);
	}
}
