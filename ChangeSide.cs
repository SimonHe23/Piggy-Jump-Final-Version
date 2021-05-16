using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform t = collision.gameObject.transform;//get the conponent of that object(pig)
        t.position = new Vector3((-t.position.x) / 0.95f, t.position.y, 0f); //switch sides, which means change X values in to opposite, ex. if 5, change it into -5
    }
}
