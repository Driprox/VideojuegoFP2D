using UnityEngine;

public class BolaPinchos : MonoBehaviour
{
    //Atributos
    public float velocidad;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * velocidad);//Rota la bola de pinchos por el eje de rotacion
    }
}
