using UnityEngine;
using System.Collections;

public class ResizingController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lerpSpeed;


    [SerializeField] private Vector2 bigScale;
    [SerializeField] private Vector2 smallScale;

    [SerializeField]  private Vector3 _newScale;

    private void Awake()
    {
        _newScale = transform.localScale;
    }
    void Update()
    {
        //Move player
        transform.Translate(speed * Time.deltaTime * transform.forward);

        //Scale player up
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            _newScale = new Vector3(bigScale.x, bigScale.y, transform.localScale.z);
            gameObject.transform.GetChild(0).position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        //Scale player down
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            _newScale = new Vector3(smallScale.x, smallScale.y, transform.localScale.z);
            gameObject.transform.GetChild(0).position = new Vector3(transform.position.x, -0.25f, transform.position.z);
        }

        ScaleLerping();
    }
    private void ScaleLerping()
    {
        if (transform.localScale != _newScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _newScale, lerpSpeed * Time.deltaTime);
        }
    }
}
