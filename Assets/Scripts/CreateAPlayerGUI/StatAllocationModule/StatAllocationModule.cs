﻿using UnityEngine;
using System.Collections;

public class StatAllocationModule{



	// Primary stats
	private string[] primaryStatNames = new string[12] 
		{"Strength","Speed","Dexterity","Reflex","Resilience","Knowledge","Elocution","Intellect","Focus","Mockery ","Malevolant","Unmerciful"};
	
	private string[] primaryStatDescriptions = new string[12] 
	{"When your battleaxe penetrates your enemy's brestplate, your strength tends to limit the number of rib bones you shatter in your wake. Remember: the more, the merrier!",
		"If the first slap on a human doesn't get you where you wanted, try a second. Double tap is the way",
		"These evasive schieming little humans dancing around can drive any decent demon mad... Just a tip: aim right between the legs, that actually - never - misses!",
		"'Stick them with the pointy end!' is what they teach their kids... Yes, seriously, they do... Well, I'd be you, I'd try to make that pointy end pointing at something else than your face...",
		"Remember that speech about the pointy end? well, your putrefied lungs or your dead hearts ain't the best second choice either.",
		"Always best to remember the difference between that chicken soup spell and the meteor one, that quite makes the good difference in the battlefield... Well, i guess in the kitchen aswell.",
		"A good demon wizard never misses on his daily elocution exercices. Try after me as fast as you can: 'Imagine an imaginary menagerie manager imagining managing an imaginary menagerie'!",
		"For a fireball to accurately blast someone's head, you've got to guess where that head's going in the next 2 seconds... that sadly requires some brain function.",
		"Demons and belief are somewhat connected, and that can have some perks. Did you know that if you concentrate, you can disbelief something enough to make it actually disapear? that works for fireballs and most similar things! P.S: By the way, that works on you too, so try really hard not to loose faith in yourself...",
		"What would be a good old lost faith without some well placed mockery and cynical attitude? try this next time : if you verbally bully that iceball coming to your head, I'm sure it will shamely run away.",
		"Remember, being part of the older demons requires some parenthood skills. Try to teach some violence in your angelic spawn for a start.",
		"If you want your frail and spoiled little spawns to survive in the human wilderness, you've got to teach them the hard way to survive."};
	
	private string[] primaryStatEffect = new string[12] 
	{"(Physical) Increase critical damage",
	"(Physical) Increase attack speed",
	"(Physical) Increase hit rate",
	"(Physical) Increase deflect rate",
	"(Physical) Increase deflected damage ratio",
	"(Non-Physical) Increase critical damage",
	"(Non-Physical) Increase casting speed",
	"(Non-Physical) Increase hit rate",
	"(Non-Physical) Increase resist rate",
	"(Non-Physical) Increase resisted damage ratio",
	"(Leadership) Increase minions damage",
	"(Leadership) Increase minions resistance"};

	// Heroic stats
	private string[] heroicStatNames = new string[2] 
	{"Rage","Phase"};

	private string[] heroicStatDescriptions = new string[2] 
	{"Come on, child. You're not making it fun enough... Give me a bit of your inner fuel, let the blood bath begin! ",
	"The mastery of your half-plane existence is simply full of perks. Guess what, you can just deny anything bad that happens to you."};

	private string[] heroicStatEffect = new string[2] 
	{"(Heroic) Increase all critical chances",
	"(Heroic) Increase denial of all damage rate"};

	// Secondary stats

	private string[] secondaryStatNames = new string[6] 
	{"Momentum","Balance","Luck","Perception","Judgement","Chaos"};

	private string[] secondaryStatDescriptions = new string[6] 
	{"Lesson on Human Castle attack 101 : First find a rock, then throw very hard the rock on the human stone wall. If it doesn't work, find a bigger rock and repeat.",
	"I know you like chicken. So if you want to roast it, you'll have to run fast, 'cause no one is getting it for you.",
	"You tend to have a very keen eye on finding human craps no one truely cares",
	"Humans have so many pockets and layers of clothes, that's very confusing...",
	"Pointy end? good. Wet stuff with bunnies and dinosaures? Bad.",
	"You've got to teach these humans the second law of thermodynamics. They tend to forget too easily..."};

