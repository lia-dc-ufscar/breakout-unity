using UnityEngine;
using System.Collections;

public class BrickFactory : MonoBehaviour {
	
	public Brick brickPrefab;
	
	// Use this for initialization
	void Start () {
	
		Color[] rowColors = Config.COLORS_ARRAY;
		int rows = rowColors.Length;
		
		int cols = Config.COLS;
		
		float spacing = Config.BRICKS_SPACING;
		
		float left = renderer.bounds.min.x;
		float top = renderer.bounds.max.y;
		
		float width = renderer.bounds.size.x;
		float height = renderer.bounds.size.y;
		
		float brickWidth = (width - ((cols - 1) * spacing)) / cols;
		float brickHeight = (height - ((rows - 1) * spacing)) / rows;
		
		Debug.Log("brickWidth: " + brickWidth);
		
		float brickScaleX = brickPrefab.transform.localScale.x * (brickWidth / brickPrefab.renderer.bounds.size.x);
		float brickScaleY = brickPrefab.transform.localScale.y * (brickHeight / brickPrefab.renderer.bounds.size.y);
		Vector3 brickScale = new Vector3(brickScaleX, brickScaleY, 1.0f);
		
		for (int row  = 0; row < rows; ++row) {
			Color color = rowColors[row];
			for (int col  = 0; col < cols; ++col) {
				Brick brick = Instantiate(brickPrefab) as Brick;
				brick.SetColor(color);
				brick.transform.localScale = brickScale;
				float x = left + (col * spacing) + (col * brickWidth) + (brickWidth / 2.0f);
				float y = top - (row * spacing) - (row * brickHeight) - (brickHeight / 2.0f);
				brick.transform.position = new Vector3(x, y, 0.0f);
			}
		}
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
