using UnityEngine;
using UnityEngine.Events;

public class SaveZone : BaseActivalible
{
    [SerializeField] private BaseActivalible _next;
    [SerializeField] private bool _isActive;
    [SerializeField] private int _needOrigins;

    private int _currentOrigins;

    public event UnityAction Activated;

    public override void Activate()
    {
        Activated?.Invoke();
        _isActive = true;
    }

    public override bool TryActivate()
    {
        //if (_line.IsRepeared())
        //{
        //    Activate();
        //    return true;
        //}

        //return false;
        _currentOrigins++;
        if (_currentOrigins == _needOrigins)
        {
            Activate();
            _next.TryActivate();
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_isActive)
            {
                player.EnterZone(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            //set _isInSavty = false;
            player.ExitZone();
        }
    }
}


