using UnityEngine;

public class TowersManager : MonoBehaviour {

	public static TowersManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private Tower towerToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return towerToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

	public void SelectTower (Node node)
	{
		if (selectedNode == node)
		{
			UnselectTower();
			return;
		}

		selectedNode = node;
		towerToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void UnselectTower()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTowerToBuild (Tower tower)
	{
		towerToBuild = tower;
		UnselectTower();
	}

	public Tower GetTowerToBuild ()
	{
		return towerToBuild;
	}

}
