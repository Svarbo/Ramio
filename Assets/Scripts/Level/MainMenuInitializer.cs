using UnityEngine;

namespace Level
{
    public class MainMenuInitializer : ItemSceneInitializer
    {
        public override void InstantiateObjects()
        {
            Debug.Log(this.name);
        }
    }
}