using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController GC;
    Demonio demonio;
    public Jugador jugador;
    public int x = 5;

    void Awake()
    {
        if (GC != null && GC != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GC = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public Jugador GetJugador()
    {
        return jugador;
    }

    public void SpawnEnemigo()
    {

    }

    void Update()
    {
      //  print(GetJugador());
    }
}
