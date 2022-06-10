using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconHandler : MonoBehaviour
{
    public GameObject beacon;
    [SerializeField] private int maxBeacons = 5;
    [SerializeField] private int beaconLifeSpan = 5;
    private Queue<GameObject> beaconsQueue;

    // Start is called before the first frame update
    void Start()
    {
        beaconsQueue = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (beaconsQueue.Count < maxBeacons)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject newBeacon = Instantiate(beacon, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
                beaconsQueue.Enqueue(newBeacon);
                StartCoroutine(DestroyBeacon());
            }
        }
    }

    IEnumerator DestroyBeacon()
    {
        yield return new WaitForSeconds(beaconLifeSpan);
        Destroy(beaconsQueue.Dequeue());
    }
}
