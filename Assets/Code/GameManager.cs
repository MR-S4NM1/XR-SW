using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region References

    public static GameManager instance;

    [SerializeField] protected GameObject[] _turrets;
    [SerializeField] protected GameObject[] _lightsabers;
    [SerializeField] protected GameObject[] _platforms;
    [SerializeField] protected GameObject _floor;
    [SerializeField] protected GameObject _finalTrigger;

    [SerializeField] protected MeshRenderer _buttonMeshRenderer;
    [SerializeField] protected Material _buttonOffMaterial;
    [SerializeField] protected Material _buttonOnMaterial;

    #endregion

    #region UnityMethods

    private void Start()
    {
        //_buttonMeshRenderer.material = _buttonOffMaterial;

        ActivateLevelEvents();
    }


    #endregion

    #region PublicMethods

    public void ActivateLevelEvents()
    {
        StartCoroutine(ActivateObjectsAndCollapseFloor());
    }

    public void ChangeToVictoryScene()
    {

    }

    #endregion

    #region LocalMethods

    protected IEnumerator ActivateObjectsAndCollapseFloor()
    {
        _buttonMeshRenderer.material = _buttonOnMaterial;

        _finalTrigger.gameObject.SetActive(true);

        foreach (GameObject turret in _turrets)
        {
            turret.SetActive(true);
        }

        foreach (GameObject lightsabers in _lightsabers)
        {
            lightsabers.SetActive(true);
        }

        StartCoroutine(CollapseFloor());

        yield return new WaitForSeconds(2.0f);

        foreach (GameObject platforms in _platforms)
        {
            platforms.SetActive(true);
        }
    }

    protected IEnumerator CollapseFloor()
    {
        _floor.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(3.0f);
        _floor.gameObject.SetActive(false);
    }

    #endregion

}
