using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkManger : MonoBehaviour
{
    public TMPro.TextMeshProUGUI blacksmith_text;
    public TMPro.TextMeshProUGUI tailor_text;
    public TMPro.TextMeshProUGUI magician_text;
    public TMPro.TextMeshProUGUI carpenter_text;

    string[] balcksmithString = new string[] { "�� ���� ���� 2�׷縦 ����Գ�...!", "�������� �� ���Ѱ�..? ������...", "��� ������ ���� ó�� �����δ� ����, Į�δ� Ǯ, ��ġ�δ� ������ ä���� �� �ִٳ�..", "���� ������ �ִ°� ���������..", "���� ������ ��ܻ� ���� ã�ư� ������ �ϰԳ�.." };
    string[] tailorString = new string[] { "���� �ַ� ������ ����� ���� �մϴ�.", "���� ������ �ź�ο� ������ �ѷ��ο��ֽ��ϴ�.", "����� �غ�, �縷, ������ �������־� ���� �ұ� ������.", "�ϴ��� ���� ū �ϼ��� �ھ� �ִ°� �� �� �����̴ϴ�. �������� ���� �縷�� ������.", "������ �ϴÿ� ū ������ ���̽ǰ̴ϴ�. ���ʿ� ���� �ֽ��ϴ�.", "���������� ���� �Ϻ����� �ѷ����ִ� ���� �غ����� ���±��Դϴ�.", "������ ���� ����� �ص���� �־����� �ֱٿ� ���� ������ ���� �� ���� ���׿�...", "�縷 ��ó���� ������ �ּ����� ��� ��� �ֽ��ϴ�.", "��� ������ ������ ���� ���� �ڼ��� �̾߱⸦ ���� �� �����̴ϴ�." };
    string[] magicianString = new string[] { "����� �ܺ��� �ΰ���?", "��ſ��Լ� ������ ����� �������±���...!", "���� ������ �ź��� ���� ���ϰ� �ִ� �������� ������ �ִ�ϴ�.", "�������� �� ���п� ���� ���� ������ �����̵� �� �� �ִ� ���������� �����ؿ�.", "�������� �ִ� ���� ã�� ��ġ�ϸ� �ش� �������� �����̵� �Ͻ� �� �����ſ���.", "�ֱٿ� �Ǵ� ����ŷ ��Ű ���밡 ħ���ؼ� ���� ������ ������ ã�����ϰ� �־��..!", "������ ���� ���ݶ� ������ ã�� ��������, ���� �ٽ� ã���� ���� �����...!", "��Ű�� ħ���� ����ؼ� ������ ����� �ص������ �غ����� ��踦 ���鼭 �踦 ����� �־��.", "���� ���� ������ ��Ų� �帱�״� �غ��� �ִ� �ص������ ã�ư��� ������ �����ּ���..!", "���ڸ� �μ��� ������ ��������ſ���.", "�� ������ ������ ����� ������ ���� �����Ͽ� �ܰŸ� �ڷ���Ʈ �ɷ��� ����ɰſ���.", "�׷� ����� ���ϴ�. ����!" };
    string[] carpenterString = new string[] { "����� �̻�!", "����� ���� ��¼�� ��� �ٹ����� ���ԉ����...��", "����� ��� ���� ���� ������ ������ �����̽ñ���!", "����ŷ ��Ű�� ħ���� ����ؼ� ���� ������� �踦 ����� �ֱ��մϴٸ�... �ξ��� ������ �����̳׿�...", "���� ������ ���� �踦 ������ ��Ḧ ���ϴ� ���� �����ּ���..!", "�����ֽŴٸ� �������� �� ��° ������ ��ġ�� �˷��帮�ڽ��ϴ�!"};

    public int balcksmith_num = 0;
    public int tailor_num = 0;
    public int magician_num = 0;
    public int carpenter_num = 0;

    // �������� talk
    public void balcksmithText()
    {
        if (balcksmith_num < balcksmithString.Length)
        {
            blacksmith_text.text = balcksmithString[balcksmith_num];
            balcksmith_num++;
        }
        else balcksmith_num = 0;
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
        if (magician_num < magicianString.Length)
        {
            magician_text.text = magicianString[magician_num];
            magician_num++;
        }
        else magician_num = 0;
    }

    // ��� talk
    public void carpenterText()
    {
        if (carpenter_num < carpenterString.Length)
        {
            carpenter_text.text = carpenterString[carpenter_num];
            carpenter_num++;
        }
        else carpenter_num = 0;
    }
}
