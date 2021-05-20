
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