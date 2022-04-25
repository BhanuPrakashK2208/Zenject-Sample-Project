using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid 
{
    
    public void SpawnGrid()
    {
        for (int x = 0; x < Spawner.instance._settings.gridX; x++)
        {
            for (int z = 0; z < Spawner.instance._settings.gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * Spawner.instance._settings.gridSpacingOffset, 0, z * Spawner.instance._settings.gridSpacingOffset) +
                    Spawner.instance._settings.gridOrigin;
                Spawner.instance.PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }
    
}
