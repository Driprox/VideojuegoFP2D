using UnityEngine;

public class BalasDerecha : MonoBehaviour
{
    //Atributos publicos para el editor
    public float velocidad = 0.5f;
    public float tiempodeDestruccion = 2;

    void FixedUpdate() //Estabilizara mejor el movimiento
    {
        transform.Translate(Vector2.right * Time.deltaTime * velocidad);//Movera el aguijon en el eje x derecha por la velocidad marcada en el editor y configurada con la del sistema
        Destroy(gameObject, tiempodeDestruccion);//Destruira la bala en el tiempo especificado
    }
}
