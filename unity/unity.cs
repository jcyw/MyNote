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

//判斷用戶設備
// Application.platform == RuntimePlatform.Android


// RuntimePlatform 屬性：
    // OSXEditor	In the Unity editor on macOS.
    // OSXPlayer	In the player on macOS.
    // WindowsPlayer	In the player on Windows.
    // WindowsEditor	In the Unity editor on Windows.
    // IPhonePlayer	In the player on the iPhone.
    // Android	In the player on Android devices.
    // LinuxPlayer	In the player on Linux.
    // LinuxEditor	In the Unity editor on Linux.
    // WebGLPlayer	In the player on WebGL
    // WSAPlayerX86	In the player on Windows Store Apps when CPU architecture is X86.
    // WSAPlayerX64	In the player on Windows Store Apps when CPU architecture is X64.
    // WSAPlayerARM	In the player on Windows Store Apps when CPU architecture is ARM.
    // PS4	In the player on the Playstation 4.
    // XboxOne	In the player on Xbox One.
    // tvOS	In the player on the Apple's tvOS.
    // Switch	In the player on Nintendo Switch.
    // Stadia	In the player on Stadia.
    // CloudRendering	In the player on CloudRendering.
    // PS5	In the player on the Playstation 5.


    //UNITY 默认DX改成OPENGL   ---》unity图标——右键属性——目标 后面加 空格-force-gles

    //Unity安卓平台shader平台丢失
    // Unity的工程切换到Android平台后，运行游戏出现shader丢失

    // 解决办法：在Unity桌面图标的快捷方式后添加 -force-gles20

    //几种加载方式的区别:
    // 其实存在3种加载方式：

    // 一是静态引用，建一个public的变量，在Inspector里把prefab拉上去，用的时候instantiate

    // 二是Resource.Load，Load以后instantiate

    // 三是AssetBundle.Load,Load以后instantiate

    // 三种方式有细 节差异，前两种方式，引用对象texture是在instantiate时加载，
        //而assetBundle.Load会把perfab的全部assets 都加载，instantiate时只是生成Clone。
        //所以前两种方式，除非你提前加载相关引用对象，否则第一次instantiate时会包含加载引用 assets的操作，导致第一次加载的lag（滞后）。

    // Unity中的内存种类
    // 实际上Unity游戏使用的内存一共有三种**：程序代码、托管堆（Managed Heap）以及本机堆（Native Heap）**。

    // 程序代码包括了所有的Unity引擎，使用的库，以及你所写的所有的游戏代码。在编译后，得到的运行文件将会被加载到设备中执行，并占用一定内存。

    // 这部分内存实际上是没有办法去“管理”的，它们将在内存中从一开始到最后一直存在。一个空的Unity默认场景，什么代码都不放，在iOS设备上占 用内存应该在17MB左右，而加上一些自己的代码很容易就飙到20MB左右。想要减少这部分内存的使用，能做的就是减少使用的库，稍后再说。

    // 托管堆是被Mono使用的一部分内存。Mono项目一个开源的.net框架的一种实现，对于Unity开发，其实充当了基本类库的角色。

    // 托管堆用来存放类的实例（比如用new生成的列表，实例中的各种声明的变量等）。“托管”的意思是Mono“应该”自动地改变堆的大小来适应你所需要的内存，

    // 并且定时地使用垃圾回收（Garbage Collect）来释放已经不需要的内存。关键在于，有时候你会忘记清除对已经不需要再使用的内存的引用，

    // 从而导致Mono认为这块内存一直有用，而无法回收。

    // 最后，本机堆是Unity引擎进行申请和操作的地方，比如贴图，音效，关卡数据等。Unity使用了自己的一套内存管理机制来使这块内存具有和托管堆类似的功能。

    // 基本理念是，如果在这个关卡里需要某个资源，那么在需要时就加载，之后在没有任何引用时进行卸载。听起来很美好也和托管堆一样，

    // 但是由于Unity有一套自动加载和卸载资源的机制，让两者变得差别很大。自动加载资源可以为开发者省不少事儿，

    // 但是同时也意味着开发者失去了手动管理所有加载资源的权力，这非常容易导致大量的内存占用（贴图什么的你懂的），

    // 也是Unity给人留下“吃内存”印象的罪魁祸首。

    //来源：
    //https://blog.csdn.net/m0_46184795/article/details/108266234?utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7EOPENSEARCH%7Edefault-12.control&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7EOPENSEARCH%7Edefault-12.control

    //网友优化建议：
    //     分享一点我们自己在做性能优化时的小经验：在Unity Editor模式下运行，有部分Overhead是由运行时的场景编辑器导致的，采样的时候可以先把“Scene”关掉。
    //     用Profiler采样时，首先重点关注CPU占用率高的方法，并且优先打击关注内存分配“GC Alloc”，
    //     每帧超过100B的内存分配都需要解决，否则这样的的内存分配累积后就会引起GC，很容易引起卡顿
    //     字符串串接使用stringbuilder不使用+，频繁foreach最好用for代替，缓存已经取到的componet.


    //Application.dataPath : 绝对路径到Assets
