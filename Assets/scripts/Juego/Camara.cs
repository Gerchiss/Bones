using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Jugador jugador;
    float topeIzq = -2.68f;
    float topeDer = 2.68f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;

        float nuevaPosX = Mathf.Clamp(jugador.transform.position.x, topeIzq, topeDer);

        transform.position = new Vector3 (nuevaPosX, transform.position.y, transform.position.z);

        //transform.posicion = posicion;
    }
}
