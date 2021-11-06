using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TypingManager : MonoBehaviour
{
    public int convIndex;
    public Transform brovo;
    public LastSiblingCheck lastSiblingCheck;
    public GameObject syncdocsweb;
    public GameObject scrollview;
    public Scrollbar scrollbar;
    public GameObject[] choices;
    public GameObject[] keywords;
    public TextMeshProUGUI[] dialogText;
    [TextArea(3, 10)]
    public string[] typingContent;
    public GameObject tinaIcon;
    public GameObject mainScrollView;
    public GameObject a4ScrollView;
    public GameObject textBoxSizeCalculator;
    public Brovo brovoScript;
    public GameObject updateText;

    TextMeshProUGUI typingText;
    int paraIndex;
    int strIndex;
    int stringNum;
    int prePlayerPara;
    int preNpcPara;
    int playerPara;
    int npcPara;
    int charPerKeyMin;
    int charPerKeyMax;
    int autoTypingMin;
    int autoTypingMax;
    float playerTime;
    float npcTime;
    float playerPauseTime;
    float playerNametagTime;
    float npcNametagTime;
    float updateTextTime;
    bool playerCanType;
    bool bgmFadeOutStarted;
    bool[] paraFinished;
    bool[] paraDevided;
    string lastPara;
    string[] typingString;
    int voCount = 0;
    int voCount1 = 0;
    int voCount2 = 0;
    int voCount3 = 0;
    int voCount4 = 0;
    int voCount6 = 0;

    private void Awake()
    {
        paraIndex = 0;
        strIndex = 0;
        stringNum = 0;
        paraFinished = new bool[dialogText.Length];
        paraDevided = new bool[dialogText.Length];
        typingText = dialogText[0];
        prePlayerPara = -1;
        preNpcPara = -1;
        playerPara = -1;
        npcPara = -1;
        playerPauseTime = 0;
        playerNametagTime = 0;
        npcNametagTime = 10;
        playerCanType = true;
        bgmFadeOutStarted = false;
        updateTextTime = 0;

        for (int i = 0; i < dialogText.Length; i++)
        {
            dialogText[i].text = "";
            paraFinished[i] = false;
            paraDevided[i] = false;
        }
        charPerKeyMin = 1;
        charPerKeyMax = 5;
        autoTypingMin = 3;
        autoTypingMax = 5;

        if (GameManager.typingEffectOn)
            DivideStrings();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (convIndex != 1)
        {
            StartCoroutine(AutoTyping(0, false));
            playerCanType = false;
            tinaIcon.SetActive(true);
            charPerKeyMin = 1 + convIndex;
            charPerKeyMax = 5 + convIndex;
        }
    }

    private void Update()
    {
        VoiceOver();
        
        if(!paraFinished[dialogText.Length - 1])
        {
            PlayerCursor();
            NPCCursor();
            HackerTyping();
            ForceExpand();
            TextBoxHeight(paraIndex);
            if (GameManager.typingEffectOn && !paraDevided[paraIndex])
                DivideStrings();
        }
        if (scrollview.activeSelf)
        {
            AutoA4paper();
            if (updateText.activeSelf)
            {
                if(paraFinished[dialogText.Length-1])
                    SaveVersionAnimaiton();
                else
                    CreateVersionAnimation();
            }
        }   
    }

    //Sound effect ========================================================================================================

    void VoiceOver()
    {
        if(convIndex == 1)
        {
            if (paraIndex == 1 && !tinaIcon.activeSelf)
            {
                tinaIcon.SetActive(true);
                voCount++;
                if (voCount == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[11]);
                    voCount = 0;
                }
            }

            if (paraIndex == 3)
            {
                if (!paraFinished[3] && !bgmFadeOutStarted)
                {
                    StartCoroutine(SettingsManager.AudioController.FadeOut(SettingsManager.instance.current_PlayingBGM, 3.5f));

                    if (SettingsManager.instance.current_PlayingBGM.volume < .01f)
                    {
                        bgmFadeOutStarted = true;
                    }
                    //if (SettingsManager.instance.current_PlayingBGM != null && !SettingsManager.instance.fadeOutDone)
                    //StartCoroutine(SettingsManager.AudioController.FadeOut(SettingsManager.instance.current_PlayingBGM, 1f));
                    //bgmFadeOutStarted = true;
                    //Debug.Log("jjjjjjj");
                    //}
                    //if(SettingsManager.instance.current_PlayingBGM != null && SettingsManager.instance.fadeOutDone)
                    //StartCoroutine(SettingsManager.AudioController.FadeIn(SettingsManager.instance.current_PlayingBGM, 1f));
                } //TODO: trigger fade in fade out effect here
            }

            if (paraIndex == 18)
            {
                voCount++;
                if (voCount == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[12]);
                }
            }
        }

        if(convIndex == 2)
        {
            if (paraIndex == 10)
            {
                voCount2++;
                if (voCount2 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[16]);
                }
            }

            if (paraIndex == 16)
            {
                voCount3++;
                if (voCount3 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[16]);
                }
            }

            if (paraIndex == 20)
            {
                voCount4++;
                if (voCount4 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[16]);
                }
            }
        }
    }

    //Visual effect ========================================================================================================

    void AutoScrollView()
    {
        if (scrollbar.GetComponent<Scrollbar>().value > 0)
            scrollbar.GetComponent<Scrollbar>().value = 0;
    }

    void ForceExpand()
    {
        float h = 120;
        for (int i = 0; i < dialogText.Length; i++)
            if (dialogText[i].gameObject.activeSelf)
                h += dialogText[i].GetComponent<RectTransform>().rect.height + 10;
        if (convIndex < 4 && mainScrollView.transform.GetChild(0).transform.GetChild(convIndex - 1).transform.Find("Spaceholder").gameObject.activeSelf)
            h += mainScrollView.transform.GetChild(0).transform.GetChild(convIndex - 1).transform.Find("Spaceholder").GetComponent<RectTransform>().rect.height;
        if (scrollview.GetComponent<RectTransform>().rect.height < h)
        {
            scrollview.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
            AutoScrollView();
        }
    }

    void TextBoxHeight(int index) {
        textBoxSizeCalculator.GetComponent<TextMeshProUGUI>().text = typingContent[index];
        float h = textBoxSizeCalculator.GetComponent<RectTransform>().rect.height;
        if(dialogText[index].gameObject.GetComponent<RectTransform>().rect.height != h)
            dialogText[index].gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
    }// Calculate the suitable height for the new text box base on its content

    void AutoA4paper()
    {
        Scrollbar mainScrollbar = mainScrollView.transform.GetChild(1).GetComponent<Scrollbar>();
        Scrollbar a4Scrollbar = a4ScrollView.transform.GetChild(1).GetComponent<Scrollbar>();
        GameObject mainContent = mainScrollView.transform.GetChild(0).transform.GetChild(convIndex - 1).gameObject;
        GameObject a4Content = a4ScrollView.transform.GetChild(0).transform.GetChild(0).gameObject;
        //scroll paper with conversations
        if (mainScrollbar.gameObject.activeSelf)
            a4Scrollbar.value = mainScrollbar.value;
        else
            a4Scrollbar.value = 1;
        //make paper's content same height with conversation content
        a4Content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mainContent.GetComponent<RectTransform>().rect.height);
        //add space before the text box that should start a new paper
        if(convIndex < 4)
        {
            GameObject spaceholder = mainContent.transform.Find("Spaceholder").gameObject;
            if (!spaceholder.activeSelf)
            {
                float p = 70;
                for (int i = 0; i < dialogText.Length; i++)
                {
                    if (dialogText[i].gameObject.activeSelf)
                        p += dialogText[i].GetComponent<RectTransform>().rect.height + 10;
                    if (p > 1000 && !spaceholder.activeSelf)
                    {
                        spaceholder.gameObject.SetActive(true);
                        spaceholder.transform.SetSiblingIndex(i + 1);
                        spaceholder.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1200 - p);
                    }
                }
            }
        }
    }

    void CreateVersionAnimation()
    {
        if (convIndex == 1)
            updateText.GetComponent<Text>().text = "New document created by Scott";
        else
            updateText.GetComponent<Text>().text = "New version created by Unkown User";
        updateTextTime += Time.deltaTime;
        if (updateTextTime < 1)
            updateText.GetComponent<Text>().color = new Color32(115, 115, 115, 255);
        else if (updateTextTime < 2)
            updateText.GetComponent<Text>().color = Color32.Lerp(updateText.GetComponent<Text>().color, new Color32(115, 115, 115, 0), updateTextTime/10);
        else
            updateText.SetActive(false);
    }

    void SaveVersionAnimaiton()
    {
        updateText.GetComponent<Text>().text = "All changes have been saved";
        updateTextTime += Time.deltaTime;
        if (updateTextTime < 1)
            updateText.GetComponent<Text>().color = new Color32(115, 115, 115, 255);
        else if (updateTextTime < 2)
            updateText.GetComponent<Text>().color = Color32.Lerp(updateText.GetComponent<Text>().color, new Color32(115, 115, 115, 0), updateTextTime / 10);
        else
            updateText.SetActive(false);
    }

    //Typing effect ==========================================================================================================

    float waitTime(string lastPara)
    {
        if (convIndex == 1 && paraIndex == 1) return 1;
        if (lastPara.Length > 300) return 4;
        else if (lastPara.Length > 200) return 3;
        else if (lastPara.Length > 100) return 2;
        return 1;
    }

    void HackerTyping()
    {
        if (playerCanType && lastSiblingCheck.IsLastSibling(brovo) && syncdocsweb.activeInHierarchy)
        {
            updateText.SetActive(true);
            brovoScript.GetComponent<Brovo>().SyncDocsNotification(false);
            playerPara = paraIndex;
            if (typingText.text == "")
                if (playerNametagTime < 2f)
                    typingText.text = "<sprite=0>";
            if (prePlayerPara >= 0 && dialogText[prePlayerPara].text[dialogText[prePlayerPara].text.Length - 1] == '|')
                dialogText[prePlayerPara].text = dialogText[prePlayerPara].text.Substring(0, dialogText[prePlayerPara].text.Length - 1);
            playerPauseTime += Time.deltaTime;
            playerNametagTime += Time.deltaTime;
            if (Input.anyKeyDown)
            {
                if (Input.GetMouseButtonDown(0)
                     || Input.GetMouseButtonDown(1)
                     || Input.GetMouseButtonDown(2))
                    return;
                playerPauseTime = 0;
                if (GameManager.typingEffectOn)
                {
                    SettingsManager.instance.play_Random_KeyPress();
                    if (typingText.text.Length > 0 && typingText.text[typingText.text.Length - 1] == '>')
                        typingText.text = typingText.text.Substring(0, typingText.text.Length - 10);
                    if (typingText.text.Length > 0 && typingText.text[typingText.text.Length - 1] == '|')
                        typingText.text = typingText.text.Substring(0, typingText.text.Length - 1);
                    if (playerNametagTime < 2f)
                        typingText.text += typingString[strIndex] + "<sprite=0>";
                    else
                        typingText.text += typingString[strIndex] + "|";
                    strIndex++;
                    if (strIndex == stringNum)
                    {
                        paraFinished[paraIndex] = true;
                        prePlayerPara = paraIndex;
                        if (startNext())
                            SwitchTypingText(true);
                        else
                            Conversations();
                    }
                }
                else
                {
                    typingText.text = "";
                    playerCanType = false;
                    StartCoroutine(AutoTyping(0, true));
                }
            }
        }
    } //player uses hacker typing

    IEnumerator AutoTyping(float wait, bool isPlayer)
    {
        yield return new WaitForSeconds(wait);
        if (typingText.text == "")
            typingText.text = "<sprite=0>";
        if (isPlayer)
        {
            playerPara = paraIndex;
            playerNametagTime = 0;
            if (prePlayerPara >= 0 && dialogText[prePlayerPara].text[dialogText[prePlayerPara].text.Length - 1] == '|')
                dialogText[prePlayerPara].text = dialogText[prePlayerPara].text.Substring(0, dialogText[prePlayerPara].text.Length - 1);
        }
        else
        {
            npcPara = paraIndex;
            npcNametagTime = 0;
            if (preNpcPara >= 0 && dialogText[preNpcPara].text[dialogText[preNpcPara].text.Length - 1] == '|')
                dialogText[preNpcPara].text = dialogText[preNpcPara].text.Substring(0, dialogText[preNpcPara].text.Length - 1);
        }
        int count = 0;
        int autoTypingPause = Random.Range(autoTypingMin, autoTypingMax);
        foreach (char letter in typingContent[paraIndex].ToCharArray())
        {
            if (typingText.text.Length > 0 && typingText.text[typingText.text.Length - 1] == '>')
                typingText.text = typingText.text.Substring(0, typingText.text.Length - 10);
            if (typingText.text.Length > 0 && typingText.text[typingText.text.Length - 1] == '|')
                typingText.text = typingText.text.Substring(0, typingText.text.Length - 1);
            if (isPlayer)
            {
                if (playerNametagTime > 0.5)
                    typingText.text += letter + "|";
                else
                {
                    typingText.text += letter + "<sprite=0>";
                    playerNametagTime += Time.deltaTime;
                }
            }
            else
            {
                if (npcNametagTime > 0.5)
                    typingText.text += letter + "|";
                else
                {
                    typingText.text += letter + "<sprite=0>";
                    npcNametagTime += Time.deltaTime;
                }
            }
            count++;
            if (GameManager.typingEffectOn)
            {
                if (count == autoTypingPause)
                {
                    yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
                    count = 0;
                    autoTypingPause = Random.Range(autoTypingMin, autoTypingMax);
                }
                yield return new WaitForSeconds(Random.Range(0.01f, 0.03f));
            }
            else
                yield return new WaitForSeconds(0.01f);
        }
        AutoScrollView();
        paraFinished[paraIndex] = true;
        if (isPlayer) prePlayerPara = paraIndex;
        else preNpcPara = paraIndex;
        if (startNext())
            SwitchTypingText(isPlayer);
        else
            Conversations();
    } //NPC uses auto typing

    void PlayerCursor()
    {
        if (Time.time - playerTime >= 0.5)
        {
            playerTime = Time.time;
            bool cursorOn = true;
            if (playerPara > 0 && paraFinished[playerPara]) //finished current paragraph
            {
                if (dialogText[playerPara].text != "" && dialogText[playerPara].text[dialogText[playerPara].text.Length - 1] == '>')
                    dialogText[playerPara].text = dialogText[playerPara].text.Substring(0, dialogText[playerPara].text.Length - 10);
                if (cursorOn && dialogText[playerPara].text[dialogText[playerPara].text.Length - 1] == '|')
                {
                    dialogText[playerPara].text = dialogText[playerPara].text.Substring(0, dialogText[playerPara].text.Length - 1);
                    cursorOn = false;
                }
                else
                {
                    dialogText[playerPara].text += "|";
                    cursorOn = true;
                }
            }
            else if (playerPauseTime > 0.5 && playerNametagTime > 2) //if there still sth to type but you stoped more than half second
            {
                if (dialogText[playerPara].text != "" && dialogText[playerPara].text[dialogText[playerPara].text.Length - 1] == '>')
                    dialogText[playerPara].text = dialogText[playerPara].text.Substring(0, dialogText[playerPara].text.Length - 10);
                if (dialogText[playerPara].text == "" || dialogText[playerPara].text[dialogText[playerPara].text.Length - 1] != '|')
                    cursorOn = false;
                if (cursorOn && dialogText[playerPara].text[dialogText[playerPara].text.Length - 1] == '|')
                {
                    dialogText[playerPara].text = dialogText[playerPara].text.Substring(0, dialogText[playerPara].text.Length - 1);
                    cursorOn = false;
                }
                else
                {
                    dialogText[playerPara].text += '|';
                    cursorOn = true;
                }
            }
        }
    } //player's cursor blinks when finished typing, pausing typing, or need to start a new paragraph

    void NPCCursor()
    {
        if (Time.time - npcTime >= 0.5)
        {
            npcTime = Time.time;
            bool cursorOn = true;
            if (npcPara >= 0 && paraFinished[npcPara])
            {
                npcNametagTime = 10;
                if (dialogText[npcPara].text[dialogText[npcPara].text.Length - 1] == '>')
                    dialogText[npcPara].text = dialogText[npcPara].text.Substring(0, dialogText[npcPara].text.Length - 10);
                if (cursorOn && dialogText[npcPara].text[dialogText[npcPara].text.Length - 1] == '|')
                {
                    dialogText[npcPara].text = dialogText[npcPara].text.Substring(0, dialogText[npcPara].text.Length - 1);
                    cursorOn = false;
                }
                else
                {
                    dialogText[npcPara].text = dialogText[npcPara].text + "|";
                    cursorOn = true;
                }
            }
        }
    } //npc's cursor only blinks when he/she finished typing the paragraphw

    void SwitchTypingText(bool isPlayer)
    {
        lastPara = typingContent[paraIndex];
        paraIndex += 1;
        dialogText[paraIndex].gameObject.SetActive(true);
        if (paraIndex < dialogText.Length) //check if conversation ends
        {
            typingText = dialogText[paraIndex];
            AutoScrollView();
            if (isPlayer)
            {
                playerCanType = false;
                StartCoroutine(AutoTyping(waitTime(lastPara), false));
            }
            else
            {
                strIndex = 0;
                playerCanType = true;
                playerNametagTime = 0;
            }
        }
        else
            RemoveBothCursors();
    } //when one person finish typing, switch to next text box

    void DivideStrings()
    {
        stringNum = 0;
        typingString = new string[typingContent[paraIndex].Length / charPerKeyMin];
        int c = 0, tsc = 0;
        string temp = "";
        int charPerKey = Random.Range(charPerKeyMin, charPerKeyMax+1);
        for(int i = 0; i < typingContent[paraIndex].Length; i++)
        {
            temp += typingContent[paraIndex][i];
            c++;
            if(c == charPerKey)
            {
                typingString[tsc] = temp;
                temp = "";
                tsc++;
                c = 0;
                stringNum++;
                if (i < typingContent[paraIndex].Length - 1)
                    charPerKey = Random.Range(charPerKeyMin, charPerKeyMax + 1);
            }
        }
        if(temp != "")
        {
            typingString[tsc] = temp;
            stringNum++;
        }
        paraDevided[paraIndex] = true;
    } //divide player's dialog into small strings and make an array

    void RemoveBothCursors()
    {
        if (dialogText[prePlayerPara].text[dialogText[prePlayerPara].text.Length - 1] == '|')
            dialogText[prePlayerPara].text = dialogText[prePlayerPara].text.Substring(0, dialogText[prePlayerPara].text.Length - 1);
        if (dialogText[preNpcPara].text[dialogText[preNpcPara].text.Length - 1] == '|')
            dialogText[preNpcPara].text = dialogText[preNpcPara].text.Substring(0, dialogText[preNpcPara].text.Length - 1);
        if (dialogText[prePlayerPara].text[dialogText[prePlayerPara].text.Length - 1] == '>')
            dialogText[prePlayerPara].text = dialogText[prePlayerPara].text.Substring(0, dialogText[prePlayerPara].text.Length - 10);
        if (dialogText[preNpcPara].text[dialogText[preNpcPara].text.Length - 1] == '>')
            dialogText[preNpcPara].text = dialogText[preNpcPara].text.Substring(0, dialogText[preNpcPara].text.Length - 10);
    } //when this conversation finished, both player and npc stop typing

    void EndConversation()
    {
        GameManager.sdend[convIndex-1] = true;
        tinaIcon.SetActive(false);
        RemoveBothCursors();
        updateText.SetActive(true);
        updateTextTime = 0;
        if (convIndex == 1)
        {
           // voCount = 0;
            voCount1++;
            if (voCount1 == 1)
            {
                SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[13]);
            }

            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(2);
            this.GetComponent<task_Property>().add_Task();
            this.GetComponent<task_Property>().add_Task();
        }
        if (convIndex == 3)
        {
            Messenger_Manager.messenger_Obj.GetComponent<Messenger_Manager>().Initialize_NewCharacter("Alex Perry");
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(8);
            this.GetComponent<task_Property>().add_Task();
            Messenger_Dropzone_Manager.alex_Active = true;
        }
        if (convIndex == 2)
        {
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(5);
            this.GetComponent<task_Property>().add_Task();
        }
        if (convIndex == 4)
        {
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(10);
            this.GetComponent<task_Property>().add_Task();
        }
        if (convIndex == 5)
        {
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(14);
            this.GetComponent<task_Property>().add_Task();
        }
        if (convIndex == 6)
        {
            task_Manager.task_obj.GetComponent<task_Manager>().try_FinishTask(16);
        }
    }
    
    void StartOption(int index)
    {
        GameObject thisbutton = EventSystem.current.currentSelectedGameObject;
        thisbutton.transform.parent.gameObject.SetActive(false);
        JumpToPara(index, false, true);
    }

    void JumpToPara(int index, bool playercantype, bool isplayer)
    {
        dialogText[index].gameObject.SetActive(true);
        typingText = dialogText[index];
        lastPara = typingContent[paraIndex];
        paraIndex = index;
        playerCanType = playercantype;
        if (playercantype)
        {
            strIndex = 0;
            DivideStrings();
            playerNametagTime = 0;
        }
        else
            StartCoroutine(AutoTyping(waitTime(lastPara), isplayer));
        AutoScrollView();
    }

    IEnumerator OpenChoicePanel(GameObject panel, float wait)
    {
        yield return new WaitForSeconds(wait);
        panel.SetActive(true);
    }

    //Narrative control ==================================================================================================

    bool startNext()
    {
        if (convIndex == 1)
            if (paraIndex == 3 || paraIndex == 4 || paraIndex == 5 || paraIndex == 6 || paraIndex == 7 || paraIndex == 9 || paraIndex == 12
                || paraIndex == 20 || paraIndex == 21 || paraIndex == 22 || paraIndex == 23 || paraIndex == 26 || paraIndex == 31
                || paraIndex == 40 || paraIndex == 41 || paraIndex == 42 || paraIndex == 43 || paraIndex == 44 || paraIndex == 46 || paraIndex == 51
                || paraIndex == 54) return false;
        if (convIndex == 2)
            if (paraIndex == 6 || paraIndex == 7 || paraIndex == 8 || paraIndex == 9 || paraIndex == 13 || paraIndex == 17 
                || paraIndex == 26 || paraIndex == 27 || paraIndex == 28 || paraIndex == 29 || paraIndex == 32 || paraIndex == 35 
                || paraIndex == 44) return false;
        if (convIndex == 3)
            if (paraIndex == 10 || paraIndex == 11 || paraIndex == 12 || paraIndex == 13
                || paraIndex == 15 || paraIndex == 19 || paraIndex == 34) return false;
        if (convIndex == 4)
            if (paraIndex == 2 || paraIndex == 3 || paraIndex == 4 || paraIndex == 5
                || paraIndex == 9 || paraIndex == 13 || paraIndex == 26) return false;
        if (convIndex == 5)
            if (paraIndex == 4) return false;
        if (convIndex == 6)
            if (paraIndex == 14) return false;
        return true;
    }

    void Conversations()
    {
        if (convIndex == 1)
        {
            // choice 1 -----------------------------------------------------------------------
            if (paraIndex == 3)
            {
                StartCoroutine(OpenChoicePanel(choices[0], 1));
                SettingsManager.instance.fadeOutDone = true;
                SettingsManager.instance.PlayBGM(SettingsManager.instance.bgmClips[1]);
                //StartCoroutine(SettingsManager.AudioController.FadeIn(SettingsManager.instance.current_PlayingBGM, 1f));
                //bgmFadeOutStarted = false;
            }    

            // choice 1 options
            if (paraIndex == 4)
                JumpToPara(7, false, false);
            if (paraIndex == 5)
                JumpToPara(8, false, false);
            if (paraIndex == 6)
                JumpToPara(10, false, false);

            //finish choice 1
            if ((paraIndex == 7 || paraIndex == 9 || paraIndex == 12) && paraFinished[paraIndex])
                JumpToPara(13, false, false);

            //choice 2 -------------------------------------------------------------------------
            if (paraIndex == 20)
                StartCoroutine(OpenChoicePanel(choices[1], 1));

            // choice 2 options
            if (paraIndex == 21)
                JumpToPara(24, false, false);
            if (paraIndex == 22)
                JumpToPara(27, false, false);
            if (paraIndex == 23)
                JumpToPara(32, false, false);

            //finish choice 2
            if ((paraIndex == 26 || paraIndex == 31) && paraFinished[paraIndex])
                JumpToPara(35, true, true);

            //choice 3 -------------------------------------------------------------------------
            if (paraIndex == 40)
                StartCoroutine(OpenChoicePanel(choices[2], 1));

            // choice 3 options
            if (paraIndex == 41)
                JumpToPara(44, false, false);
            if (paraIndex == 42)
                JumpToPara(45, false, false);
            if (paraIndex == 43)
                JumpToPara(47, false, false);

            //finish choice 3
            if ((paraIndex == 44 || paraIndex == 46) && paraFinished[paraIndex])
                JumpToPara(52, false, false);

            //Game Over
            if (paraIndex == 51 && paraFinished[paraIndex])
            {
                GameManager.gameOverAnimation = true;
            }

            //end conversation----------------------------------------------------------------
            if (paraIndex == 54 && paraFinished[paraIndex])
            {
                keywords[0].SetActive(true);
                keywords[1].SetActive(true);
                dialogText[54].GetComponent<TextMeshProUGUI>().text = "Oh! I do know the names of two girls in my dorm" +
                    ":                   and              . Let me know if you find anything out. I’ll be waiting";
                EndConversation();
            }
        }
        if (convIndex == 2)
        {
            // choice 1----------------------------------------------------------------
            if (paraIndex == 6)
                StartCoroutine(OpenChoicePanel(choices[0], 1));

            // choice 1 options
            if (paraIndex == 7)
                JumpToPara(10, false, false);
            if (paraIndex == 8)
                JumpToPara(14, false, false);
            if (paraIndex == 9)
                JumpToPara(18, false, false);

            //finish choice 1
            if ((paraIndex == 13 || paraIndex == 17) && paraFinished[paraIndex])
                JumpToPara(22, false, false);

            // choice 2-----------------------------------------------------------------
            if (paraIndex == 26)
                StartCoroutine(OpenChoicePanel(choices[1], 1));

            // choice 2 options
            if (paraIndex == 27)
                JumpToPara(30, false, false);
            if (paraIndex == 28)
                JumpToPara(33, false, false);
            if (paraIndex == 29)
                JumpToPara(36, false, false);

            //finish choice 2
            if ((paraIndex == 32 || paraIndex == 35) && paraFinished[paraIndex])
                JumpToPara(37, true, true);

            //end conversation
            if (paraIndex == 44 && paraFinished[paraIndex])
                EndConversation();
        }
        if (convIndex == 3)
        {
            // choice 1
            if (paraIndex == 10)
                StartCoroutine(OpenChoicePanel(choices[0], 1));

            // choice 1 options
            if (paraIndex == 11)
                JumpToPara(14, false, false);
            if (paraIndex == 12)
                JumpToPara(16, false, false);
            if (paraIndex == 13)
                JumpToPara(20, false, false);

            //finish choice 1
            if ((paraIndex == 15 || paraIndex == 19) && paraFinished[paraIndex])
                JumpToPara(22, false, false);

            //end conversation
            if (paraIndex == 34 && paraFinished[paraIndex])
                EndConversation();
        }
        if (convIndex == 4)
        {
            // choice 1
            if (paraIndex == 2 && paraFinished[paraIndex])
            {
                keywords[0].SetActive(true);
                dialogText[2].GetComponent<TextMeshProUGUI>().text = "I call it          .Long story short, it lets you access a computer’s files and download them";
                voCount6++;
                if (voCount6 == 1)
                {
                    SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[20]);
                }
                StartCoroutine(OpenChoicePanel(choices[0], 1));
            }

            // choice 1 options
            if (paraIndex == 3)
                JumpToPara(6, false, false);
            if (paraIndex == 4)
                JumpToPara(10, false, false);
            if (paraIndex == 5)
                JumpToPara(14, false, false);

            //finish choice 1
            if ((paraIndex == 9 || paraIndex == 13) && paraFinished[paraIndex])
                JumpToPara(16, false, false);

            //end conversation
            if (paraIndex == 26 && paraFinished[paraIndex])
                EndConversation();
        }
        if (convIndex == 5)
        {
            if (paraIndex == 4 && paraFinished[paraIndex])
                EndConversation();
        }
        if (convIndex == 6)
        {
            if (paraIndex == 14 && paraFinished[paraIndex])
            {
                EndConversation();
                GameManager.gameWonAnimation = true;
            }  
        }
    }

    //function for choice1-1---------------------------------------------------
    public void Option1_1_1()
    {
        StartOption(4);
    }
    public void Option1_1_2()
    {
        StartOption(5);
    }
    public void Option1_1_3()
    {
        StartOption(6);
    }

    //function for choice1-2----------------------------------------------------------
    public void Option1_2_1()
    {
        StartOption(21);
    }
    public void Option1_2_2()
    {
        StartOption(22);
    }
    public void Option1_2_3()
    {
        StartOption(23);
    }

    //function for choice1-3-----------------------------------------------------------
    public void Option1_3_1()
    {
        StartOption(41);
    }
    public void Option1_3_2()
    {
        StartOption(42);
    }
    public void Option1_3_3()
    {
        StartOption(43);
    }

    //function for choice2-1-----------------------------------------------------------
    public void Option2_1_1()
    {
        StartOption(7);
    }
    public void Option2_1_2()
    {
        StartOption(8);
    }
    public void Option2_1_3()
    {
        StartOption(9);
    }

    //function for choice2-2-----------------------------------------------------------
    public void Option2_2_1()
    {
        StartOption(27);
    }
    public void Option2_2_2()
    {
        StartOption(28);
    }
    public void Option2_2_3()
    {
        StartOption(29);
    }

    //function for choice3-1-----------------------------------------------------------
    public void Option3_1_1()
    {
        StartOption(11);
    }
    public void Option3_1_2()
    {
        StartOption(12);
    }
    public void Option3_1_3()
    {
        StartOption(13);
    }

    //function for choice4-1-----------------------------------------------------------
    public void Option4_1_1()
    {
        StartOption(3);
    }
    public void Option4_1_2()
    {
        StartOption(4);
    }
    public void Option4_1_3()
    {
        StartOption(5);
    }
}
