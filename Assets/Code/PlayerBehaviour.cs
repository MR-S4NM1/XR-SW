using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] protected InputActionProperty actionPropertyRight;
    [SerializeField] protected InputActionProperty actionPropertyLeft;

    //[SerializeField] protected GameObject rightRay;
    //[SerializeField] protected GameObject leftRay;

    #region UnityMethods
    private void Update()
    {
        //rightRay.SetActive(actionPropertyRight.action.ReadValue<float>() > 0.1f);
        //leftRay.SetActive(actionPropertyLeft.action.ReadValue<float>() > 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Return"))
        {
            GameManager.instance.ReturnPlayerToPlatform();
        }
        else if (other.gameObject.CompareTag("Final"))
        {
            GameManager.instance.ShowVictoryCanvas();
        }
    }

    #endregion

    #region


    #endregion
}
