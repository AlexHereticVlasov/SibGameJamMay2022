using UnityEngine;

public sealed class UserInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private Checks _checks;
    [SerializeField] private PauseMenu _pauseMenu;

    private float _horizontal;

    private void Update() => ReadInput();

    private void ReadInput()
    {
        _horizontal = Input.GetAxisRaw(Horizontal);
        _checks.SetXInput((int)_horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            _checks.SetIsJumping(true);
        else if (Input.GetKeyUp(KeyCode.Space))
            _checks.SetIsJumping(false);

        if (Input.GetKeyDown(KeyCode.F))
            _checks.SetInteract();

        if (Input.GetKeyDown(KeyCode.Escape))
            _pauseMenu.ChangeActivity();
    }
}

