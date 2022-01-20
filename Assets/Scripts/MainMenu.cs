using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SwitchAnimator switchAnimator;

	public void Play ()
	{
		switchAnimator.AnimateToNext(levelToLoad);
	}

	public void Quit ()
	{
		Application.Quit();
	}

}
