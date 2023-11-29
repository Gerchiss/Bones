using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : Movilidad
{
    void Start()
    {
        velocidadH = 1;
        child = "caminar";
    }

}
