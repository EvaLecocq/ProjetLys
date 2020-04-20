using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour
{
    public bool useRootPoint = true;
    public GameObject rootPoint;

    public GameObject[] cloudRound;
    public float[] cloudRoundSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(useRootPoint)
        {
            transform.position = new Vector3(rootPoint.transform.position.x, transform.position.y, rootPoint.transform.position.z);
        }

        for (int i = 0; i < cloudRound.Length; i++)
        {
            cloudRound[i].transform.Rotate(Vector3.up * cloudRoundSpeed[i]);
        }
    }
}
