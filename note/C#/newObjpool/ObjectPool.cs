using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;  // 预制体
    public int poolSize;       // 对象池大小
    private ObjectPool bulletPool;  // 对象池

    private List<GameObject> objectPool;  // 对象池列表

    private void Start()
    {
        objectPool = new List<GameObject>();  // 初始化对象池

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);  // 创建预制体

            obj.SetActive(false);  // 设置为不激活状态

            objectPool.Add(obj);   // 添加到对象池列表中
        }
    }

    // 从对象池中获取可用的游戏对象
    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);

        newObj.SetActive(true);

        objectPool.Add(newObj);

        return newObj;
    }

    void Start() 
    {
        bulletPool = GetComponent<ObjectPool>();  // 获取对象池
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = bulletPool.GetObjectFromPool();  // 从对象池中获取 Bullet 游戏对象

            bullet.transform.position = transform.position;  // 设置坐标为当前物体位置

            bullet.transform.rotation = transform.rotation;  // 设置旋转角度为当前物体旋转角度
        }
    }

}