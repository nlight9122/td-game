using UnityEngine;

public class TowersBuildingBarHander : MonoBehaviour {

	public Tower simpleTower;
	public Tower strongTower;
	public Tower laserTower;

	TowersManager towersManager;

	void Start ()
	{
		towersManager = TowersManager.instance;
	}

	public void SelectSimpleTower ()
	{
		towersManager.SelectTowerToBuild(simpleTower);
	}

	public void SelectStrongTower()
	{
		towersManager.SelectTowerToBuild(strongTower);
	}

	public void SelectLaserTower()
	{
		towersManager.SelectTowerToBuild(laserTower);
	}

}
