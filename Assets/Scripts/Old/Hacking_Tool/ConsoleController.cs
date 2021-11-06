using UnityEngine;

using System;
using System.Collections.Generic;
using System.Text;

public delegate void CommandHandler(string[] args);

public class ConsoleController
{

    #region Event declarations
    // Used to communicate with ConsoleView
    public delegate void LogChangedHandler(string[] log);
    public event LogChangedHandler logChanged;

    public delegate void VisibilityChangedHandler(bool visible);
    public event VisibilityChangedHandler visibilityChanged;
    #endregion
    public bool secondPC;
    public bool loggedIn;
    
    // public bool addCommand;
    /// <summary>
    /// Object to hold information about each command
    /// </summary>
    class CommandRegistration
    {
        public string command { get; private set; }
        public CommandHandler handler { get; private set; }
        public string help { get; private set; }

        public CommandRegistration(string command, CommandHandler handler, string help)
        {
            this.command = command;
            this.handler = handler;
            this.help = help;
        }
    }

    /// <summary>
    /// How many log lines should be retained?
    /// Note that strings submitted to appendLogLine with embedded newlines will be counted as a single line.
    /// </summary>
    const int scrollbackSize = 1000;

    Queue<string> scrollback = new Queue<string>(scrollbackSize);
    List<string> commandHistory = new List<string>();
    Dictionary<string, CommandRegistration> commands = new Dictionary<string, CommandRegistration>();

    public string[] log { get; private set; } //Copy of scrollback as an array for easier use by ConsoleView

    const string repeatCmdName = "!!"; //Name of the repeat command, constant since it needs to skip these if they are in the command history

    public ConsoleController()
    {
        //When adding commands, you must add a call below to registerCommand() with its name, implementation method, and help text.
       // registerCommand("babble", babble, "Example command that demonstrates how to parse arguments. babble [word] [# of times to repeat]");
        //registerCommand("echo", echo, "echoes arguments back as array (for testing argument parser)");
        registerCommand("help", help, "Print this help.");
        //registerCommand("helppc", helppc, "vlad pc");
        //registerCommand("hide", hide, "Hide the console.");
        //registerCommand(repeatCmdName, repeatCommand, "Repeat last command.");
        //registerCommand("reload", reload, "Reload game.");
        //registerCommand("resetprefs", resetPrefs, "Reset & saves PlayerPrefs.");
        registerCommand("xploit", xploit, "Ping user");
        registerCommand("cipher", cipher, "Decrypts hashed passwords, if the file contains any");
        registerCommand("list", list, "works after user pings a particular computer");
        registerCommand("view", view, "works after user pings a particular computer");
        registerCommand("download", download, "download zip files");
        //registerCommand("open", open, "open Dynamic Map");
        registerCommand("wftrack", wftrack, "shows the connected devices to local wifi");
    }

    void registerCommand(string command, CommandHandler handler, string help)
    {
        commands.Add(command, new CommandRegistration(command, handler, help));
    }

    public void appendLogLine(string line)
    {
        Debug.Log(line);

        //if (scrollback.Count >= ConsoleController.scrollbackSize) {
        //	scrollback.Dequeue();
        //}
        scrollback.Enqueue(line);

        log = scrollback.ToArray();
        if (logChanged != null)
        {
            logChanged(log);
        }
    }

    public void runCommandString(string commandString)
    {


        string[] commandSplit = parseArguments(commandString);
        string[] args = new string[0];
        if (commandSplit.Length < 1)
        {
            //appendLogLine(string.Format("Unable to process command '{0}'", commandString));
            //return;

        }
        else if (commandSplit.Length >= 2)
        {
            appendLogLine("$ " + commandString);
            int numArgs = commandSplit.Length - 1;
            args = new string[numArgs];
            Array.Copy(commandSplit, 1, args, 0, numArgs);
        }
        runCommand(commandSplit[0].ToLower(), args);
        commandHistory.Add(commandString);
    }

    public void runCommand(string command, string[] args)
    {
        CommandRegistration reg = null;
        if (!commands.TryGetValue(command, out reg))
        {
                appendLogLine(string.Format("Unknown command '{0}', type 'help' for list.", command));
        }
        else
        {
            if (reg.handler == null)
            {
                appendLogLine(string.Format("Unable to process command '{0}', handler was null.", command));
            }
            else
            {
                reg.handler(args);
            }
        }
    }

