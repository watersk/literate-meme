using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    private void Start ()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        string startingLocation = Assets.Scripts.Property.getLocation(waypointIndex);
        Debug.Log("starting location: " + startingLocation);
    }

    // Update is called once per frame
    private void Update()
    {
        if(moveAllowed)
        {
            Move();
        }
    }

    void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            string updatedLocation = Assets.Scripts.Property.getLocation(waypointIndex);
            Debug.Log("updated location: " + updatedLocation);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
