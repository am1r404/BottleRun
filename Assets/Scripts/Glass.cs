using DG.Tweening;
using UnityEngine;

public class Glass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            PlayerController.OnWineGlassFill.Invoke();
            GetComponent<Collider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.DOMoveY(transform.position.y + 0.1f, 0.1f)
                .OnComplete(() =>
                    transform.DOScale(transform.localScale * 1.3f, 0.2f)
                        .OnComplete(() => transform.DOScale(transform.localScale / 1.3f, 0.2f)
                            .OnComplete(() => { transform.DOMoveY(transform.position.y - 0.1f, 0.1f); }))
                );
        }
    }
}