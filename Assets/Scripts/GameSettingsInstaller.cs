using UnityEngine;
using Zenject;
using System;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public PlayerSettings Player;

    

    //public SpawnNPCSettings NPCSpawner;

    [Serializable]
    public class PlayerSettings
    {
        public PlayerController.Settings _PlayerSettings; 
    }
    
    
    //[Serializable]
    //public class SpawnNPCSettings
    //{
    //    public SpawnPrefabGrid.Settings _NPCSettings;
    //}
    public override void InstallBindings()
    {
        Container.BindInstance(Player._PlayerSettings);
        
        //Container.BindInstance(NPCSpawner._NPCSettings);
    }
}