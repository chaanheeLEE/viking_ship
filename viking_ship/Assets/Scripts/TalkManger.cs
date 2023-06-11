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

    string[] balcksmithString = new string[] { "�� ���� ���� 2�׷縦 ����Գ�...!", "�������� �� ���Ѱ�..? ������...", "��� ������ ���� ó�� �����δ� ����, Į�δ� Ǯ, ��ġ�δ� ������ ä���� �� �ִٳ�..", "���� ������ �ִ°� ���������..", "���� ������ ��ܻ� ���� ã�ư� ������ �ϰԳ�.." };
    string[] tailorString = new string[] { "���� �ַ� ������ ����� ���� �մϴ�.", "���� ������ �ź�ο� ������ �ѷ��ο��ֽ��ϴ�.", "����� �غ�, �縷, ������ �������־� ���� �ұ� ������.", "�ϴ��� ���� ū �ϼ��� �ھ� �ִ°� �� �� �����̴ϴ�. �������� ���� �縷�� ������.", "������ �ϴÿ� ū ������ ���̽ǰ̴ϴ�. ���ʿ� ���� �ֽ��ϴ�.", "���������� ���� �Ϻ����� �ѷ����ִ� ���� �غ����� ���±��Դϴ�.", "������ ���� ����� �ص���� �־����� �ֱٿ� ���� ������ ���� �� ���� ���׿�...", "�縷 ��ó���� ������ �ּ����� ��� ��� �ֽ��ϴ�.", "��� ������ ������ ���� ���� �ڼ��� �̾߱⸦ ���� �� �����̴ϴ�." };
    string[] magicianString = new string[] { "����� �ܺ��� �ΰ���?", "��ſ��Լ� ������ ����� �������±���...!", "���� ������ �ź��� ���� ���ϰ� �ִ� �������� ������ �ִ�ϴ�.", "�������� �� ���п� ���� ���� ������ �����̵� �� �� �ִ� �̵������� �����ؿ�.", "�̵����� �ִ� ���� ã�� ��ġ�ϸ� �ش� �������� �����̵� �Ͻ� �� �����ſ���.", "�ֱٿ� �Ǵ� ����ŷ ��Ű ���밡 ħ���ؼ� ���� ������ ������ ã�����ϰ� �־��..!", "������ ���� ���ݶ� ������ ��� ������ �ʾ�����, ���� �ٽ� ã���� ���� �����...!", "��Ű�� ħ���� ����ؼ� ������ ����� �ص������ �غ����� ��踦 ���鼭 �踦 ����� �־��.", "���� ���� ������ ��Ų� �帱�״� �غ��� �ִ� �ص������ ã�ư��� ������ �����ּ���..!", "���ڸ� �μ��� ������ ��������ſ���.", "�� ������ ������ ����� ������ ���� �����Ͽ� �ܰŸ� �ڷ���Ʈ �ɷ��� ����ɰſ���.", "�׷� ����� ���ϴ�. ����!" };
    string[] carpenterString = new string[] { "����� �̻�!", "����� ���� ��¼�� ��� �ٹ����� ���ԉ����...��", "����� ��� ���� ���� ������ ������ �����̽ñ���!", "����ŷ ��Ű�� ħ���� ����ؼ� ���� ������� �踦 ����� �ֱ��մϴٸ�... �ξ��� ������ �����̳׿�...", "���� ������ ���� �踦 ������ ��Ḧ ���ϴ� ���� �����ּ���..!", "�� �ϳ���! ���� �����ֽ��� �˾ҽ��ϴ�.. ����!!", "�밡�� ���� ������ ������ �� ��° ������ ��ġ�� �˷��帳��..!", "�� ��° ������ ��ġ�� ���� �Ա����� ������ ���� ���������� �� �����ø� �����̴ϴ�!", "�׷� ����� ���ϴ�. ����!!"};

    public int balcksmith_num = 0;
    public int tailor_num = 0;
    public int magician_num = 0;
    public int carpenter_num = 0;

    // �������� talk
    public void balcksmithText()
    {
        // �������̿� ��ȭ�ؾ� ����Ʈ1 Ȱ��ȭ
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

    // ��ܻ� talk
    public void tailorText()
    {
        if (tailor_num < tailorString.Length)
        {
            tailor_text.text = tailorString[tailor_num];
            tailor_num++;
        }
        else tailor_num = 0;
    }

    // �ּ��� talk
    public void magicianText()
    {
        // �ּ���� ��ȭ�ؾ� ����Ʈ2 Ȱ��ȭ
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

    // ��� talk
    public void carpenterText()
    {
        // ����� ��ȭ�ؾ� ����Ʈ3 Ȱ��ȭ
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
