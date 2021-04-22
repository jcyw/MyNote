using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // 容量是一个常量，最好取二的幂值，这样的话可以刚好占用所有内存位的资源，避免浪费。
    private const int maxCount = 128;
    private Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();

    public GameObject GetObj(GameObject perfab)
    {
        //池子中有
        GameObject result = null;
        if (pool.ContainsKey(perfab.name))
        {
            if (pool[perfab.name].Count > 0)
            {
                result = pool[perfab.name][0];
                if (result != null)
                {
                    result.SetActive(true);
                    pool[perfab.name].Remove(result);
                    return result;
                }
                else
                {
                    pool.Remove(perfab.name);
                }
            }
        }
        //池子中缺少
        result = Object.Instantiate(perfab);
        result.name = perfab.name;
        RecycleObj(result);
        GetObj(result);
        return result;
    }

    public GameObject GetObj(GameObject perfab, Transform parent)
    {
        var result = GetObj(perfab);
        result.transform.SetParentSafe(parent);
        return result;
    }

    public void RecycleObj(GameObject obj)
    {
        var par = Camera.main;
        obj.transform.SetParentSafe(par.transform);
        obj.SetActive(false);

        if (pool.ContainsKey(obj.name))
        {
            if (pool[obj.name].Count < maxCount)
            {
                pool[obj.name].Add(obj);
            }
        }
        else
        {
            pool.Add(obj.name, new List<GameObject>() { obj });
        }
    }

    public void RecycleAllChildren(GameObject parent)
    {
        for (; parent.transform.childCount > 0;)
        {
            var tar = parent.transform.GetChild(0).gameObject;
            RecycleObj(tar);
        }
    }

    public void Clear()
    {
        pool.Clear();
    }
    
}