using UnityEngine;

public class BalasIzquierda : MonoBehaviour
{
    //Atributos publicos para el editor
    public float velocidad = 0.5f;
    public float tiempodeDestruccion = 2;
    void FixedUpdate() //Estabilizara mejor el movimiento
    {
        transform.Translate(Vector2.left * Time.deltaTime * velocidad);//Movera el aguijon en el eje X por la izquierda por la velocidad marcada en el editor y configurada con la del sistema
        Destroy(gameObject, tiempodeDestruccion);//Destruira el bala en el tiempo especificado
    }
}
