using UnityEngine;

public class Delivery : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] float destroyDelayTime = 0f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    //local variables.
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("You Crashed!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            //get package actions
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelayTime);
            hasPackage = true;

        }
        else if (other.tag == "Customer" && hasPackage)
        {
            //drop package actions    
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
