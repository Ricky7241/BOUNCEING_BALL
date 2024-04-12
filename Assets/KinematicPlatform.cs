using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class KinematicPlatform : MonoBehaviour
{

    public float cycleruntime;
    public float cyclewait;
    protected float currentcycletime;
    protected float currentwaitcycle;

    public enum CycleType { repeat, pingpong };
    public CycleType cycletype;

    protected sbyte cycledirection = 1;

            
    protected Rigidbody2D rg;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    protected virtual void Reset()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (cyclewait <=0)
        {// cylce is running

            currentcycletime += Time.deltaTime * cycledirection; 
            // handle end of cycle 
            CycleEnd();
        } else
        {// cyle not running 
            cyclewait -= Time.deltaTime * cycledirection;
            // restsrt new cycle
            HandleCyclerestart();
        }


    }
    void HandleCyclerestart()
    {
        if (cyclewait <=0)
        {
            currentcycletime -= cyclewait;
            cyclewait = 0;

        }
    }

    void CycleEnd()
    {
        switch (cycletype)
        {
            case CycleType.repeat:
                // Once exceed run time goes back to zer0;
                if (currentcycletime > cycleruntime)
                {
                    currentwaitcycle = cyclewait -(currentcycletime - cycleruntime);
                    currentcycletime = 0;
                }
                break;
            case CycleType.pingpong:
                // inverts the cycle;
                if (currentcycletime > 0) {
                    currentwaitcycle = cyclewait - (currentcycletime - cycleruntime);
                    cycledirection = -1;
                    currentcycletime = cycleruntime;
                } else if(currentcycletime < 0) {
                    currentwaitcycle = cyclewait - currentcycletime;
                    cycledirection = 1;
                    currentcycletime = 0;
                }
                break;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController p = collision.collider.GetComponent<PlayerController>();
        if (p) 
        {
            p.transform.SetParent(transform);

        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController p = collision.collider.GetComponent<PlayerController>();
        if (p)
        {
            p.transform.SetParent(null);

        }
    }



}




