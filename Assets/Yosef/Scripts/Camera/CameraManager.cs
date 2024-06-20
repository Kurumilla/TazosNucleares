using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    Pivot,      //Rotate around the playground
    Swivel,     //Tilt the camera around
    Focus,      //Lerp position and rotation
    Unfocus     //Return from focus
}

public class CameraManager : MonoBehaviour
{
    public Mode _mode;
    private Mode mode;
    Pivot pivot;
    Swivel swivel;
    Focus focus;

    bool isDone;
    public Transform target;
    private RoundOver ro;
    
    void Start()
    {
        ro = GameObject.Find("Scripts Manager").GetComponent<RoundOver>();
        pivot = GetComponent<Pivot>();
        swivel = GetComponentInChildren<Swivel>();
        focus = GetComponent<Focus>();
        StartCoroutine("PresentPlayers");
    }

    private void Update()
    {
        ChangeMode();
        switch (mode)
        {
            case Mode.Pivot:
                pivot.CameraMovement();
                break;
            case Mode.Swivel:
                swivel.CameraMovement();
                break;
            case Mode.Focus:
                isDone = focus.CameraMovement(1);
                break;
            case Mode.Unfocus:
                isDone = focus.CameraMovement(-1);
                break;
        }
    }

    private void ChangeMode()
    {
        if (mode != Mode.Focus && _mode == Mode.Focus)          //If entering focus, set variables
            SetFocus();
        else if (mode == Mode.Focus && _mode != Mode.Focus)     //If exit from focus, go to unfocus instead
            mode = Mode.Unfocus;
        else if (mode == Mode.Unfocus && isDone)                //Wait for unfocus to be done
            mode = _mode;
        else if (mode != Mode.Unfocus)
            mode = _mode;
    }

    private void SetFocus()
    {
        focus.SetVariables(target);
        mode = Mode.Focus;
    }

    public void UI_Button()
    {
        if (_mode == Mode.Pivot)
            _mode = Mode.Swivel;
        else
            _mode = Mode.Pivot;
    }

    private IEnumerator PresentPlayers()
    {
        yield return new WaitForSeconds(2f);
        //Presentar al jugador
        target = GameObject.Find("Player").transform;
        _mode = Mode.Focus;
        yield return new WaitForSeconds(2f);
        //Return
        _mode = Mode.Pivot;
        yield return new WaitForSeconds(2f);
        //Presentar al enemigo
        target = GameObject.Find("Enemy").transform;
        _mode = Mode.Focus;
        yield return new WaitForSeconds(2f);
        //Return
        _mode = Mode.Pivot;
        yield return new WaitForSeconds(2f);
        ro.PlayerPhase();
    }
}
