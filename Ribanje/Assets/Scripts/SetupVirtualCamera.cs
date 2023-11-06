using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetupVirtualCamera : MonoBehaviour
{
    //postavi igraca kao followa da ne moram to stalno radit
    public GameObject Kamera;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        this.GetComponent<CinemachineVirtualCamera>().Follow = Player.transform;
        
    }

}
