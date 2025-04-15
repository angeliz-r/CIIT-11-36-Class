using TMPro;
using UnityEngine;

public class TimedButton2D : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private GameObject[] _HiddenObjects;
    [SerializeField] private TextMeshProUGUI _timerNum;
    private float _timer;
    private Animator _animator;
    private bool _startTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timer = _timeLimit;
        _timerNum.text = "";
        _animator = GetComponent<Animator>();
        _startTime = false;
        foreach (GameObject obj in _HiddenObjects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTime)
        {
            _timer -= Time.deltaTime;
            _timerNum.text = _timer.ToString("0");
            ActivateButton();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySFX("lazer");
            _animator.SetBool("IsPressed", true);
            _startTime = true;
        }
    }

    private void ActivateButton()
    {
        foreach (GameObject obj in _HiddenObjects)
        {
            obj.SetActive(true);
        }
        if (_timer < 0)
        {
            AudioManager.Instance.PlaySFX("lazer");
            _animator.SetBool("IsPressed", false);
            foreach (GameObject obj in _HiddenObjects)
            {
                obj.SetActive(false);
            }
            _startTime = false;
            _timerNum.text = "";
            _timer = _timeLimit;
        }
    }
}
