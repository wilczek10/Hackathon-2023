using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zdjecie : Interakcja
{
    public GameObject zdjecie;

    protected override void Otworz()
    {
        zdjecie.SetActive(true);
    }

    protected override void Zamknij()
    {
        zdjecie.SetActive(false);
    }
}