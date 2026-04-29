using System;
using System.Linq; 

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("ادخل رقم : ");

        string input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("خطأ: لم تقم بإدخال أي قيمة.");
            return;
        }

        int value = 0;

        try
        {
            if (input.StartsWith("0b", StringComparison.OrdinalIgnoreCase) || input.All(c => c == '0' || c == '1'))
            {
                input = input.Replace("0b", "", StringComparison.OrdinalIgnoreCase);
                value = Convert.ToInt32(input, 2);
            }
            else
            {
                input = input.Replace("0x", "", StringComparison.OrdinalIgnoreCase);
                value = Convert.ToInt32(input, 16);
            }
        }
        catch (Exception)
        {
            Console.WriteLine(" يرجى إدخال رقم");
        }

        
        int teamA = (value >> 12) & 0x1F;
        int teamB = (value >> 7) & 0x1F;
        int tournament = (value >> 5) & 0x3;
        int matchState = (value >> 3) & 0x3;
        int stadium = (value >> 2) & 0x1;
        int referee = (value >> 1) & 0x1;

        string teamAName = GetTeam(teamA);
        string teamBName = GetTeam(teamB);
        string tournamentName = GetTournament(tournament);
        string matchResult = GetMatchResult(matchState, teamAName, teamBName);

        string stadiumName = stadium == 0 ? $"ملعب {teamAName}" : $"ملعب {teamBName}";
        string refereeType = referee == 0 ? "حكم محلي" : "حكم أجنبي";

        Console.WriteLine("\n===== نتيجة المباراة =====");
        Console.WriteLine($"المباراة: {teamAName} vs {teamBName}");
        Console.WriteLine($"البطولة: {tournamentName}");
        Console.WriteLine($"النتيجة: {matchResult}");
        Console.WriteLine($"الملعب: {stadiumName}");
        Console.WriteLine($"الحكم: {refereeType}");
    }

    static string GetTeam(int code)
    {
        return code switch
        {
            1 => "النصر",
            2 => "الهلال",
            3 => "الأهلي",
            4 => "القادسية",
            5 => "التعاون",
            6 => "الاتحاد",
            7 => "الاتفاق",
            8 => "نيوم",
            9 => "الحزم",
            10 => "الخليج",
            11 => "الفيحاء",
            12 => "الشباب",
            13 => "الفتح",
            14 => "الخلود",
            15 => "ضمك",
            16 => "الرياض",
            17 => "الأخدود",
            18 => "النجمة",
            _ => "غير معروف" 
        };
    }

    static string GetTournament(int code)
    {
        return code switch
        {
            0 => "دوري روشن",
            1 => "كأس الملك",
            2 => "السوبر",
            3 => "ولي العهد",
            _ => "غير معروف"
        };
    }

    static string GetMatchResult(int state, string teamA, string teamB)
    {
        return state switch
        {
            0 => $"{teamA} فاز", 
            1 => $"{teamB} فاز", 
            2 => "تعادل",
            3 => "لم تلعب أو مؤجلة",
            _ => "غير معروف"
        };
    }
}