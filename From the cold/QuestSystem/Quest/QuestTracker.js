var myskin : GUIStyle;

var QuestTr1 : boolean = true;
var QuestTr2 : boolean = true;
var QuestTr3 : boolean = true;
var QuestTr4 : boolean = true;
var QuestTr5 : boolean = true;

var QuestTr1Str : String = "";
var QuestTr2Str : String = "";
var QuestTr3Str : String = "";
var QuestTr4Str : String = "";
var QuestTr5Str : String = "";

function OnGUI () {
GUI.skin.label = myskin;

GUI.Label(Rect( 1550, 250, 1000, 1000), QuestTr1Str.ToString());
GUI.Label(Rect( 1550, 300, 1000, 1000), QuestTr2Str.ToString());
GUI.Label(Rect( 1550, 350, 1000, 1000), QuestTr3Str.ToString());
GUI.Label(Rect( 1550, 400, 1000, 1000), QuestTr4Str.ToString());
GUI.Label(Rect( 1550, 450, 1000, 1000), QuestTr5Str.ToString());

}
function Update() {
	if(QuestTr1 == true) {
		QuestTr1Str = "";
	}
	if(QuestTr2 == true) {
		QuestTr2Str = "";
	}
	if(QuestTr3 == true) {
		QuestTr3Str = "";
	}
	if(QuestTr4 == true) {
		QuestTr4Str = "";
	}
	if(QuestTr5 == true) {
		QuestTr5Str = "";
	}
	
}


