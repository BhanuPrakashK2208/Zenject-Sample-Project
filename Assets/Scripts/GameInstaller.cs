using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallPlayer();
        //InstallNPCSpawner();
    }
    void InstallPlayer()
    {
        Container.Bind<PlayerController>().AsSingle();
    }
    //void InstallNPCSpawner()
    //{
    //    Container.Bind<SpawnPrefabGrid>().AsSingle();
        
    //}
}