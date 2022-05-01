using UnityEngine;

public class SaveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            //Reset counter and set _isInSavty = true;
            player.EnterZone(this);
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


