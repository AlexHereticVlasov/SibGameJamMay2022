using UnityEngine;


public class EnergyLine : BaseActivalible
{
    [SerializeField] private Segment[] _segments;
    [SerializeField] private BaseActivalible _next;

    bool _hasPower;

    private void OnEnable()
    {
        foreach (var segment in _segments)
        {
            //Subscribe on repered event;
            segment.Interacted += OnInteracted;
        }
    }

    private void OnDisable()
    {
        foreach (var segment in _segments)
        {
            //Subscribe on repered event;
            segment.Interacted -= OnInteracted;
        }
    }

    private void OnInteracted()
    {
        if (_hasPower)
        {
            if (IsRepeared())
            {
                _next.TryActivate();

                foreach (var segment in _segments)
                {
                    segment.GivePower();
                }
            }
        }
    }

    public override void Activate()
    {
        _next.TryActivate();

        foreach (var segment in _segments)
        {
            segment.GivePower();
        }
    }

    //3states

    public bool IsRepeared()
    {
        foreach (var segment in _segments)
        {
            if (segment.State == SegmentState.Broken)
            {
                return false;
            }
        }

        return true;
    }

    public override bool TryActivate()
    {
        _hasPower = true;
        if (IsRepeared())
        {
            Activate();
            return true;
        }

        return false;
    }
}

public enum SegmentState { Broken, NoEnergy, HasEnergy, Repeared, RepearedAndHasEnergy}
