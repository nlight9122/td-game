using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyBarHandler : MonoBehaviour {

	public Text moneyText;

	void Update () {
		moneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
