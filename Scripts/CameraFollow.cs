using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Transform border;
    public Transform[] target;
    private int target_index = 0;
    public Vector3 offset;
    public bool ending;
    private GameObject player;

    private void Start()
    {
        if (!ending)
        {
            target_index = respawn_manager.instance.getCamPosition();
            transform.position = target[target_index].position + offset;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (ending)
        {
            return;
        }
        if (target != null)
        {
            Vector3 desiredPosition = target[target_index].position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = transform.position;
        }
    }

    public void changelevel(bool scaleBig, bool scaleSmall)
    {
        if (target_index < target.Length - 1)
        {
            target_index++;
            respawn_manager.instance.setCamPosition(target_index);
        }
        if (scaleBig)
        {
            gameObject.GetComponentInChildren<Camera>().orthographicSize = 15f;
            border.position = new Vector3(transform.position.x - 24f, 0f, 0f); //need to recount
        }
        if (scaleSmall)
        {
            gameObject.GetComponentInChildren<Camera>().orthographicSize = 9f;
            border.position = new Vector3(transform.position.x - 16f, 0f, 0f);
        }
    }
}
