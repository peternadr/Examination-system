namespace ExaminationSystemCore.Utilities;

public static class Helper
{
    public static int GetValidIntegerInput(string prompt, int minValue, int maxValue)
    {
        int value;
        bool isValid;
        do
        {
            Console.WriteLine(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
        }
        while (!isValid || value < minValue || value > maxValue);
        return value;
    }

    public static string GetNonEmptyStringInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}
