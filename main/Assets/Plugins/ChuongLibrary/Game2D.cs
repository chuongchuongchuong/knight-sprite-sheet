using System;
using UnityEngine;
namespace ChuongLibrary.GameDev
{
    public static class Game2D
    {
        // Hàm gốc: target là Vector3. Hướng của theLooker ban đầu là hướng lên trên
        public static void LookAtTarget(Transform theLooker, Vector3 target)
        {
            var diff = (target - theLooker.position).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            theLooker.rotation = Quaternion.Euler(0, 0, rotZ - 90);
        }
        
        // Overload 1: target là Transform
        public static void LookAtTarget(Transform theLooker, Transform target)
        {
            LookAtTarget(theLooker, target.position);
        }
        
        // Overload 2: target là Vector3, thêm offset góc (góc bù này dương thì quay ngược chiều kim đồng hồ)
        public static void LookAtTarget(Transform theLooker, Vector3 target, float offsetAngle)
        {
            var diff = (target - theLooker.position).normalized;
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            theLooker.rotation = Quaternion.Euler(0, 0, rotZ - 90 + offsetAngle);
        }
        
        // Overload 3: target là Transform, thêm offset góc (góc bù này dương thì quay ngược chiều kim đồng hồ)
        public static void LookAtTarget(Transform theLooker, Transform target, float offsetAngle)
        {
            LookAtTarget(theLooker, target.position, offsetAngle);
        }

        /*public static void GuaranteeSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("More than one " + GetType().Name + " in scene.");
                return;
            }

            Instance = this;
        }*/
    }
}