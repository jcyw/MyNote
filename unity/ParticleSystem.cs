// 属性	功能
// Duration	系统运行的时间长度。
// Looping	如果启用此属性，系统将在其持续时间结束时再次启动并继续重复该循环。
// Prewarm	如果启用此属性，系统将初始化，就像已经完成一个完整周期一样（仅当 Looping 也启用时才有效）。
// Start Delay	启用此属性后，系统开始发射前将延迟一段时间（以秒为单位）。
// Start Lifetime	粒子的初始生命周期。
// Start Speed	每个粒子在适当方向的初始速度。
// 3D Start Size	如果要分别控制每个轴的大小，请启用此属性。
// Start Size	每个粒子的初始大小。
// 3D Start Rotation	如果要分别控制每个轴的旋转，请启用此属性。
// Start Rotation	每个粒子的初始旋转角度。
// Flip Rotation	使一些粒子以相反的方向旋转。
// Start Color	每个粒子的初始颜色。
// Gravity Modifier	缩放 Physics 窗口中设置的重力值。值为零会关闭重力。
// Simulation Space	控制粒子的运动位置是在父对象的局部空间中（因此与父对象一起移动）、在世界空间中还是相对于自定义对象（与您选择的自定义对象一起移动）。
// Simulation Speed	调整整个系统更新的速度。
// Delta Time	在 Scaled 和 Unscaled 之间进行选择，其中的 Scaled 使用 Time 窗口中的 Time Scale 值，而 Unscaled 将忽略该值。此属性对于出现在暂停菜单 (Pause Menu) 上的粒子系统非常有用。
// Scaling Mode	选择如何使用变换中的缩放。设置为 Hierarchy、Local 或 Shape。Local 仅应用粒子系统变换缩放，忽略任何父级。Shape 模式将缩放应用于粒子起始位置，但不影响粒子大小。
// Play on Awake	如果启用此属性，则粒子系统会在创建对象时自动启动。
// Emitter Velocity	选择粒子系统如何计算 Inherit Velocity 和 Emission 模块使用的速度。系统可使用刚体组件（如果存在）或通过跟踪变换组件的移动情况来计算速度。
// Max Particles	系统中同时允许的最多粒子数。如果达到限制，则移除一些粒子。
// Auto Random Seed	如果启用此属性，则每次播放时粒子系统看起来都会不同。设置为 false 时，每次播放时系统都完全相同。
// Random Seed	禁用自动随机种子时，此值用于创建唯一的可重复效果。
// Stop Action	当属于系统的所有粒子都已完成时，可使系统执行某种操作。当一个系统的所有粒子都已死亡，并且系统存活时间已超过 Duration 设定的值时，判定该系统已停止。对于循环系统，只有在通过脚本停止系统时才会发生这种情况。
//     Disable	禁用游戏对象。
//     Destroy	销毁游戏对象。
//     Callback	将 OnParticleSystemStopped 回调发送给附加到游戏对象的任何脚本。
// Culling Mode	选择粒子在屏幕外时是否暂停粒子系统模拟。在屏幕外时进行剔除具有最高效率，但您可能希望继续进行非一次性 (off-one) 效果的模拟。
//     Automatic	循环系统使用 Pause__，而所有其他系统使用 Always Simulate。 | |    Pause And Catch-up | 系统在屏幕外时停止模拟。当重新进入视图时，模拟会执行一大步以到达在不暂停的情况下可实现的程度。在复杂系统中，此选项可能会导致性能尖峰。 | |    Pause | 系统在屏幕外时停止模拟。 | |    Always Simulate | 无论是否在屏幕上，系统始终处理每个帧的模拟。这对于烟花等一次性效果（在模拟过程中这些效果很明显）非常有用。 | | Ring Buffer Mode__	保持粒子存活直到它们达到 Max Particles 计数，此时新粒子会取代最早的粒子，而不是在它们的寿命终结时才删除粒子。
//     Disabled	禁用 Ring Buffer Mode__，以便系统在粒子生命周期终结时删除粒子。 | |    Pause Until Replaced | 在粒子生命周期结束时暂停旧粒子，直至达到 Max Particle__ 限制，此时系统会进行粒子再循环，因此旧粒子会重新显示为新粒子。
//     Loop Until Replaced	在粒子生命周期结束时，粒子将倒回到其生命周期的指定比例，直至达到 Max Particle 限制，此时系统会进行粒子再循环，因此旧粒子会重新显示为新粒子。


