using StringCalculator.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Services.Services
{
    public interface ICustomSplitServices
    {
        /// <summary>
        /// Handle a string of numbers with custom delimiters and return a List of positive integers. 
        /// </summary>
        /// <param name="numbers">String of numbers with custom delimiters.</param>
        /// <returns>List of positive integers.</returns>
        List<int> GetNumbers(string numbers);
    }
    public class CustomSplitServices : ICustomSplitServices
    {
        /// <summary>
        /// Handle a string of numbers with custom delimiters and return a List of positive integers. 
        /// </summary>
        /// <param name="numbers">String of numbers with custom delimiters.</param>
        /// <returns>List of positive integers.</returns>
        public List<int> GetNumbers(string numbers)
        {
            List<string> delimiters = new List<string> { ",", "\n" };
            numbers = numbers.Replace("\\n", "\n");
            var numbersSection = numbers;

            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Remove(0, 2);
                var index = numbers.IndexOf("\n");
                var delimitersSection = numbers.Substring(0, index);
                numbersSection = numbers.Substring(index + 1);

                if (delimitersSection.StartsWith("["))
                {
                    delimitersSection = delimitersSection.Remove(0, 1);
                    delimitersSection = delimitersSection.Remove(delimitersSection.Length - 1, 1);

                    var customedelimiters = delimitersSection.Split("][");
                    delimiters.AddRange(customedelimiters);
                }
                else
                {
                    delimiters.Add(delimitersSection);
                }
            }

            var stringNumbers = numbersSection.Split(delimiters.ToArray(), StringSplitOptions.None);

            var numbersList = new List<int>();
            var invalidNumbers = new List<string>();

            foreach (var item in stringNumbers)
            {
                if (int.TryParse(item, out int num))
                {
                    numbersList.Add(num);
                }
                else
                {
                    invalidNumbers.Add(item);
                }
            }
            if (invalidNumbers.Count > 0)
            {
                throw new Exception($"Invalid Numbers { invalidNumbers.ToArrayMessage()}");
            }

            var negatives = numbersList.Where(x => x <= 0).ToList();
            if (negatives.Count > 0)
            {
                throw new Exception($"Negatives not allowed { negatives.ToArrayMessage()}");
            }
            return numbersList;
        }

    }
}
