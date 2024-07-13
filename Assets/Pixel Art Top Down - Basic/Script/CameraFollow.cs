using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    // Let the camera follow the target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;      // The target the camera follows
        public float lerpSpeed = 1.0f; // Speed at which the camera follows

        private Vector3 offset;       // Offset distance between camera and target
        private Vector3 targetPos;    // The target position the camera will move to

        private void Start()
        {
            // If no target is set, return early
            if (target == null) return;

            // Calculate the offset between the camera and the target
            offset = transform.position - target.position;
        }

        private void Update()
        {
            // If no target is set, return early
            if (target == null) return;

            // Calculate the target position with the offset
            targetPos = target.position + offset;

            // Smoothly interpolate the camera's position to the target position
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
    }
}
