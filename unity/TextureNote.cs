
// 属性：	功能：
// Dimension	渲染纹理的尺寸
//      2D	渲染纹理将是二维的。
//      Cube	渲染纹理将是立方体贴图
//      3D	渲染纹理将是三维的
// Size	渲染纹理的大小（以像素为单位）。
// Color Format	渲染纹理的格式
// sRGB (Color Render Texture)	此渲染纹理是否使用 sRGB 读/写转换（只读）。
// Enable Mip Maps	此渲染纹理是否使用 MipMap？
// Auto generate Mip Maps	启用此属性可自动生成 MipMap。
// Wrap Mode	选择纹理平铺时的行为方式
//      Repeat	纹理重复（平铺）自身
//      Clamp	纹理的边缘被拉伸
// Filter Mode	选择纹理在通过 3D 变换拉伸时如何进行过滤：
//      Point	纹理在靠近时变为块状
//      Bilinear	纹理在靠近时变得模糊
//      Trilinear	与 Bilinear 类似，但纹理也在不同的 Mip 级别之间模糊
// Aniso Level	以大角度查看纹理时提高纹理质量。适用于地板和地面纹理


// Sprite (2D and UI) --2D 游戏中使用该纹理作为精灵

// 属性：	功能：
// Sprite Mode	指定从图像中提取精灵图形的方式。此选项的默认设置为 Single。
//  Single	按原样使用精灵图像。您可以在 Sprite Editor 中剪辑和编辑图像以进一步优化图像，但是 Unity 会将从导入纹理生成的精灵视为单个资源。
//  Multiple	如果您的图像在同一图像中有多个元素，请选择此值。然后，可以在 Sprite Editor 中定义元素的位置，以便 Unity 知道如何将图像拆分为不同的子资源。例如，可从具有多个姿势的单个图集创建动画帧，从单个瓦片图集创建瓦片，或创建角色的不同部位。
//  Polygon	选择此值可根据 Sprite Editor 的 Sprite Custom Outline 中定义的网格来剪辑精灵纹理。
// Packing Tag	（按名称）指定要将此纹理打包到的精灵图集。仅当项目中已启用 Legacy Sprite Packer 时，此属性才可见。
// Pixels Per Unity	精灵图像中对应于世界空间一个距离单位的宽度/高度像素数。
// Mesh Type	定义您希望 Unity 为精灵生成的网格类型。此选项的默认值为 Tight。

// 注意：只有 Single 和 Multiple 精灵模式才能使用此属性。
// Full Rect	选择此值可创建一个四边形，从而将精灵映射到四边形上。
// Tight	选择此值可基于像素 Alpha 值来生成网格。Unity 生成的网格通常贴合精灵的形状。

// 注意：任何小于 32x32 的精灵都使用 Full Rect__，即使指定了 Tight__ 也是如此。
// Extrude Edges	使用滑动条确定在生成的网格中的精灵周围留出的区域大小。
// Pivot	精灵本地坐标系所在的图像中的位置。选择预设选项之一，或者选择 Custom 在 X 和 Y 轴中设置自定义的轴心位置。

// 注意：只有 Single 精灵模式才能使用此属性。
// Generate Physics Shape	启用此属性后，如果尚未为此精灵定义 Custom Physics Shape，Unity 会从精灵的轮廓生成默认的物理性状。

// 注意：只有 Single 和 Multiple 精灵模式才能使用此属性。
// Sprite Editor	单击此按钮可定义您希望 Unity 如何分离具有多个元素的图像上的元素（以创建子资源）或优化多边形的形状、大小和轴心位置。

// 注意：需要安装 2D Sprite 包才能使用 Sprite Editor。有关如何在 Unity Package Manager 中查找和安装包的信息，请参阅查找包和从注册表中安装。
// sRGB (Color Texture)	启用此属性可指定将纹理存储在伽马空间中。
// Alpha Source	指定如何生成纹理的 Alpha 通道。
// Alpha is Transparency	如果指定的 Alpha 通道为透明度 (Transparency)，则启用此属性可扩充颜色并避免边缘上的过滤瑕疵。
// Remove Matte (PSD)	对使用透明度（将彩色像素与白色像素混合）的 Photoshop 文件启用特殊处理。
// Ignore PNG file gamma	启用此属性可忽略 PNG 文件中的伽马 (Gamma) 特性。
// Read/Write Enabled	启用此属性可以使用 Texture2D.SetPixels、Texture2D.GetPixels 和其他 Texture2D 方法从脚本访问纹理数据。
// Generate Mip Maps	选中此复选框可允许生成 Mipmap。

// 默认情况下会禁用此属性。
// Wrap Mode	选择纹理平铺时的行为方式。
// Filter Mode	选择纹理在通过 3D 变换拉伸时如何进行过滤。
// Aniso Level	以大角度查看纹理时提高纹理质量。



// 在Unity中，加载图片的大小取决于以下几个因素：

// 图片本身的分辨率和大小：加载一个高分辨率或大尺寸的图片将占用更多的内存，并且可能会导致应用程序加载速度变慢。

// 要在场景中显示的对象的大小和位置：如果要使用图片作为纹理贴图，那么贴图大小需要与对象的大小匹配。如果图片的大小与对象不匹配，则需要在运行时对其进行缩放，这将增加处理时间和内存消耗。

// 设备的屏幕分辨率：在移动设备上运行的应用程序通常需要考虑到不同的屏幕分辨率和长宽比，因此需要确保加载的图片尺寸和分辨率适合不同的设备。

// 压缩格式和解压缩方式：在Unity中可以使用多种不同的压缩格式来加载图片，包括PNG、JPG、TGA等。不同的压缩格式和解压缩方式可能会影响加载速度和内存占用。例如，PNG格式具有更好的压缩率和图像质量，但可能会增加解压时间和内存消耗。

// 综上所述，加载图片的大小取决于多个因素，包括图片本身的大小和分辨率、要显示的对象的大小和位置、设备的屏幕分辨率以及压缩格式和解压缩方式。因此，在开发过程中需要仔细考虑使用不同大小和分辨率的图片以及选择合适的压缩格式和解压缩方式来平衡内存占用和加载性能。