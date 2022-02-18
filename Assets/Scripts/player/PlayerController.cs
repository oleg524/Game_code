using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    #region Singelton
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField] private Interactable focus;
    [SerializeField] private Camera cam;
    private PlayerMotor motor;
    private PlayerAttack playerAttack;

    public Ability EspecialShells;


    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        NoveMeshTranslating();

        if (Input.GetMouseButtonDown(1))
            Shooting();
    }
    private void NoveMeshTranslating()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(ray, out Hit, 100))
            {
                motor.MoveToPoint(Hit.point); // Player Move

                Interactable interacteble = Hit.collider.GetComponent<Interactable>(); // Focus Interacteble
                if (interacteble != null)
                {
                    SetFocus(interacteble);
                }

                if ((interacteble == null))
                {
                    RemoveFocus();
                }

            }

        }
    }
    void SetFocus(Interactable NewFocus)
    {
        if (NewFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = NewFocus;
            motor.FollowTarget(NewFocus);
        }
        NewFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowTarget();
    }
    private void Shooting()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit ArrowHit;

        if (Physics.Raycast(ray, out ArrowHit, 100))
        {
            playerAttack.Shoot(ArrowHit, EspecialShells);
        }

        Vector3 relativePos = ArrowHit.point - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos); // look at target position
    }
}