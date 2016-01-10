using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {

    public GameObject mapNode;
    public GameObject mapPath;

    public GameObject[] tempNodes;

    public int mapLength;

	public float scatter;

	void Start () {

        tempNodes = new GameObject[mapLength];

        for(int i = 0; i <= tempNodes.Length - 1; i++)
        {
            float tempFloat = 12.5f / mapLength;

            tempNodes[i] = Instantiate(mapNode, new Vector3(tempFloat + (i * tempFloat) - (6.25f + tempFloat), Random.Range(-scatter + 2, scatter), 0), Quaternion.identity) as GameObject;
			tempNodes[i].GetComponent<MapNode>().id = i + "a";

			// Sets Mommy to red.

			if(i == tempNodes.Length - 1)
			{
				tempNodes[i].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0);
			}

			// Chance to generate a second node on the column.

			if(Random.Range (0,10) <= 2){
				tempNodes[i] = Instantiate(mapNode, new Vector3(tempFloat + (i * tempFloat) - (6.25f + tempFloat), Random.Range(-scatter + 2, scatter), 0), Quaternion.identity) as GameObject;
				tempNodes[i].GetComponent<MapNode>().id = i + "b";

				// Chance to generate a third node on the column.

				if(Random.Range (0,10) <= 2){
					tempNodes[i] = Instantiate(mapNode, new Vector3(tempFloat + (i * tempFloat) - (6.25f + tempFloat), Random.Range(-scatter + 2, scatter), 0), Quaternion.identity) as GameObject;
					tempNodes[i].GetComponent<MapNode>().id = i + "c";
				}
			}

        }

		// Draw pips between nodes.

		/*

        for (int i = 0; i <= tempNodes.Length - 1; i++)
        {
            if (i > 0)
            {
                tempNodes[i].GetComponent<MapNode>().Connections.Add(tempNodes[i - 1]);
            }
            if (i < tempNodes.Length - 1)
            {
                tempNodes[i].GetComponent<MapNode>().Connections.Add(tempNodes[i + 1]);

                int distBetweenPips = (int)Mathf.Ceil(Vector3.Distance(tempNodes[i].transform.position, tempNodes[i + 1].transform.position));
                int numOfPips = 1;


				for (int j = 0; j < distBetweenPips; j = j + (distBetweenPips/numOfPips))
                {
                    Instantiate(mapPath, (tempNodes[i].transform.position + tempNodes[i + 1].transform.position) / 2, Quaternion.identity);
                }
            }
        }

        */

        /*
        for (int i = 0; i <= mapLength; i++)
        {
            GameObject tempNode = Instantiate(mapNode, transform.position, Quaternion.identity) as GameObject;
            Vector3 currentPos = transform.position;
            GameObject tempLeftNode = Instantiate(mapNode, Move1StepLeft(currentPos), Quaternion.identity) as GameObject;
            GameObject tempRightNode = Instantiate(mapNode, Move1StepRight(currentPos), Quaternion.identity) as GameObject;

            tempNode.GetComponent<MapNode>().left = tempLeftNode;
            tempNode.GetComponent<MapNode>().right = tempRightNode;

            transform.Translate(new Vector3(i, 0, 0));

        }
        */
    }

    public Vector3 Move1StepLeft(Vector3 _currentPos) {
        _currentPos += new Vector3(3.6f, .6f, 0);
        return _currentPos;
    }

    public Vector3 Move1StepRight(Vector3 _currentPos)
    {
		_currentPos += new Vector3(3.6f, -.6f, 0);
        return _currentPos;
    }
}