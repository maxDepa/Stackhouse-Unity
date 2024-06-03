using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Vector3 TargetPosition => new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
            );

        private void LateUpdate() {
            transform.position = TargetPosition;
            //transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.75f * Time.deltaTime);
        }
    }

}