    static string[] parseArguments(string commandString)
    {
        LinkedList<char> parmChars = new LinkedList<char>(commandString.ToCharArray());
        bool inQuote = false;
        var node = parmChars.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value == '"')
            {
                inQuote = !inQuote;
                parmChars.Remove(node);
            }
            if (!inQuote && node.Value == ' ')
            {
                node.Value = '\n';
            }
            node = next;
        }
        char[] parmCharsArr = new char[parmChars.Count];
        parmChars.CopyTo(parmCharsArr, 0);
        return (new string(parmCharsArr)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    #region Command handlers
    //Implement new commands in this region of the file.

    /// <summary>
    /// A test command to demonstrate argument checking/parsing.
    /// Will repeat the given word a specified number of times.
    /// </summary>
    //void babble(string[] args)
    //{
    //    if (args.Length < 2)
    //    {
    //        appendLogLine("Expected 2 arguments.");
    //        return;
    //    }
    //    string text = args[0];
    //    if (string.IsNullOrEmpty(text))
    //    {
    //        appendLogLine("Expected arg1 to be text.");
    //    }
    //    else
    //    {
    //        int repeat = 0;
    //        if (!Int32.TryParse(args[1], out repeat))
    //        {
    //            appendLogLine("Expected an integer for arg2.");
    //        }
    //        else
    //        {
    //            for (int i = 0; i < repeat; ++i)
    //            {
    //                appendLogLine(string.Format("{0} {1}", text, i));
    //            }
    //        }
    //    }
    //}

    //void echo(string[] args)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach (string arg in args)
    //    {
    //        sb.AppendFormat("{0},", arg);
    //    }
    //    sb.Remove(sb.Length - 1, 1);
    //    appendLogLine(sb.ToString());
    //}

    void help(string[] args)
    {
        //foreach(CommandRegistration reg in commands.Values) {
        //	appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
        //}
        //appendLogLine("\n");
        if (loggedIn)
        {
            appendLogLine("$help");
            appendLogLine("\n");
            appendLogLine("         <b>help</b> - Show commands for host PC");
            appendLogLine("         <b>list</b> - View host PC registry");
            appendLogLine("         <b>view <i><color=green>folder/file-name</color></i></b> - Displays file contents");
            appendLogLine("         <b>cipher <i><color=green>folder/file-name</color></i></b> - Decrypts hashed passwords, if the file contains any");
            appendLogLine("         <b>download <i><color=green>folder/file-name</color> <color=orange>password</color></i></b> - download only zip files");
            //appendLogLine("         <b>open <i>folder/file name code</i></b> - open map file");
            //appendLogLine("         <b>wftrack <i>code</i></b> - show connected devices in the floor map");
        }
       
        else
        {
            appendLogLine("$help");
            appendLogLine("\n");
            appendLogLine("         <b>help</b> - Displays commands");
            appendLogLine("         <b>xploit <i>IP Address</i></b> - Locates vulnerabilities and connects player to host computer");
        }

    }

    

    //void hide(string[] args) {
    //	if (visibilityChanged != null) {
    //		visibilityChanged(false);
    //	}
    //}

    //void repeatCommand(string[] args) {
    //	for (int cmdIdx = commandHistory.Count - 1; cmdIdx >= 0; --cmdIdx) {
    //		string cmd = commandHistory[cmdIdx];
    //		if (String.Equals(repeatCmdName, cmd)) {
    //			continue;
    //		}
    //		runCommandString(cmd);
    //		break;
    //	}
    //}

    //void reload(string[] args) {
    //	Application.LoadLevel(Application.loadedLevel);
    //}

    //void resetPrefs(string[] args) {
    //	PlayerPrefs.DeleteAll();
    //	PlayerPrefs.Save();
    //}

    void xploit(string[] args)
    {
        string IPAddress = args[0];
        if (IPAddress == "192.168.207.1")
        {
            loggedIn = true;
            appendLogLine("\n");
            appendLogLine("         Locating vulnerabilities...");
            appendLogLine("\n");
            appendLogLine("         Connecting to 192.168.207.1...");
            appendLogLine("\n");
            appendLogLine("         CONNECTED TO VladK_PC");
            appendLogLine("\n");
            appendLogLine("         <b>help</b> - Show commands for host PC");
            appendLogLine("         <b>list</b> - View host PC registry");
            appendLogLine("         <b>view <i><color=green>folder/file-name</color></i></b> - Displays file contents");
            appendLogLine("         <b>cipher <i><color=green>folder/file-name</color></i></b> - Decrypts hashed passwords, if the file contains any");
            appendLogLine("         <b>download <i><color=green>folder/file-name</color> <color=orange>password</color></i></b> - download only zip files");
            // appendLogLine("         <b>open <i>folder/file name</i></b> - open map file");
            // appendLogLine("         <b>wftrack <code></b> - show connected devices in the floor map");
        }
        else
        {
            appendLogLine("\n");
            appendLogLine("         Locating vulnerabilities...");
            appendLogLine("\n");
            appendLogLine("         <color=red>Invalid IP, cannot connect.</color>");
        }
    }

    void cipher(string[] args)
    {
        string passwordFile = args[0];
        if (passwordFile == "/documents/password.reg")
        {
            appendLogLine("\n");
            appendLogLine("         finding hashed password...");
            appendLogLine("\n");
            appendLogLine("         generating possible algorithms...");
            appendLogLine("         <color=green>L+1 T+2 B+3 M+4 C+5 3+4 8+7</color>");
        }
        else
        {
            appendLogLine("\n");
            appendLogLine("         finding hashed password...");
            appendLogLine("\n");
            appendLogLine("         <color=red>file doesn't contain hashed password.</color>");
        }
    }


    void list(string[] args)
    {
        appendLogLine("$list");
        appendLogLine("\n");
        appendLogLine("         Accessing files...");
        appendLogLine("\n");
        appendLogLine("         Access granted!");
        appendLogLine("\n");
        appendLogLine("         /system");
        appendLogLine("         /downloads");
        appendLogLine("         /documents");
        appendLogLine("         /trash");
        
    }

    void view(string[] args)
    {
        string folder = args[0];
        if (folder == "/system")
        {
            appendLogLine("\n");
            appendLogLine("         Folder opened:");
            appendLogLine("\n");
            appendLogLine("         /system");
            appendLogLine("             /system.ini");

        }
        else if (folder == "/downloads")
        {
            appendLogLine("\n");
            appendLogLine("         Folder opened:");
            appendLogLine("\n");
            appendLogLine("         /downloads");
            appendLogLine("             /untitled.img");
            appendLogLine("             /untitled(2).img");
            appendLogLine("             /ym_install.exe");
        }
        else if (folder == "/documents")
        {
            appendLogLine("\n");
            appendLogLine("         Folder opened:");
            appendLogLine("\n");
            appendLogLine("         /documents");
            appendLogLine("             /password.reg");
            appendLogLine("             /Important_Work_Folder.zip");
            appendLogLine("             /Map.map");
        }
        else if (folder == "/trash")
        {
            appendLogLine("\n");
            appendLogLine("         Folder opened:");
            appendLogLine("\n");
            appendLogLine("         /trash");
            appendLogLine("             /brInstall.exe");
            appendLogLine("             /Top100Songs.mp4");
        }
        else if (folder == "/system/system.ini" || folder == "/downloads/untitled.img" || folder == "/downloads/untitled(2).img" || folder == "/downloads/ym_install.exe" || folder == "/trash/brInstall.exe" || folder == "/trash/Top100Songs.mp4")
        {
            appendLogLine("         <color=red>Cannot open, file is password-protected.</color>");
        }
        else if (folder == "/documents/passwordgenerator.exe" || folder == "/documents/Important_Work_Folder.zip")
        {
            appendLogLine("         <color=red>Cannot open, command not followed, use some other command to open the file</color>");
        }
        if (folder != "/system/system.ini" && folder != "/downloads/untitled.img" && folder != "/downloads/untitled(2).img" && folder != "/downloads/ym_install.exe" && folder != "/trash/brInstall.exe" && folder != "/trash/Top100Songs.mp4" 
            && folder != "/system" && folder != "/documents" && folder != "/downloads" && folder != "/trash" && folder != "/documents/passwordgenerator.exe" && folder != "/documents/Important_Work_Folder.zip")
        {
            appendLogLine("         <color=red>Folder/file not found.</color>");
        }
    }

    void download(string[] args)
    {
        if (args.Length < 2)
        {
            appendLogLine("password not entered, input password.");
            return;
        }
        string folder = args[0];
        string password = args[1];
        
        if ((password == "MVERH75" || password == "mverh75") && (folder == "/documents/Important_Work_Folder.zip"))
        {
            GameManager.impFile = true;
            
            appendLogLine("<color=green>file downloaded and unzipped, check file browser</color>");
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(12);
            ConsoleView.console_obj.GetComponent<task_Property>().add_Task();

        }
        
        else
        {
            if(password != "MVERH75" && password != "mverh75")
                appendLogLine("         <color=red>Incorrect password. Please try again.</color>");

            if(folder != "/documents/Important_Work_Folder.zip")
                appendLogLine("        <color=red> Incorrect folder/file. Please try again on a zip file.</color>");
        }
    }

    //void open(string[] args)
    //{
    //    string path = args[0];
       

    //    if (path == "/documents/Map.map")
    //    {
    //        GameManager.dynamicMap = true;
    //        appendLogLine("Dynamic map Opening.....");
    //        appendLogLine("Application opened.");
    //    }
    //    else
    //    {
    //        appendLogLine("         Incorrect path. Please try again.");
    //    }
    //}

    void wftrack(string[] args)
    {
        string code = args[0];

        if(code == "5558181293")
        {
            GameManager.sd6 = true;
            
            appendLogLine("         Device: VLAD_CELL   108.10.221");
            appendLogLine("         Co-ordinates: 88'69'26E,48S");
            appendLogLine("         <color=green>Device tracked</color>");
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(15);
            ConsoleView.console_obj.GetComponent<task_Property>().add_Task();
        }
        else
        {
            appendLogLine("         <color=red>Incorrect codelist. Please try again.</color>");
        }
    }

    #endregion
}