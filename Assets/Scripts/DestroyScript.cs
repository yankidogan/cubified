using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("AdditionalCube(Clone)"))
        {
            Destroy(collision.gameObject);
        }
    }
}
