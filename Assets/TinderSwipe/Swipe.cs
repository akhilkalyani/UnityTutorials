using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Swipable
{
    public class Swipe : MonoBehaviour
    {
        [SerializeField]Vector3 pivot;
        Vector3 axis;
        float rightRotaionAngle = -23f;
        float leftRotaionAngle = 23f;
        // Start is called before the first frame update
        void Start()
        {
            axis = Vector3.forward;
            transform.RotateAround(pivot, axis, rightRotaionAngle);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
