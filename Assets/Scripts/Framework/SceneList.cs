using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct LevelScene
{
    public string name;
    public bool active;
};

public class SceneList : MonoBehaviour
{
    public List<LevelScene> levelScenes = new List<LevelScene>();

    [HideInInspector]
    public Dictionary<string, int> sceneId = new Dictionary<string, int>();

    void Start()
    {
        levelScenes = levelScenes.Where(x => x.active).ToList();

        for (int i = 0; i < levelScenes.Count; i++)
            sceneId[levelScenes[i].name] = i;
    }
}
