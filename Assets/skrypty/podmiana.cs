using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PodmianaObiektu : MonoBehaviour
{
    public GameObject dziadekWnuczekPrefab;
    public GameObject dziadekBabciaPrefab;
    public GameObject trzeciObiektPrefab;
    public Animator koniecAnimator;

    public float czasPodmiany = 5f;
    public float czasPojawianiaTrzeciegoObiektu = 15f;
    private float czasDoPodmiany = 0f;
    private float czasDoPojawianiaTrzeciegoObiektu = 0f;

    private void Start()
    {
        if (dziadekWnuczekPrefab == null || dziadekBabciaPrefab == null || trzeciObiektPrefab == null)
        {
            Debug.LogError("Przypisz prefaby dla obiektów dziadek-wnuczek, dziadek-babcia i trzeci obiekt w edytorze Unity!");
            enabled = false;
            return;
        }

        czasDoPodmiany = Time.time + czasPodmiany;
        czasDoPojawianiaTrzeciegoObiektu = Time.time + czasPojawianiaTrzeciegoObiektu;

        dziadekWnuczekPrefab.SetActive(true);
        dziadekBabciaPrefab.SetActive(false);
        trzeciObiektPrefab.SetActive(false);
    }

    private void Update()
    {
        if (Time.time >= czasDoPodmiany)
        {
            PodmienObiekt();
            czasDoPodmiany = Time.time + czasPodmiany;
        }

        if (Time.time >= czasDoPojawianiaTrzeciegoObiektu)
        {
            PojawienieTrzeciegoObiektu();
            czasDoPojawianiaTrzeciegoObiektu = Time.time + czasPojawianiaTrzeciegoObiektu;
        }
    }

    private void PodmienObiekt()
    {
        //Destroy(dziadekWnuczekPrefab);
        dziadekWnuczekPrefab.SetActive(false);
        dziadekBabciaPrefab.SetActive(true);
        trzeciObiektPrefab.SetActive(false);
    }

    private void PojawienieTrzeciegoObiektu()
    {
        Destroy(dziadekBabciaPrefab);
        Destroy(dziadekWnuczekPrefab);
        dziadekWnuczekPrefab.SetActive(false);
        dziadekBabciaPrefab.SetActive(false);
        trzeciObiektPrefab.SetActive(true);
        koniecAnimator.Play("2");

        // Wywo³anie metody przenosz¹cej do sceny "menu" po 5 sekundach
        Invoke("PrzeniesDoMenu", 5f);
    }

    private void PrzeniesDoMenu()
    {
        // Tutaj przenoszenie do sceny o nazwie "menu"
        SceneManager.LoadScene("menu");
    }
}



