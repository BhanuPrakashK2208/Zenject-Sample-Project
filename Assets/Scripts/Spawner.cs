using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public Settings _settings;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid createGrid = new CreateGrid();
        createGrid.SpawnGrid();
    }
    public void PickAndSpawn(Vector3 positionToTransform, Quaternion rotationToTransform)
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
    }
}
