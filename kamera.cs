using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    public Transform takip_edilen_kup;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, takip_edilen_kup.position, Time.deltaTime * 3.0f);
    }

}
