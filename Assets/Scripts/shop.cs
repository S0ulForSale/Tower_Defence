using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;
    public TowerBlueprint standartTower;
    public TowerBlueprint upgradeTower;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTower()
    {
       
        buildManager.SelectTowerToBuild(standartTower);
    }
    public void SelectUpperTower()
    {
        
        buildManager.SelectTowerToBuild(upgradeTower);

    }
}
