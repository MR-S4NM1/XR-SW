using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    #region References

    public static GameManager instance;

    [SerializeField] protected Canvas _rotationCanvas;
    [SerializeField] protected Canvas _victoryCanvas;

    [SerializeField] protected ActionBasedContinuousTurnProvider _continousTurnProvider;
    [SerializeField] protected ActionBasedSnapTurnProvider _snapTurnProvider;

    [SerializeField] protected GameObject _initialBlockGroup;

    [SerializeField] protected TurretCode[] _turrets;

    [SerializeField] protected GameObject[] _lightsabers;
    [SerializeField] protected GameObject[] _platforms;
    [SerializeField] protected GameObject _floor;
    [SerializeField] protected GameObject _finalTrigger;

    [SerializeField] protected GameObject _alarmGO;

    [SerializeField] protected MeshRenderer _buttonMeshRenderer;
    [SerializeField] protected Material _buttonOffMaterial;
    [SerializeField] protected Material _buttonOnMaterial;

    [SerializeField] protected Transform _playersTransform;
    [SerializeField] protected Transform _platformsTransform;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _buttonMeshRenderer.material = _buttonOffMaterial;
    }


    #endregion

    #region PublicMethods

    public void ActivateLevelEvents()
    {
        StartCoroutine(ActivateObjectsAndCollapseFloor());
    }

    public void ShowVictoryCanvas()
    {
        //SceneChanger.instance.ChangeSceneTo(1);
        _victoryCanvas.gameObject.SetActive(true);
    }

    public void ReturnPlayerToPlatform()
    {
        _playersTransform.position = _platformsTransform.position;
    }

    public void ActivateSnapRotation()
    {
        _snapTurnProvider.enabled = true;
        _continousTurnProvider.enabled = false;
        _rotationCanvas.gameObject.SetActive(false);
        _initialBlockGroup.gameObject.SetActive(false);
    }

    public void ActivateContinousRotation()
    {
        _snapTurnProvider.enabled = false;
        _continousTurnProvider.enabled = true;
        _rotationCanvas.gameObject.SetActive(false);
        _initialBlockGroup.gameObject.SetActive(false);
    }

    #endregion

    #region LocalMethods

    protected IEnumerator ActivateObjectsAndCollapseFloor()
    {
        _buttonMeshRenderer.material = _buttonOnMaterial;

        _finalTrigger.gameObject.SetActive(true);

        _alarmGO.gameObject.SetActive(true);

        foreach (TurretCode turret in _turrets)
        {
            turret.ShootingRoutine();
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
