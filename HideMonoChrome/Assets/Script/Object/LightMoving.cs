using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 光源を動かすスクリプト
// 主にマウスでプレイヤーが移動させる
// プレイヤー本体が動いてる時と、動いてない時で
// 揺れや光の強弱にメリハリをつける
public class LightMoving : MonoBehaviour
{
    Light _light;
    Vector2 _lightPos;
    float _posZ;

    void Start()
    {
        _light = this.GetComponent<Light>();
        _posZ = transform.position.z;
    }

    void Update()
    {
        SetLightPosition();
    }

    void SetLightPosition()
    {
        // マウス座標とスクリーンのサイズを考慮して
        // ライトの座標を設定する
        _lightPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = new Vector3(_lightPos.x,_lightPos.y,_posZ);
    }
}
