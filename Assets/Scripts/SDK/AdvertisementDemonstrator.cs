using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;

public class AdvertisementDemonstrator : MonoBehaviour
{
    [SerializeField] private Image _advertisementPanel;

    private int _attemptCount;

    private void Start()
    {
        TryShow();
    }

    public void OnStartPlayButtonClick()
    {
        _advertisementPanel.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    private void TryShow()
    {
        IncreaseAttemptsCount();

        if (_attemptCount % 3 == 0)
        {
            Show();

            Time.timeScale = 0;
        }
        else
        {
            _advertisementPanel.gameObject.SetActive(false);
        }

        //UnityEngine.PlayerPrefs.Save();
    }

    private void IncreaseAttemptsCount()
    {
        _attemptCount = UnityEngine.PlayerPrefs.GetInt("AttemptCount");
        _attemptCount++;
        UnityEngine.PlayerPrefs.SetInt("AttemptCount", _attemptCount);
    }

    private void Show()
    {
        InterstitialAd.Show();
    }
}