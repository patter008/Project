var CurrentLevel : float = 1f;
var CurrentExp : float = 0f;
var MaxLevel : float;
var MaxExp : float;


var ToggleExp : boolean = true;

function Start () {

}

function Update () {
   LevelExp();
   
   if(Input.GetKeyDown("y")){
   		ToggleExp = !ToggleExp;
   }
}

function OnGUI () {
if(!ToggleExp){
GUI.Box(Rect( 1, 1, Screen.width/3, 20), CurrentExp.ToString());

}

GUI.Label(Rect( 50, 100, 1000, 1000), "Level :");
GUI.Label(Rect( 100, 100, 1000, 1000), CurrentLevel.ToString());
}

function LevelExp(){
   if(CurrentExp > 100){
      CurrentLevel = 2f;
   }
   
   if(CurrentExp > 300){
      CurrentLevel = 3f;
   }
   
   if(CurrentExp > 900){
      CurrentLevel = 4f;
   }
   
   if(CurrentExp > 2700){
      CurrentLevel = 5f;
   }
   
   if(CurrentExp > 8100){
      CurrentLevel = 6f;
   }
}

