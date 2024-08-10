using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    public Tower[] towers;
    private int selectedTurret = 0;
    private void Awake()
    {
        main = this;
    }
    public Tower GetSelectTurret()
    {
        return towers[selectedTurret];
    }

    public void SetselectedTower(int _selectedTower)
    {
        selectedTurret = _selectedTower;
    }
}
