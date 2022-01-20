using UnityEngine;
using UnityEngine.UI;

public class HealthBarHander : MonoBehaviour {

	public Text livesText;

	void Update () {
		livesText.text = "Здоровье: " + PlayerStats.Lives.ToString();
	}
}
