using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodmianaObiektu : MonoBehaviour
{
    public GameObject dziadekWnuczekPrefab; // Przypisz prefab "dziadek-wnuczek" w edytorze Unity
    public GameObject dziadekBabciaPrefab;   // Przypisz prefab "dziadek-babcia" w edytorze Unity
    public GameObject trzeciObiektPrefab;    // Przypisz prefab trzeciego obiektu w edytorze Unity
    public Animator koniecAnimator;

    public float czasPodmiany = 5f;        // Czas (w sekundach) mi�dzy podmianami
    public float czasPojawianiaTrzeciegoObiektu = 15f; // Czas (w sekundach) mi�dzy pojawianiem si� trzeciego obiektu
    private float czasDoPodmiany = 0f;
    private float czasDoPojawianiaTrzeciegoObiektu = 0f;

    private void Start()
    {
        if (dziadekWnuczekPrefab == null || dziadekBabciaPrefab == null || trzeciObiektPrefab == null)
        {
            Debug.LogError("Przypisz prefaby dla obiekt�w dziadek-wnuczek, dziadek-babcia i trzeci obiekt w edytorze Unity!");
            enabled = false;
            return;
        }

        // Inicjalizacja czasu do pierwszej podmiany i pierwszego pojawienia si� trzeciego obiektu
        czasDoPodmiany = Time.time + czasPodmiany;
        czasDoPojawianiaTrzeciegoObiektu = Time.time + czasPojawianiaTrzeciegoObiektu;

        // Ustawienie dziadka-wnuczka jako aktywnego, a dziadka-babci� i trzeci obiekt jako nieaktywne na starcie
        dziadekWnuczekPrefab.SetActive(true);
        dziadekBabciaPrefab.SetActive(false);
        trzeciObiektPrefab.SetActive(false);
    }

    private void Update()
    {
        // Sprawdzanie, czy nadszed� czas na podmian� obiektu
        if (Time.time >= czasDoPodmiany)
        {
            PodmienObiekt();
            czasDoPodmiany = Time.time + czasPodmiany; // Aktualizacja czasu do nast�pnej podmiany
        }

        // Sprawdzanie, czy nadszed� czas na pojawienie si� trzeciego obiektu
        if (Time.time >= czasDoPojawianiaTrzeciegoObiektu)
        {
            PojawienieTrzeciegoObiektu();
            czasDoPojawianiaTrzeciegoObiektu = Time.time + czasPojawianiaTrzeciegoObiektu; // Aktualizacja czasu do nast�pnego pojawienia si� trzeciego obiektu
        }
    }

    private void PodmienObiekt()
    {
        dziadekWnuczekPrefab.SetActive(false);
        dziadekBabciaPrefab.SetActive(true);
        trzeciObiektPrefab.SetActive(false);
    }

    private void PojawienieTrzeciegoObiektu()
    {
        dziadekWnuczekPrefab.SetActive(false);
        dziadekBabciaPrefab.SetActive(false);
        trzeciObiektPrefab.SetActive(true);
        koniecAnimator.Play("2");
    }
}


