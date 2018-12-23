using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceRotate : MonoBehaviour { //偵測手機陀螺儀

    private const float lowPassFilterFactor = 0.2f;

    //可讓手機震動！
    void Update()
    {
        CheckVibrate();
    }

    private void CheckVibrate()
    {
        m_newAcceleration = Input.acceleration; //抓手機陀螺儀位置
        m_detalAcceleration = m_newAcceleration - m_oldAcceleration;
        m_oldAcceleration = m_newAcceleration;

        if (m_detalAcceleration.x > m_checkValue ||
            m_detalAcceleration.y > m_checkValue ||
            m_detalAcceleration.z > m_checkValue)
        {
            /// 手机震动
            Handheld.Vibrate();

            // 填滿可樂
            // Step one
            ShakeCola[] clones = FindObjectsOfType<ShakeCola>();

            // Step two
            foreach (var shakeCola in clones)
                shakeCola.CmdShakeCola();
            //print("success!");


        }

    }

    [SerializeField] //Serialize功能(序列化的意思是说再次读取Unity时序列化的变量是有值的，不需要你再次去赋值，因为它已经被保存下来)
    protected float m_checkValue = 0.8f;

    private Vector3 m_detalAcceleration;
    private Vector3 m_oldAcceleration;
    private Vector3 m_newAcceleration;

}
