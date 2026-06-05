using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] public ObjectPool<GameObject> pool;
    public int size;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(
            createFunc: CreateObject,
            actionOnGet: TrueGameObject,
            actionOnRelease: FalseGameObject,
            actionOnDestroy: Destroy,
            collectionCheck: false,
            maxSize: size
            );
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; 
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(bullet);
        return obj;
    }

    void TrueGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    void FalseGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }

}
