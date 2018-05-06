//using UnityEngine;
using System.Collections;

class RotateHelper 
{
    // 旋转转朝向
    public static Common.Vector3 GetForward(Common.Quaternion rotation)
    {
        return rotation * Common.Vector3.forward;
    }

    // 朝向转旋转
    public static Common.Quaternion LookAt(Common.Vector3 dir)
    {
        return Common.Quaternion.LookRotation(dir, Common.Vector3.up);
    }

#if UNITY_4 || UNITY_5
    public static Vector3 GetForwardClient(Quaternion rotation)
    {
        return rotation * Vector3.forward;
    }

    public static Quaternion LookAtClient(Vector3 dir)
    {
        return Quaternion.LookRotation(dir, Vector3.up);
    }
#endif
}
