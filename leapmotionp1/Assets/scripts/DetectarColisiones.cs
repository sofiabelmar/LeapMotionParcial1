using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisiones : MonoBehaviour
{
    [SerializeField]
    IndicesTouchManager scriptAuxiliar;

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Cubo")){
            Debug.Log("Cubo Seleccionado");
            scriptAuxiliar.aux = 0;
        }
        if (collisionInfo.CompareTag("Piramide")){
            Debug.Log("Piramide Seleccionada");
            scriptAuxiliar.aux = 1;
        }
        if (collisionInfo.CompareTag("Esfera")){
            Debug.Log("Esfera Seleccionada");
            scriptAuxiliar.aux = 2;
        }
    }

}
