using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("p");
    }

    void Update()
    {
        // �J�����̈ʒu���v���C���[�ɍ��킹��
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y-2, transform.position.z);
    }
}
