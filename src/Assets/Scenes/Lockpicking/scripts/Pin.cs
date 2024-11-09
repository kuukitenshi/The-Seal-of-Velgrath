using UnityEngine;

public class Pin : MonoBehaviour
{

    public static int pinCounter = 0;

    public int pinOrderNumber;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Lock") && pinCounter == pinOrderNumber)
        {
            Debug.Log("Pin hit lock");
            pinCounter++;
            this.gameObject.layer = LayerMask.NameToLayer("SetLayer");
        }
    }
}
