using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialGroup;
    //private float _timeLimit;
    //private float _timer;
    //private bool _isExitingArea;

    //private void Awake()
    //{
    //    _timeLimit = 10f;
    //    _timer = 0;
    //    _isExitingArea = false;
    //}
    private void Start()
    {
        //if (GameManager2D.Instance.IsNewGame())
        //{
        //    Debug.Log("Enable tutorial");
        //    EnableTutorial();
        //}
        //else if (!(GameManager2D.Instance.IsNewGame()))
        //{
        //    Debug.Log("no tutorial");
        //    DisableTutorial();
        //}
    }
    //private void Update()
    //{
    //    if (_isExitingArea)
    //    {
    //        Debug.Log("timer");
    //        _timer += Time.deltaTime;
    //        if (_timer > _timeLimit)
    //            DisableTutorial();
    //    }

    //}
    //private void OnTriggerExit(Collider collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        _isExitingArea = true;
    //        Debug.Log("triggered");
    //    }
    //}

    void DisableTutorial()
    {
        foreach(GameObject obj in tutorialGroup)
        {
            obj.SetActive(false);
        }
        //_isExitingArea = false;
    }

    void EnableTutorial ()
    {
        foreach (GameObject obj in tutorialGroup)
        {
            obj.SetActive(true);
        }
    }

}
