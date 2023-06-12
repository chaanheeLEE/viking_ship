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

    string[] quest1_titleString = new string[] { "#1. 마을 사람들과 대화하기"};
    string[] quest2_titleString = new string[] { "#2. 목수 앤드류와 대화하기"};
    string[] quest3_titleString = new string[] { "#3. 배 만드는 재료 구해오기" };
    string[] quest4_titleString = new string[] { "#4. 수트르의 거미" };
    string[] quest5_titleString = new string[] { "#5. 바이킹 침공 방어전"};

    string[] quest1_explainationString = new string[] { "마을에서 재단사 폴과 대화한 후 주술사 사라를 찾아가서 대화하십시오.\n\n 보상\n- 신비한 보석 한 개 습득\n(텔레포트 능력 개방)" };
    string[] quest2_explainationString = new string[] { "해변에서 경계 근무중인 목수 앤드류를 만나서 대화하십시오.\n\n보상\n- 두 번째 보석의 위치\n(두 번째 보석 습득시 몰니르의 숨겨진 능력 개방)" };
    string[] quest3_explainationString = new string[] { "마을 사람들을 태울 큰 배를 만들어야 합니다. 재료를 구해오십시오.\n나무: 50개, 돌: 50개, 밧줄: 10개, 신비한 보석 4개\n\n보상\n- 마을 사람들과 섬 탈출. 게임 클리어!" };
    string[] quest4_explainationString = new string[] { "보석의 알 수 없는 강력한 힘으로 사막화된 땅 무스팰해임으로 가서 보석의 힘으로 거대화된 수트르의 거미를 쓰러트리십시오.\n\n보상\n- 세 번째 보석 습득\n(몰니르의 공격력 강화)" };
    string[] quest5_explainationString = new string[] { "해변으로 가서 앤드류와 대화를 완료한 후에 바이킹의 침공을 방어하세요.\n\n보상\n- 네 번째 보석 습득\n실패시\n- 마을이 불타게 됩니다."};


    public int quest1_num = 0;
    public int quest2_num = 0;
    public int quest3_num = 0;
    public int quest4_num = 0;
    public int quest5_num = 0;

    // quest1 활성화 #1. 마을사람들과 대화하기
    public void quest1Text()
    {   
        if (talkmanager.quest1Active == true)
        {
            quest1_title.text = quest1_titleString[0];
            quest1_explaination.text = quest1_explainationString[0];
        }
    }

    // quest2 활성화 #2. 목수와 대화하기
    public void quest2Text()
    {
        if (talkmanager.quest2Active == true)
        {
            quest2_title.text = quest2_titleString[0];
            quest2_explaination.text = quest2_explainationString[0];
        }
    }

    // quest3 활성화 #3. 배만드는 재료 구해오기
    public void quest3Text()
    {
        if (talkmanager.quest3Active == true)
        {
            quest3_title.text = quest3_titleString[0];
            quest3_explaination.text = quest3_explainationString[0];
        }
    }

    // quest4 활성화 #4. 수트르의 거미
    public void quest4Text()
    {   
        // 보석 두 개가 활성화 되어있으면 퀘스트 활성화
        if (stoneManager.stone1.activation == true && stoneManager.stone2.activation == true)
            talkmanager.quest4Active = true;

        if (talkmanager.quest4Active == true)
        {
            quest4_title.text = quest4_titleString[0];
            quest4_explaination.text = quest4_explainationString[0];
        }
    }
      
    // quest5 활성화 #5. 바이킹 침공 방어전
    public void quest5Text()
    {
        // 보석 세 개가 활성화 되어있으면 퀘스트 활성화
        if (stoneManager.stone1.activation == true && stoneManager.stone2.activation == true && stoneManager.stone3.activation == true)
            talkmanager.quest5Active = true;

        if (talkmanager.quest5Active == true)
        {
            quest5_title.text = quest5_titleString[0];
            quest5_explaination.text = quest5_explainationString[0];
        }
    }




}
