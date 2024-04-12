using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovingPlatform : KinematicPlatform
{
    public Vector2 endpoint;
    Vector2 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.position = Vector2.Lerp(origin, endpoint, currentwaitcycle / cycleruntime);
    }

    protected override void Reset()
    {
        base.Reset();
        // staright line

        endpoint = transform.position + transform.right * 8;

        cycletype = CycleType.pingpong;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, endpoint);
    }

}
