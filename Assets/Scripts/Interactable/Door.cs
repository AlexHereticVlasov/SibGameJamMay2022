using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Door : BaseActivalible
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private int _originNeed = 1;
    private int _currentOrigins = 0;

    public event UnityAction Victory;

    public override void Activate()
    {
        Debug.Log($"{this} Activated");
    }

    public override bool TryActivate()
    {
        //foreach (var line in Lines)
        //{
        //    if (line.IsRepeared() == false)
        //    {
        //        return false;
        //    }
        //}

        _currentOrigins++;

        if (_currentOrigins == _originNeed)
        {
            Activate();
        }

        return true;
    }

    private IEnumerator Open()
    {
        _animator.SetTrigger("Open");
        yield return new WaitForSeconds(1); //Anim Length;
        _boxCollider.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Victory?.Invoke();   
        }
    }
}

