using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one manager on scene");
        }
        instance = this;

    }

    public GameObject standartTowerPrefub;
    public GameObject upgradeTowerPrefab;
    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney{ get { return PlayerStats.Money >= towerToBuild.cost; } }
    public void BuildTowerOn(Node node)
    {
        if(PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("No enough money");
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;

        GameObject tower =  (GameObject)Instantiate(towerToBuild.prefab,node.GetBuildPosition(), Quaternion.identity);
        node.tower = tower;
        Debug.Log("Tower build! Money left : " + PlayerStats.Money);
    }
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }
}
 