using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        PlayerMovement PM = GetComponent<PlayerMovement>();

        transform.position += transform.right * PM.MoveSpeed * Time.deltaTime;
    }
}
