using System;
using System.Collections.Generic;


#region |CodeGenerator|
// Rastgele kod üreteN sınıf
public class CodeGenerator
{
    private const string CharSet = ConstVariables.CharSet;
    private readonly Random _random;

    public CodeGenerator()
    {
        _random = new Random();
    }

    public string GenerateCode(int length)
    {
        char[] code = new char[length];
        for (int i = 0; i < length; i++)
        {
            code[i] = CharSet[_random.Next(CharSet.Length)];
        }
        return new string(code);
    }
}
#endregion

#region |CodeValidator|
// Kodların geçerliliğini doğrulama
public class CodeValidator
{
    private HashSet<string> usedCodes = new HashSet<string>();

    public bool IsCodeValid(string code)
    {
        if (code.Length != 8)
            return false;

        foreach (char c in code)
        {
            if (!ConstVariables.CharSet.Contains(c))
                return false;
        }
        // Kullanılan kodları takip eden HashSet
        lock (usedCodes)
        {
            if (usedCodes.Contains(code))
                return false;

            usedCodes.Add(code);
        }

        return true;
    }
}
#endregion

#region |Main|
public class Program
{
    public static void Main(string[] args)
    {
        CodeGenerator generator = new CodeGenerator();
        CodeValidator validator = new CodeValidator();

        List<string> generatedCodes = new List<string>();

        int numberOfCodes = 1000;

        for (int i = 0; i < numberOfCodes; i++)
        {
            string code = generator.GenerateCode(8);
            if (validator.IsCodeValid(code))
            {
                generatedCodes.Add(code);
                Console.WriteLine($"Generated Code: {code}");
            }
        }

       
    }
}
#endregion


#region|Const|
public static class ConstVariables
{
    public const string CharSet = "ACDEFGHKLMNPRTXYZ234579";


}
#endregion