using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Depth;
    public int Support = 10000;
    public int Money;
    public int PeopleCost;
    public int PeopleGain;
    public int EnergyCost;
    public int EnergyGain;

    public int Energy;
    public int People;

    public bool IsDrilling = true;

    public int Boosters = 0;

    private bool _reqBoost = false;
    private bool _getPaid = false;

    public LazerController LazerController;
    public TMP_Text PowerText;
    public TMP_Text PeopleText;
    public TMP_Text DepthText;
    public TMP_Text MoneyText;
    public TMP_Text SupportText;
    public static ResourceManager Instance { get; private set; }

    private AudioSource _audioSource;

    public bool CheatMode = false;

    private int _nextPaidInterval = 250;
    private int _nextCostInterval = 500;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        InvokeRepeating("GetPaid", 5, 5);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PowerText.text = $"Energy: {Energy}";
        PeopleText.text = $"People: {People}";
        DepthText.text = $"{Depth}m Deep";
        MoneyText.text = $"Money: ${Money}";
        SupportText.text = $"{Mathf.Round(Support/10000f * 100)}% in Support";

        if (Input.GetKeyDown(KeyCode.M) && CheatMode)
        {
            Money += 1000;
        }
    }

    private void FixedUpdate()
    {
        Energy = EnergyGain - EnergyCost;
        People = PeopleGain - PeopleCost;

        if (IsDrilling)
        {
            if (People >= 0 && Energy >= 0)
            {
                Depth += 1 + (Boosters * 1);
                LazerController.LazerBeam.SetActive(true);
            }
            else
            {
                LazerController.LazerBeam.SetActive(false);
                Support -= 2;
            }

            if (Depth >= _nextCostInterval)
            {
                if (!_reqBoost)
                {
                    EnergyCost += 1;
                    _nextCostInterval += 500;
                    _reqBoost = true;
                }
            }
            else
            {
                _reqBoost = false;
            }
        }
        else
        {
            Support -= 2;
        }

        if (Support <= 0)
        {
            SceneManager.LoadScene("FailScene");
        }

        if (Depth >= 50000)
        {
            SceneManager.LoadScene("WinScene");
        }


    }

    public void GetPaid()
    {
        Money += (People * 25);
        _audioSource.Play();
    }
}
