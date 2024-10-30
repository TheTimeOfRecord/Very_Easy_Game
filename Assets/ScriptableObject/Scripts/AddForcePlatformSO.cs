using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AddForcePlatform", menuName = "Platform/AddForcePlatform")]
public class AddForcePlatformSO : ScriptableObject
{
    public ForceMode forceMode;
    public Vector3 direction;
    public float power;
}
