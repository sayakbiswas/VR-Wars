using UnityEngine;
using System.Collections;

public class FollowUser : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 5.0f, f_MoveSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /* Look at Player*/
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

        /* Move at Player*/
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}