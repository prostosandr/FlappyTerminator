using UnityEngine;

public interface IPool<TItem> where TItem : MonoBehaviour
{
    public int NumbersOfObjects { get;  }
    public int Capacity { get; }

    public TItem GetObject();
}
