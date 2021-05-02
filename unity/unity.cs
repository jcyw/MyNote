// Vector2.Normalize
// 使该向量的 magnitude 为 1。

// Vector2.normalized
// 返回 magnitude 为 1 时的该向量。（只读）

// Vector3.Normalize
// 使该向量的 magnitude 为 1。

// Vector3.normalized
// 返回 magnitude 为 1 时的该向量。（只读）

// RaycastHit.normal
// 射线命中的表面的法线。

// RaycastHit2D.normal
// 射线命中的表面的法线矢量。

// using UnityEngine;

// public class Example : MonoBehaviour
// {
//     Transform gunObj;

//     void Update()
//     {
//         if (Input.GetMouseButton(0))
//         {
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//             if (Physics.Raycast(ray, out hit))
//             {
//                 Vector3 incomingVec = hit.point - gunObj.position;

//                 Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
                
//                 Debug.DrawLine(gunObj.position, hit.point, Color.red);
//                 Debug.DrawRay(hit.point, reflectVec, Color.green);
//             }
//         }
//     }
// }




// 在四元数 a 与 b 之间按比率 t 进行球形插值。参数 t 限制在范围 [0, 1] 内。

// 这可用于创建一个旋转，以基于参数的值 a，在第一个四元数 a 到第二个四元数 b 之间平滑进行插值。如果参数的值接近于 0，则输出会接近于 /a/，如果参数的值接近于 1，则输出会接近于 /b/。
// using UnityEngine;
// using System.Collections;

// public class ExampleClass : MonoBehaviour
// {
//     public Transform from;
//     public Transform to;

//     private float timeCount = 0.0f;

//     void Update()
//     {
//         transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
//         timeCount = timeCount + Time.deltaTime;
//     }
// }


// GameObject.Find
// public static GameObject Find (string name);
// 描述
// 按 name 查找 GameObject，然后返回它。

// 此函数仅返回活动 GameObject。如果未找到具有 name 的 GameObject，则返回 null。如果 name 包含“/”字符，则会向路径名称那样遍历此层级视图。

// 出于性能原因，建议不要每帧都使用此函数，而是在启动时将结果缓存到成员变量中，或者使用 GameObject.FindWithTag。

// 注意：如果您要查找子 GameObject，使用 Transform.Find 通常会更加轻松。

// 注意：如果正在使用多个场景运行此游戏，则 Find 将在所有这些场景中进行搜索。

// using UnityEngine;
// using System.Collections;

// // This returns the GameObject named Hand in one of the Scenes.

// public class ExampleClass : MonoBehaviour
// {
//     public GameObject hand;

//     void Example()
//     {
//         // This returns the GameObject named Hand.
//         hand = GameObject.Find("Hand");

//         // This returns the GameObject named Hand.
//         // Hand must not have a parent in the Hierarchy view.
//         hand = GameObject.Find("/Hand");

//         // This returns the GameObject named Hand,
//         // which is a child of Arm > Monster.
//         // Monster must not have a parent in the Hierarchy view.
//         hand = GameObject.Find("/Monster/Arm/Hand");

//         // This returns the GameObject named Hand,
//         // which is a child of Arm > Monster.
//         hand = GameObject.Find("Monster/Arm/Hand");
//     }
// }
// GameObject.Find 有助于在加载时自动连接对其他对象的引用；例如在 MonoBehaviour.Awake 或 MonoBehaviour.Start 内。

// 出于性能原因，建议不要每帧都使用此函数。

// 常见模式是将 GameObject 分配到 MonoBehaviour.Start 内的变量，然后在 MonoBehaviour.Update 中使用此变量。

// using UnityEngine;
// using System.Collections;

// // Find the GameObject named Hand and rotate it every frame

// public class ExampleClass : MonoBehaviour
// {
//     private GameObject hand;

//     void Start()
//     {
//         hand = GameObject.Find("/Monster/Arm/Hand");
//     }

//     void Update()
//     {
//         hand.transform.Rotate(0, 100 * Time.deltaTime, 0);
//     }
// }


// Object.Instantiate
// public static Object Instantiate (Object original);
// public static Object Instantiate (Object original, Transform parent);
// public static Object Instantiate (Object original, Transform parent, bool instantiateInWorldSpace);
// public static Object Instantiate (Object original, Vector3 position, Quaternion rotation);
// public static Object Instantiate (Object original, Vector3 position, Quaternion rotation, Transform parent);
// 参数
// original	要复制的现有对象。
// position	新对象的位置。
// rotation	新对象的方向。
// parent	将指定给新对象的父对象。
// instantiateInWorldSpace	分配父对象时，传递 true 可直接在世界空间中定位新对象。传递 false 可相对于其新父项来设置对象的位置。