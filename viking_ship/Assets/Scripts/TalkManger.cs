using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkManger : MonoBehaviour
{
    public GameObject saraGemBox;

    public bool quest1Active = false;
    public bool quest2Active = false;
    public bool quest3Active = false;
    public bool quest4Active = false;
    public bool quest5Active = false;

    public TMPro.TextMeshProUGUI blacksmith_text;
    public TMPro.TextMeshProUGUI tailor_text;
    public TMPro.TextMeshProUGUI magician_text;
    public TMPro.TextMeshProUGUI carpenter_text;

    string[] balcksmithString = new string[] { "내 뒤의 나무 2그루를 베어보게나...!", "도끼질은 할 만한가..? 껄껄껄...", "방금 나무를 벤것 처럼 도끼로는 나무, 칼로는 풀, 망치로는 바위를 채집할 수 있다네..", "내가 가르쳐 주는건 여기까지야..", "이제 마을의 재단사 폴을 찾아가 보도록 하게나.." };
    string[] tailorString = new string[] { "저는 주로 밧줄을 만드는 일을 합니다.", "저희 마을은 신비로운 공간에 둘러싸여있습니다.", "사방이 해변, 사막, 숲으로 나뉘어있어 길을 잃기 쉽지요.", "하늘을 보면 큰 암석이 솟아 있는걸 볼 수 있을겁니다. 그쪽으로 가면 사막이 나오죠.", "맞은편 하늘엔 큰 나무가 보이실겁니다. 그쪽엔 숲이 있습니다.", "마지막으로 낮은 암벽으로 둘러져있는 곳이 해변으로 가는길입니다.", "마을엔 본래 목수인 앤드류도 있었지만 최근에 어디로 갔는지 저는 알 수가 없네요...", "사막 근처에는 마을의 주술사인 사라가 살고 있습니다.", "사라를 만나면 마을에 대해 좀더 자세한 이야기를 들을 수 있을겁니다." };
    string[] magicianString = new string[] { "당신은 외부인 인가요?", "당신에게서 강력한 기운이 느껴지는군요...!", "저희 마을엔 신비한 힘을 지니고 있는 보석들이 숨겨져 있답니다.", "보석들의 힘 덕분에 저희 마을 곳곳엔 순간이동 할 수 있는 이동석들이 존재해요.", "이동석이 있는 곳을 찾아 터치하면 해당 지역으로 순간이동 하실 수 있을거에요.", "최근에 악당 바이킹 로키 군대가 침략해서 저희 마을의 보석을 찾으려하고 있어요..!", "다행히 저번 습격땐 보석을 모두 뺐기지 않았지만, 언제 다시 찾으러 올지 몰라요...!", "로키의 침략에 대비해서 마을의 목수인 앤드류씨가 해변에서 경계를 서면서 배를 만들고 있어요.", "제가 지닌 보석을 당신께 드릴테니 해변에 있는 앤드류씨를 찾아가서 마을을 도와주세요..!", "상자를 부수면 보석이 들어있을거에요.", "이 보석을 얻으면 당신의 강력한 기운과 공명하여 단거리 텔레포트 능력이 개방될거에요.", "그럼 행운을 빕니다. 용사님!" };
    string[] carpenterString = new string[] { "경계중 이상무!", "목수인 내가 어쩌다 경계 근무까지 서게됬는지...참", "당신이 사라가 말한 저희 마을을 구해줄 영웅이시군요!", "바이킹 로키의 침략에 대비해서 마을 사람들이 배를 만들고 있긴합니다만... 턱없이 부족한 실정이네요...", "저희 마을을 위해 배를 제작할 재료를 구하는 일을 도와주세요..!", "오 하나님! 역시 도와주실줄 알았습니다.. 용사님!!", "대가로 저희 마을에 숨겨진 두 번째 보석의 위치를 알려드립죠..!", "두 번째 보석의 위치는 숲의 입구에서 돌산을 따라서 오른쪽으로 쭉 가보시면 있을겁니다!", "그럼 행운일 빕니다. 용사님!!"};

    public int balcksmith_num = 0;
    public int tailor_num = 0;
    public int magician_num = 0;
    public int carpenter_num = 0;

    // 대장장이 talk
    public void balcksmithText()
    {
        // 대장장이와 대화해야 퀘스트1 활성화
        if (balcksmith_num < balcksmithString.Length)
        {
            blacksmith_text.text = balcksmithString[balcksmith_num];
            balcksmith_num++;
        }
        else
        {
            balcksmith_num = 0;
            quest1Active = true;
        }
    }

    // 재단사 talk
    public void tailorText()
    {
        if (tailor_num < tailorString.Length)
        {
            tailor_text.text = tailorString[tailor_num];
            tailor_num++;
        }
        else tailor_num = 0;
    }

    // 주술사 talk
    public void magicianText()
    {
        // 주술사와 대화해야 퀘스트2 활성화
        if (magician_num < magicianString.Length)
        {
            magician_text.text = magicianString[magician_num];
            magician_num++;
        }
        else
        {
            magician_num = 0;
            saraGemBox.SetActive(true);
            quest2Active = true;
        }
    }

    // 목수 talk
    public void carpenterText()
    {
        // 목수와 대화해야 퀘스트3 활성화
        if (carpenter_num < carpenterString.Length)
        {
            carpenter_text.text = carpenterString[carpenter_num];
            carpenter_num++;
        }
        else
        {
            carpenter_num = 0;
            quest3Active = true;
        }
    }
}
