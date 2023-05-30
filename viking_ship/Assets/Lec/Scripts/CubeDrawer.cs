using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{
    private Renderer _renderer;
    private Material originalMaterial;
    private Material selectMaterial;

    private bool isClosed = true;
    private bool isAnimationPlaying = false;

    private Vector3 closedPosition;
    private Vector3 openedPosition;

    public float animPlayTime = 0.5f;
    public float animDistance = 0.5f;

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        originalMaterial = _renderer.material;
        selectMaterial = new Material(originalMaterial);
        selectMaterial.color = new Color(0f, 1f, 0f);

        closedPosition = this.transform.position;
        openedPosition = this.transform.position - Vector3.forward * animDistance;
    }

    public void HoverIn()
    {
        _renderer.material = selectMaterial;
    }

    public void HoverOut()
    {
        _renderer.material = originalMaterial;
    }

    public void Select()
    {
        Debug.Log("Drawer Selected...");
        if(isClosed)
        {
            if(!isAnimationPlaying)
            {
                isAnimationPlaying = true;
                StartCoroutine("PlayOpeningAnimation");
            }
        }
        else
        {
            if (!isAnimationPlaying)
            {
                isAnimationPlaying = true;
                StartCoroutine("PlayClosingAnimation");
            }
        }
    }

    IEnumerator PlayOpeningAnimation()
    {
        float curTime = 0f;
        while (curTime / animPlayTime < 1.0f)
        {
            curTime += Time.deltaTime;
            Vector3 currentPos = Vector3.Lerp(closedPosition, openedPosition, curTime / animPlayTime);
            this.transform.position = currentPos;
            yield return null;
        }

        isAnimationPlaying = false;
        isClosed = false;
    }

    IEnumerator PlayClosingAnimation()
    {
        float curTime = 0f;
        while (curTime / animPlayTime < 1.0f)
        {
            curTime += Time.deltaTime;
            Vector3 currentPos = Vector3.Lerp(openedPosition, closedPosition, curTime / animPlayTime);
            this.transform.position = currentPos;
            yield return null;
        }

        isAnimationPlaying = false;
        isClosed = true;
    }
}