// Emission 模块

// 属性	功能
// Rate over Time	每个时间单位发射的粒子数。
// Rate over Distance	每个移动距离单位发射的粒子数。
// Bursts	爆发是指生成粒子的事件。通过这些设置可允许在指定时间发射粒子。
//     Time	设置发射爆发粒子的时间（粒子系统开始播放后的秒数）。
//     Count	设置可能发射的粒子数的值。
//     Cycles	设置播放爆发次数的值。
//     Interval	设置触发每个爆发周期的间隔时间（以秒为单位）的值。
//     Probability	控制每个爆发事件生成粒子的可能性。较高的值使系统产生更多的粒子，而值为 1 将保证系统产生粒子。


// Shape 模块
// 此模块用于定义可发射粒子的体积或表面以及起始速度的方向。Shape 属性定义发射体积的形状，其余模块属性根据您选择的 Shape 值而变化。

// 所有形状（Mesh 除外）都具有定义其大小的属性，例如 Radius 属性。要编辑这些属性，请在 Scene 视图中拖动线框发射器形状上的控制柄。形状的选择会影响可发射粒子的区域，但也会影响粒子的初始方向。例如，__球体 (Sphere)__ 向外向各个方向发射粒子，__锥体 (Cone)__ 发射发散的粒子流，而__网格 (Mesh)__ 在垂直于表面的方向上发射粒子。

// 以下部分将详细介绍每种__形状__的属性。

// 属性	功能
// Shape	发射体积的形状。
// Sphere	在所有方向均匀发射粒子。
// Hemisphere	在平面其中一面的所有方向均匀发射粒子。
// Radius	形状的圆形半径。
// Radius Thickness	发射粒子的体积比例。值为 0 表示从形状的外表面发射粒子。值为 1 表示从整个体积发射粒子。介于两者之间的值将使用体积的一定比例。
// Texture	用于为粒子着色和丢弃粒子的纹理。
// Clip Channel	纹理中用于丢弃粒子的通道。
// Clip Threshold	将粒子映射到纹理上的位置时，丢弃像素颜色低于此阈值的所有粒子。
// Color affects Particles	粒子颜色受纹理颜色影响。
// Alpha affects Particles	粒子 Alpha 受纹理 Alpha 影响。
// Bilinear Filtering	在读取纹理时，无论纹理尺寸如何，均组合 4 个相邻样本以获得更平滑的粒子颜色变化。
// Position	将一个偏移应用于生成粒子的发射器形状。
// Rotation	旋转生成粒子的发射器形状。
// Scale	更改生成粒子的发射器形状的大小。
// Align to Direction	根据粒子的初始行进方向定向粒子。如果想要模拟大块的汽车油漆在碰撞过程中飞出车身，此设置将非常有用。如果对该方向不太满意，也可通过在__主__模块中应用 Start Rotation 值来覆盖该设置。
// Randomize Direction	将粒子方向朝随机方向混合。设置为 0 时，此设置不起作用。设置为 1 时，粒子方向完全随机。
// Spherize Direction	将粒子方向朝球面方向混合，从它们的变换中心向外行进。设置为 0 时，此设置不起作用。设置为 1 时，粒子方向从中心向外（与 Shape 设置为 Sphere 时的行为相同）。
// Randomize Position	以随机量移动粒子，直至达到指定值。此属性设置为 0 时，此设置不起作用。任何其他值都会对粒子的生成位置应用一些随机性。