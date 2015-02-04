using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameObjectInfo : MonoBehaviour
{
    public int Team;

    private static Dictionary<int, GameObjectInfo> _infoDictionary = new Dictionary<int, GameObjectInfo>();

    void Start()
    {
        Register(this);
    }


    public static void Register(GameObjectInfo info)
    {
        _infoDictionary.Add(info.gameObject.GetInstanceID(), info);
    }

    public static void UnRegister(GameObjectInfo info)
    {
        _infoDictionary.Remove(info.gameObject.GetInstanceID());
    }

    public static GameObjectInfo GetObjectInfoById(int id)
    {
        GameObjectInfo info = null;

        _infoDictionary.TryGetValue(id, out info);

        return info;
    }

    void OnDestroy()
    {
        UnRegister(this);
    }
}
