/// <summary>
/// Class responsible for displaying numbers using engineering notation.
/// </summary>
public static class NumberUtility
{
	private static string[] shortExponents =
		{"", "k", "M", "B", "T", "Q", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii"};

	/// <summary>
	/// Format number with a given number of digits after a comma using engineering notation.
	/// </summary>
	/// <param name="number">Number to format.</param>
	/// <param name="digits">Indicates how many digits should be presented after a comma.</param>
	/// <returns></returns>
	public static string FormatNumber(double number, int digits)
	{
		int exponentsCounter = 0;

		while (number / 1000 > 1)
		{
			exponentsCounter++;
			if (exponentsCounter >= shortExponents.Length) exponentsCounter = 0;
			number /= 1000;
		}

		string numberAsString;

		switch (digits)
		{
			case 3:
				numberAsString = $"{number:F3}".Contains(".")
					? $"{number:F3}".TrimEnd('0').TrimEnd('.')
					: $"{number:F3}";
				break;

			case 2:
				numberAsString = $"{number:F2}".Contains(".")
					? $"{number:F2}".TrimEnd('0').TrimEnd('.')
					: $"{number:F2}";
				break;

			case 1:
				numberAsString = $"{number:F1}".Contains(".")
					? $"{number:F1}".TrimEnd('0').TrimEnd('.')
					: $"{number:F1}";
				break;

			default:
				numberAsString = $"{number:F0}".Contains(".")
					? $"{number:F0}".TrimEnd('0').TrimEnd('.')
					: $"{number:F0}";
				break;
		}

		return numberAsString + shortExponents[exponentsCounter];
	}
}