	private string[] secondaryStatEffect = new string[6] 
	{"(Secondary) Reduce crowd control effects",
	"(Secondary) Increase running speed",
	"(Secondary) Increase human crap amount in loot",
	"(Secondary) Increase average number of items found in loot",
	"(Secondary) Increase average rarity of items found in loot",
	"(Secondary) Increase chances of additional random effects on actions"};


	public int[] primaryPointsToAllocate = new int[12];
	public int[] heroicPointsToAllocate = new int[2];
	public int[] secondaryPointsToAllocate = new int[6];

	private int[] primaryPointsMinimum = new int[12];
	private int[] heroicPointsMinimum = new int[2];
	private int[] secondaryPointsMinimum = new int[6];

	private bool[] primaryStatSelections = new bool[12];
	private bool[] heroicStatSelections = new bool[2];
	private bool[] secondaryStatSelections = new bool[6];


	public int primaryStatPointsToAllocate;
	public int heroicStatPointsToAllocate;
	public int secondaryStatPointsToAllocate;

	public bool didRunOnce=false;


	public void DisplayStatAllocationModule(){
		if (!didRunOnce) {
			RetrieveStatBaseStatPoints ();
			didRunOnce=true;
		}
		DisplayStatToggleSwitches();
		DisplayStatIncreaseDecreaseButtons ();
	}

	private void DisplayStatToggleSwitches(){

		// Display primary stats
		for (int i=0; i<primaryStatNames.Length; i++) {

			primaryStatSelections[i]=GUI.Toggle (new Rect(100,30*i+70,80,30),primaryStatSelections[i],primaryStatNames[i]);

			GUI.Label (new Rect(190,30*i+70,30,30), primaryPointsToAllocate[i].ToString ());

			if(primaryStatSelections[i]) {
				GUI.Label (new Rect(340,30*i+70,Screen.width-440,40), primaryStatDescriptions[i]);
				GUI.Label (new Rect(340,30*i+85,Screen.width-440,40), primaryStatEffect[i]);
			}
		}

		// Display heroic stats
		for (int i=0; i<heroicStatNames.Length; i++) {
			int j=i+primaryStatNames.Length;
			heroicStatSelections[i]=GUI.Toggle (new Rect(100,30*j+70,80,30),heroicStatSelections[i],heroicStatNames[i]);
			GUI.Label (new Rect(190,30*j+70,30,30), heroicPointsToAllocate[i].ToString ());
			
			if(heroicStatSelections[i]) {
				GUI.Label (new Rect(340,30*j+70,Screen.width-440,40), heroicStatDescriptions[i]);
				GUI.Label (new Rect(340,30*j+85,Screen.width-440,40), heroicStatEffect[i]);

			}
		}

		// Display Secondary stats
		for (int i=0; i<secondaryStatNames.Length; i++) {
			int j=i+primaryStatNames.Length+heroicStatNames.Length;
			secondaryStatSelections[i]=GUI.Toggle (new Rect(100,30*j+70,80,30),secondaryStatSelections[i],secondaryStatNames[i]);
			GUI.Label (new Rect(190,30*j+70,30,30), secondaryPointsToAllocate[i].ToString ());
			
			if(secondaryStatSelections[i]) {
				GUI.Label (new Rect(340,30*j+70,Screen.width-440,40), secondaryStatDescriptions[i]);
				GUI.Label (new Rect(340,30*j+85,Screen.width-440,40), secondaryStatEffect[i]);
			}
		}

	}

