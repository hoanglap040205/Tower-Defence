using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camSpeed;
    private void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Input.mousePosition; 
            mousePosition.z = Mathf.Abs(cam.transform.position.z); 

            Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition); 
            StartCoroutine(MoveCamera(worldPosition));
        }
    }

    private IEnumerator MoveCamera(Vector3 targetPosition)
    {
        while ((cam.transform.position - targetPosition).magnitude > 0.1f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, camSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
