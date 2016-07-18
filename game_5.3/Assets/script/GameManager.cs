using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public void city_button2(){
		Application.LoadLevel("city_army");
	}

	public void city_button1() {
		Application.LoadLevel("city_house");
	}

	public void city_return() {
		Application.LoadLevel("game");
	}

	public void city_house_return()
	{
		Application.LoadLevel("city");
	}

	public void city_army_return()
	{
		Application.LoadLevel("city");
	}
}
