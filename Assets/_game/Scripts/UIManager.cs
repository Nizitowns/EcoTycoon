using _game.Scripts;
using _game.Scripts.Managers;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum State
    {
        Main,
        Managers
    }

    [SerializeField] TMP_Text currentBalanceText;
    [SerializeField] TMP_Text companyNameText;
    [SerializeField] GameObject managerPanel;

    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Main;
    }

    private void OnEnable()
    {
        GameManager.OnUpdateBalance += UpdateUI;
        InitGameData.OnLoadDataComplete += UpdateUI;
    }

    private void OnDisable()
    {
        GameManager.OnUpdateBalance -= UpdateUI;
        InitGameData.OnLoadDataComplete -= UpdateUI;
    }

    public void UpdateUI()
    {
        currentBalanceText.text = GameManager.Instance.GetCurrentBalance().ToString("C2");
        companyNameText.text = GameManager.Instance.CompanyName;
    }

    void OnShowManagers()
    {
        currentState = State.Managers;
        managerPanel.SetActive(true);
    }

    void OnShowMain()
    {
        currentState = State.Main;
        managerPanel.SetActive(false);
    }

    public void OnClickManagers()
    {
        if (currentState == State.Main)
        {
            OnShowManagers();
        }
        else
        {
            OnShowMain();
        }
    }
}
