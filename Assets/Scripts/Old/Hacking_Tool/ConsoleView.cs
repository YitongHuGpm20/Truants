/// <summary>
/// Marshals events and data between ConsoleController and uGUI.
/// Copyright (c) 2014-2015 Eliot Lash
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class ConsoleView : MonoBehaviour {
	ConsoleController console = new ConsoleController();
	
	bool didShow = false;
    public GameObject firstPC;
    public GameObject secondPC;
	public GameObject viewContainer; //Container for console view, should be a child of this GameObject
	public Text logTextArea;
	public InputField inputField;
    public static GameObject console_obj;

    private void Awake()
    {
        console_obj = this.gameObject;
    }


    public void KeepActive()
    {
        inputField.GetComponent<InputField>().ActivateInputField();
    }

    
    void Start() {
		if (console != null) {
			console.visibilityChanged += onVisibilityChanged;
			console.logChanged += onLogChanged;
		}
		updateLogStr(console.log);

        KeepActive();
    }
	
	~ConsoleView() {
		console.visibilityChanged -= onVisibilityChanged;
		console.logChanged -= onLogChanged;
	}
	
	void Update() {
        //Toggle visibility when tilde key pressed
        //if (Input.GetKeyUp("`")) {
        //	toggleVisibility();
        //}
        KeepActive();
        
        
        //Toggle visibility when 5 fingers touch.
        if (Input.touches.Length == 5) {
			if (!didShow) {
				toggleVisibility();
				didShow = true;
			}
		} else {
			didShow = false;
		}

        if (console.secondPC)
        {
            firstPC.SetActive(false);
            secondPC.SetActive(true);
            console.secondPC = false;
           // GameManager.hack = true;
        }

        if (!inputField.isFocused && inputField.text != "" && Input.GetKeyDown(KeyCode.Return))
            runCommand();
    }

	void toggleVisibility() {
		setVisibility(!viewContainer.activeSelf);
	}
	
	void setVisibility(bool visible) {
		viewContainer.SetActive(visible);
	}
	
	void onVisibilityChanged(bool visible) {
		setVisibility(visible);
	}
	
	void onLogChanged(string[] newLog) {
		updateLogStr(newLog);
	}
	
	void updateLogStr(string[] newLog) {
		if (newLog == null) {
			logTextArea.text = "Welcome to xPloit! (v. 1.0)\n Made by Knightmare\n Type help to list system commands";
		} else {
			logTextArea.text = string.Join("\n", newLog);
		}
	}

	/// <summary>
	/// Event that should be called by anything wanting to submit the current input to the console.
	/// </summary>
	public void runCommand() {
		console.runCommandString(inputField.text);
		inputField.text = "";
	}

}
