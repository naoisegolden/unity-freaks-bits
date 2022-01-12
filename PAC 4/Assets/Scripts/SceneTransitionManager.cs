using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : MonoBehaviour
{
	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 1.0f;

	public void LoadScene(string scene)
	{
		StartCoroutine(LoadSceneCoroutine(scene));
	}

	IEnumerator LoadSceneCoroutine(string scene)
	{
		transition.SetTrigger("StartTransition");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(scene);
	}
}
