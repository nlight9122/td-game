using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public SwitchAnimator switchAnimator;

	public void Retry ()
	{
		switchAnimator.AnimateToNext(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
		switchAnimator.AnimateToNext(menuSceneName);
	}

}
