using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TalkManger talkmanager;
    public StoneManager stoneManager;

    public TMPro.TextMeshProUGUI quest1_title;
    public TMPro.TextMeshProUGUI quest2_title;
    public TMPro.TextMeshProUGUI quest3_title;
    public TMPro.TextMeshProUGUI quest4_title;
    public TMPro.TextMeshProUGUI quest5_title;

    public TMPro.TextMeshProUGUI quest1_explaination;
    public TMPro.TextMeshProUGUI quest2_explaination;
    public TMPro.TextMeshProUGUI quest3_explaination;
    public TMPro.TextMeshProUGUI quest4_explaination;
    public TMPro.TextMeshProUGUI quest5_explaination;

    string[] quest1_titleString = new string[] { "#1. ���� ������ ��ȭ�ϱ�"};
    string[] quest2_titleString = new string[] { "#2. ��� �ص���� ��ȭ�ϱ�"};
    string[] quest3_titleString = new string[] { "#3. �� ����� ��� ���ؿ���" };
    string[] quest4_titleString = new string[] { "#4. ��Ʈ���� �Ź�" };
    string[] quest5_titleString = new string[] { "#5. ����ŷ ħ�� �����"};

    string[] quest1_explainationString = new string[] { "�������� ��ܻ� ���� ��ȭ�� �� �ּ��� ��� ã�ư��� ��ȭ�Ͻʽÿ�.\n\n ����\n- �ź��� ���� �� �� ����\n(�ڷ���Ʈ �ɷ� ����)" };
    string[] quest2_explainationString = new string[] { "�غ����� ��� �ٹ����� ��� �ص���� ������ ��ȭ�Ͻʽÿ�.\n\n����\n- �� ��° ������ ��ġ\n(�� ��° ���� ����� ���ϸ��� ������ �ɷ� ����)" };
    string[] quest3_explainationString = new string[] { "���� ������� �¿� ū �踦 ������ �մϴ�. ��Ḧ ���ؿ��ʽÿ�.\n����: 50��, ��: 50��, ����: 10��, �ź��� ���� 4��\n\n����\n- ���� ������ �� Ż��. ���� Ŭ����!" };
    string[] quest4_explainationString = new string[] { "������ �� �� ���� ������ ������ �縷ȭ�� �� �������������� ���� ������ ������ �Ŵ�ȭ�� ��Ʈ���� �Ź̸� ����Ʈ���ʽÿ�.\n\n����\n- �� ��° ���� ����\n(���ϸ��� ���ݷ� ��ȭ)" };
    string[] quest5_explainationString = new string[] { "�غ����� ���� �ص���� ��ȭ�� �Ϸ��� �Ŀ� ����ŷ�� ħ���� ����ϼ���.\n\n����\n- �� ��° ���� ����\n���н�\n- ������ ��Ÿ�� �˴ϴ�."};


    public int quest1_num = 0;
    public int quest2_num = 0;
    public int quest3_num = 0;
    public int quest4_num = 0;
    public int quest5_num = 0;

    // quest1 Ȱ��ȭ #1. ���������� ��ȭ�ϱ�
    public void quest1Text()
    {   
        if (talkmanager.quest1Active == true)
        {
            quest1_title.text = quest1_titleString[0];
            quest1_explaination.text = quest1_explainationString[0];
        }
    }

    // quest2 Ȱ��ȭ #2. ����� ��ȭ�ϱ�
    public void quest2Text()
    {
        if (talkmanager.quest2Active == true)
        {
            quest2_title.text = quest2_titleString[0];
            quest2_explaination.text = quest2_explainationString[0];
        }
    }

    // quest3 Ȱ��ȭ #3. �踸��� ��� ���ؿ���
    public void quest3Text()
    {
        if (talkmanager.quest3Active == true)
        {
            quest3_title.text = quest3_titleString[0];
            quest3_explaination.text = quest3_explainationString[0];
        }
    }

    // quest4 Ȱ��ȭ #4. ��Ʈ���� �Ź�
    public void quest4Text()
    {   
        // ���� �� ���� Ȱ��ȭ �Ǿ������� ����Ʈ Ȱ��ȭ
        if (stoneManager.stone1.activation == true && stoneManager.stone2.activation == true)
            talkmanager.quest4Active = true;

        if (talkmanager.quest4Active == true)
        {
            quest4_title.text = quest4_titleString[0];
            quest4_explaination.text = quest4_explainationString[0];
        }
    }
      
    // quest5 Ȱ��ȭ #5. ����ŷ ħ�� �����
    public void quest5Text()
    {
        // ���� �� ���� Ȱ��ȭ �Ǿ������� ����Ʈ Ȱ��ȭ
        if (stoneManager.stone1.activation == true && stoneManager.stone2.activation == true && stoneManager.stone3.activation == true)
            talkmanager.quest5Active = true;

        if (talkmanager.quest5Active == true)
        {
            quest5_title.text = quest5_titleString[0];
            quest5_explaination.text = quest5_explainationString[0];
        }
    }




}
