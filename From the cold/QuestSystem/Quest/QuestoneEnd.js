#pragma strict
var questgiver : GameObject;
var FinishScreen : boolean = true;
var Player : GameObject;
var Expgained : float = 0f;

var EnterArea : boolean = true;

var Myskin : GUISkin;

var NPCClickText : boolean = true;

var NPCName : String = "";

function Start () {
   
}

function Update () {

	var eh = questgiver.GetComponent(QuestoneStart);
   
   Player = GameObject.FindGameObjectWithTag("Player");
   
   if(EnterArea == true){
   		FinishScreen = true;
   		NPCClickText = true;
   
   }
   
   if( eh.QuestFinished == true){
   		NPCClickText = true;
   		
   }
   
   if(!EnterArea){
   		if(eh.QuestPending == true){
   			if(FinishScreen == true){
   				if(Input.GetKeyDown("e")){
   					FinishScreen = !FinishScreen;
   				}
   			}
   		}
   }
   
   
   
}
   
function OnMouseUp() {
   var eh = questgiver.GetComponent(QuestoneStart);
   
   if(eh.QuestPending == true) {
      FinishScreen = !FinishScreen;
   }
   
   
   
}

function OnGUI () {

	GUI.skin = Myskin;
   var eh = questgiver.GetComponent(QuestoneStart);
   var exp = Player.GetComponent(LevelAndExperience);
   
   if(!FinishScreen) {
      GUI.Box(Rect( 200, 30, 400, 500), "Finding My Brother");
      if(GUI.Button(Rect( 240, 445, 100, 30), "Finish")){
         eh.QuestFinished = true;
         FinishScreen = true;
         exp.CurrentExp += Expgained;
         
         
         
      
      }
      
      if(Input.GetKeyDown(KeyCode.Return)){
      		eh.QuestFinished = true;
         FinishScreen = true;
         exp.CurrentExp += Expgained;
      }
      
      if(Input.GetKeyDown(KeyCode.Tab)){
      		FinishScreen = true;
      }
      
      GUI.TextArea(Rect( 250, 130, 280, 200), "Thank The gods you came to me! I thought i was going to die in this forest! Can you point me the way where to go on my map? Thank you!");
      GUI.TextArea(Rect( 250, 335, 280, 100), "Rewards: 100 Xp, 90 Copper coins");
   
      if(GUI.Button(Rect( 340, 445, 100, 30), "GoodBye")){
         FinishScreen = true;
      }
      
      
   }
		
		if(!EnterArea){
   			if(FinishScreen == true){
   				NPCClickText = false;
   				
   		}
   		
   		if(FinishScreen == false){
   			NPCClickText = true;
   		}
   		
   		if(EnterArea == true){
   			NPCClickText = true;
   		}
   		
   		if(NPCClickText == false){
   		GUI.Label(Rect( 900, 500, 200, 50), "Press E" + "     " + NPCName);
   }
   }
   
   
}

function OnTriggerEnter(other: Collider){
   		EnterArea = !EnterArea;
   }
   
   function OnTriggerExit(other: Collider){
   		EnterArea = true;
   }


