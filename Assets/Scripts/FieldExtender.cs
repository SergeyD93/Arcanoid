using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FieldExtender : MonoBehaviour {

	public List<GameObject> listOfBlocks;
	public List<Sprite> listOfBackgrounds;
	private List<Vector2> listOfPositions;


	void Start () 
	{
		extendGameField();
	}

	public void extendGameField()
	{

		GameObject.Find("Ball").GetComponent<Ball>().setBallOnStartPosition();
		System.Random rnd = new System.Random();

		GameObject bacground = GameObject.Find("Background");
		Sprite bacgroundSprite = new Sprite();

		do
		{
			bacgroundSprite = getRandomBackground();
			if(!bacgroundSprite)
			{
				Debug.LogError("[FieldExtender] listOfBackgrounds hasn't any sprites");
				return;
			}
		}
		while (bacgroundSprite == bacground.GetComponent<SpriteRenderer>().sprite );
		bacground.GetComponent<SpriteRenderer>().sprite = bacgroundSprite;

		listOfPositions = new List<Vector2>();
		
		float blockAreaWidth = bacground.GetComponent<SpriteRenderer>().bounds.size.x;
		float blockAreaHeight = bacground.GetComponent<SpriteRenderer>().bounds.size.y/2;
		
		float blockWidth = listOfBlocks[0].GetComponent<SpriteRenderer>().bounds.size.x;
		float blockHeight = listOfBlocks[0].GetComponent<SpriteRenderer>().bounds.size.y;
		
		int numOfBlocksOnHorizontLine = Convert.ToInt32(blockAreaWidth/blockWidth)-1;
		int numOfBlocksOnVerticalLine = Convert.ToInt32(blockAreaHeight/blockHeight)-1;
		
		float totalHorizontalSpaceBetweenBlocks = blockAreaWidth % blockWidth;
		float singleHorizontalSpaceBetweenBlocks = totalHorizontalSpaceBetweenBlocks/numOfBlocksOnHorizontLine;
		
		float totalVerticalSpaceBetweenBlocks = (blockAreaHeight % blockHeight)+ blockHeight;
		float singleVerticalSpaceBetweenBlocks = totalVerticalSpaceBetweenBlocks/numOfBlocksOnVerticalLine;

		for (int i = 0; i < numOfBlocksOnHorizontLine; i++)
		{
			for (int j = 0; j < numOfBlocksOnVerticalLine; j++)
			{
				if(rnd.Next(3) > 0)// 3 for more num of bloks
				{
					Vector2 vector = new Vector2();
					vector.x = (singleHorizontalSpaceBetweenBlocks/2 + blockWidth/2 + blockWidth*i + singleHorizontalSpaceBetweenBlocks*i) - blockAreaWidth/2;
					vector.y = singleVerticalSpaceBetweenBlocks/2 + blockHeight/2 + blockHeight*j + singleVerticalSpaceBetweenBlocks*j;
					listOfPositions.Add(vector);
				}
			}
		}

		foreach(Vector2 vector in listOfPositions)
		{
			Instantiate(listOfBlocks[rnd.Next(listOfBlocks.Count)], vector, transform.rotation); 
		}
		PlayerProgressManager.Instance.getNumberOfBlocks();
	}

	Sprite getRandomBackground()
	{
		if(listOfBackgrounds.Count != 0)
		{
		System.Random rnd = new System.Random();
			return listOfBackgrounds[rnd.Next(listOfBackgrounds.Count)];
		}
		return null;
	}
}
