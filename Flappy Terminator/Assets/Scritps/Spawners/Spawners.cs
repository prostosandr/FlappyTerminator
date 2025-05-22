using UnityEngine;

public abstract class Spawners<TItem> : MonoBehaviour where TItem : MonoBehaviour, IItem<TItem>
{
    [SerializeField] private TItem _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxSize;

    private Pool<TItem> _pool;

    private void Awake()
    {
        _pool = new Pool<TItem>();
        _pool.Initialize(_prefab, _capacity, _maxSize);
    }

    public void SetCapacity(int value)
    {
        _capacity = value;
    }

    public void SetMaxSize(int value)
    {
        _maxSize = value;
    }

    public TItem GetObject()
    {
        return _pool.GetObject();
    }

    protected void Spawn()
    {
        if (_pool.NumbersOfObjects < _pool.Capacity)
            CreateItem();
    }

    protected virtual void CreateItem() { }
}
