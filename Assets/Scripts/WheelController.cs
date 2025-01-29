using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;
public class WheelController : MonoBehaviour
{
    [SerializeField] private GameViewModel viewModel;
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private Button spinButton;
    [SerializeField] private Transform wheel;
    [SerializeField] private TextMeshProUGUI[] numbers;
    [SerializeField] private WheelSO wheelData;
    private bool _isSpinning;

    void Start()
    {
        InitializeWheel();
        UpdateBalanceUI();
        spinButton.onClick.AddListener(OnSpinButtonPressed);
    }

    private void OnSpinButtonPressed()
    {
        if (_isSpinning) return;

        spinButton.interactable = false;
        _isSpinning = true;
        StartCoroutine(SpinWheel(wheelData.spinTime, wheelData.speed));
    }
    private void InitializeWheel()
    {
        viewModel.Initialize();
        for (int i = 0; i < viewModel.Model.SegmentValues.Length; i++)
        {
            numbers[i].text = viewModel.Model.SegmentValues[i].ToString();
        }
    }

    private IEnumerator SpinWheel(float spinDuration, float startSpeed)
    {
        float currentRotation = 0f;
        float elapsedTime = 0f;
        _isSpinning = true;
        spinButton.interactable = false;
        while (elapsedTime < spinDuration)
        {
            float t = elapsedTime / spinDuration;
            float easedT = 1f - Mathf.Pow(1f - t, 3f);
            float rotationSpeed = Mathf.Lerp(startSpeed, 0, easedT);
            float rotationStep = rotationSpeed * Time.deltaTime;
            currentRotation += rotationStep;
            wheel.rotation = Quaternion.Euler(0, 0, -currentRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        float finalAngle = currentRotation % 360f;
        float segmentLenght = 360f / viewModel.Model.SegmentValues.Length;
        int winningSegment = Mathf.FloorToInt(finalAngle / segmentLenght);
        viewModel.SpinWheel(winningSegment);
        UpdateBalanceUI();
        _isSpinning = false;
        spinButton.interactable = true;
    }


    private void UpdateBalanceUI()
    {
        balanceText.text = viewModel.FormattedBalance;
    }
}