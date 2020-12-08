using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerrycanController : MonoBehaviour
{
    [SerializeField]
    private int _cansTook;


    public void TakeJerrycan()
    {
        _cansTook++;
    }
}
