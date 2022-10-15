using UnityEngine;

public class CubeKiller : MonoBehaviour,IEventListener<Cube>
{
    [SerializeField] CubeEvent _cubeDying;

    private void OnEnable()
    {
        _cubeDying.RegisterListener(this);
    }

    private void OnDisable()
    {
        _cubeDying.UnregisterListener(this);
    }

    public void OnEventRaised(Cube data)
    {
        data.LastWords();
        Destroy(data.gameObject);
    }
}