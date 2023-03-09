using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShearingExample : MonoBehaviour
{
    public float shearIntensity = 0.5f;

    void Start()
    {
        // 添加 SpriteRenderer 渲染组件
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        // 设置渲染精灵的图片
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Character");

        // 创建剪切变换矩阵
        var shearMatrix = Matrix4x4.identity;
        shearMatrix.SetColumn(1, new Vector4(shearIntensity, 0, 0, 1));

        // 将剪切变换矩阵赋值给 additionalVertexStreams 属性
        spriteRenderer.additionalVertexStreams = shearMatrix;
    }
}