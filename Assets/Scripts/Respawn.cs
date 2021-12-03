using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    [SerializeField] private Transform respawn;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawn.transform.position;
    }
}
