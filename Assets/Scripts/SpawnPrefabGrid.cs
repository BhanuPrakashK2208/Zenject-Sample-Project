using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpawnPrefabGrid : MonoBehaviour
{
    public Settings _settings;

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnGrid()
    {
        for (int x = 0; x < _settings.gridX; x++)
        {
            for(int z = 0; z < _settings.gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * _settings.gridSpacingOffset, 0, z * _settings.gridSpacingOffset) + _settings.gridOrigin;
                PickAndSpawn(RandomizePosition(spawnPosition), Quaternion.identity);
            }
        }
    }

    Vector3 RandomizePosition(Vector3 position)
    {
        Vector3 randomizedPosition = new Vector3(Random.Range(-_settings.positionRandomization.x, _settings.positionRandomization.x), Random.Range(-_settings.positionRandomization.y, _settings.positionRandomization.y), Random.Range(-_settings.positionRandomization.z, _settings.positionRandomization.z)) + position;

        return randomizedPosition;
    }

    void PickAndSpawn(Vector3 positionToTransform, Quaternion rotationToTransform)
    {
        int randomIndex = Random.Range(0, _settings.prefabs.Length);
        GameObject clone = Instantiate(_settings.prefabs[randomIndex], positionToTransform, rotationToTransform);

    }
    [Serializable]
    public class Settings
    {
        public GameObject[] prefabs;
        public int gridX;
        public int gridZ;
        public float gridSpacingOffset = 1f;
        public Vector3 gridOrigin = Vector3.zero;
        public Vector3 positionRandomization;
    }
}