	private void DisplayStatIncreaseDecreaseButtons(){


		// display + and - for primary stats
		for (int i=0; i<primaryStatNames.Length; i++) {
			if (primaryStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * i + 65, 30, 30), "+")) {
					++primaryPointsToAllocate[i];
					--primaryStatPointsToAllocate;
				}
			}
			if (primaryPointsToAllocate[i]-primaryPointsMinimum[i]>0) {
				if (GUI.Button (new Rect (230, 30 * i + 65, 30, 30), "-")) {
					--primaryPointsToAllocate[i];
					++primaryStatPointsToAllocate;
			}
			}
		}

		// display + and - for heroic stats

		for (int i=0; i<heroicStatNames.Length; i++) {
			int j=i+primaryStatNames.Length;
			if (heroicStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * j + 65, 30, 30), "+")) {
					++heroicPointsToAllocate[i];
					--heroicStatPointsToAllocate;
				}
			}
			if (heroicPointsToAllocate[i]-heroicPointsMinimum[i]>-1) {
				if (GUI.Button (new Rect (230, 30 * j + 65, 30, 30), "-")) {
					--heroicPointsToAllocate[i];
					++heroicStatPointsToAllocate;
				}
			}
		}

		// display + and - for secondary stats

		for (int i=0; i<secondaryStatNames.Length; i++) {
			int j=i+primaryStatNames.Length+heroicStatNames.Length;
			if (secondaryStatPointsToAllocate>0) {
				if (GUI.Button (new Rect (270, 30 * j + 65, 30, 30), "+")) {
					++secondaryPointsToAllocate[i];
					--secondaryStatPointsToAllocate;
				}
			}
			if (secondaryPointsToAllocate[i]-secondaryPointsMinimum[i]>0) {
				if (GUI.Button (new Rect (230, 30 * j + 65, 30, 30), "-")) {
					--secondaryPointsToAllocate[i];
					++secondaryStatPointsToAllocate;
				}
			}
		}



	}










	private void RetrieveStatBaseStatPoints(){


		primaryStatPointsToAllocate = GameInformation.PrimaryStatPointsToAllocate;
		heroicStatPointsToAllocate = GameInformation.HeroicStatPointsToAllocate;
		secondaryStatPointsToAllocate = GameInformation.SecondaryStatPointsToAllocate;


		// Initiation des stats allouées
		primaryPointsToAllocate[0] = GameInformation.Strength;
		primaryPointsMinimum[0] = GameInformation.Strength;
		primaryPointsToAllocate[1] = GameInformation.Speed;
		primaryPointsMinimum[1] = GameInformation.Speed;
		primaryPointsToAllocate[2] = GameInformation.Dexterity;
		primaryPointsMinimum[2] = GameInformation.Dexterity;
		primaryPointsToAllocate[3] = GameInformation.Reflex;
		primaryPointsMinimum[3] = GameInformation.Reflex;
		primaryPointsToAllocate[4] = GameInformation.Resilience;
		primaryPointsMinimum[4] = GameInformation.Resilience;
		primaryPointsToAllocate[5] = GameInformation.Knowledge;
		primaryPointsMinimum[5] = GameInformation.Knowledge;
		primaryPointsToAllocate[6] = GameInformation.Elocution;
		primaryPointsMinimum[6] = GameInformation.Elocution;
		primaryPointsToAllocate[7] = GameInformation.Intellect;
		primaryPointsMinimum[7] = GameInformation.Intellect;
		primaryPointsToAllocate[8] = GameInformation.Focus;
		primaryPointsMinimum[8] = GameInformation.Focus;
		primaryPointsToAllocate[9] = GameInformation.Mockery;
		primaryPointsMinimum[9] = GameInformation.Mockery;
		primaryPointsToAllocate[10] = GameInformation.Malevolant;
		primaryPointsMinimum[10] = GameInformation.Malevolant;
		primaryPointsToAllocate[11] = GameInformation.Unmerciful;
		primaryPointsMinimum[11] = GameInformation.Unmerciful;

		heroicPointsToAllocate[0] = GameInformation.Rage;
		heroicPointsMinimum[0] = GameInformation.Rage;
		heroicPointsToAllocate[1] = GameInformation.Phase;
		heroicPointsMinimum[1] = GameInformation.Phase;

		secondaryPointsToAllocate[0] = GameInformation.Momentum;
		secondaryPointsMinimum[0] = GameInformation.Momentum;
		secondaryPointsToAllocate[1] = GameInformation.Balance;
		secondaryPointsMinimum[1] = GameInformation.Balance;
		secondaryPointsToAllocate[2] = GameInformation.Luck;
		secondaryPointsMinimum[2] = GameInformation.Luck;
		secondaryPointsToAllocate[3] = GameInformation.Perception;
		secondaryPointsMinimum[3] = GameInformation.Perception;
		secondaryPointsToAllocate[4] = GameInformation.Judgement;
		secondaryPointsMinimum[4] = GameInformation.Judgement;
		secondaryPointsToAllocate[5] = GameInformation.Chaos;
		secondaryPointsMinimum[5] = GameInformation.Chaos;

		}




	}

