using UnityEngine;

public class LoaderRecall : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Awake()
    {
        //GameManager.instance.ManualTurnOff();
    }

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderRecall();
        }
    }
}
