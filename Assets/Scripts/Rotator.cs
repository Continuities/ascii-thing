﻿//Made By Stefan Jovanović
//Twitter: https://twitter.com/SJovGD
//Reddit: https://www.reddit.com/user/sjovanovic3107
//Unity Asset Store: https://assetstore.unity.com/publishers/32235
//Itch.io: https://stefanjo.itch.io/s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Range(0, 1)]
    public float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(speed, 0, 0));
    }
}
