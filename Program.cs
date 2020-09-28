using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        enum TemperatureType { CELSIUS, FAHRENHEIT, REAMUR, KELVIN, INVALID }
        static void Main(string[] args)
        {

            Console.WriteLine("Dieses Programm hilft Ihnen beim konvertieren von Temperaturen.\n\n");

            Console.WriteLine("Bitte wählen sie die bekannte Einheit:   (Buchstabe aus Klammer eingeben)\n");
            Console.WriteLine("   [C]elsius");
            Console.WriteLine("   [F]ahrenheit");
            Console.WriteLine("   [R]eamur");
            Console.WriteLine("   [K]elvin\n");

            string input = null;

            while (!IsValidType(input))
            {
                Console.Write("Gewünschte Einheit: ");
                input = Console.ReadLine();
            }

            TemperatureType type = GetType(input);



            string valueInput = null;

            while (!IsValidValue(valueInput))
            {
                valueInput = null;
                Console.WriteLine($"Bitte geben Sie den Wert der umgerechnet werden soll ein [{type}]: ");

                valueInput = Console.ReadLine();

                if (valueInput != null)
                {
                    valueInput.Replace(".", ",");
                    valueInput.Trim();
                    if (!valueInput.Contains(",")) valueInput += ",0";
                }

            }

            double value;

            try
            {
                value = Double.Parse(valueInput);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ihre Eingabe konnte nicht in eine Zahl konvertiert werden.");
                Console.WriteLine(e.Message);

                Console.WriteLine("Starte Programm neu...");

                Main(new string[0]);
                return;
            }


            PrintConversion(value, type);

            Console.WriteLine("Danke, dass sie dieses Programm verwendet haben...");
            Console.ReadLine();
        }

        private static void PrintConversion(double value, TemperatureType type)
        {
            double tempCelsius, tempFahrenheit, tempKelvin, tempReamur;

            switch (type)
            {
                case TemperatureType.CELSIUS:
                    {
                        tempCelsius = value;
                        tempFahrenheit = tempCelsius * 9 / 5 + 32;
                        tempKelvin = tempCelsius - 273.15;
                        tempReamur = tempCelsius / 1.25;
                        break;
                    }
                case TemperatureType.FAHRENHEIT:
                    {
                        tempFahrenheit = value;
                        tempCelsius = (tempFahrenheit - 32) * 5 / 9;
                        tempKelvin = tempCelsius - 273.15;
                        tempReamur = tempCelsius / 1.25;
                        break;
                    }
                case TemperatureType.KELVIN:
                    {
                        tempKelvin = value;
                        tempCelsius = tempKelvin + 273.15;
                        tempFahrenheit = tempCelsius * 9 / 5 + 32;
                        tempReamur = tempCelsius / 1.25;
                        break;
                    }
                case TemperatureType.REAMUR:
                    {
                        tempReamur = value;
                        tempCelsius = tempReamur * 1.25;
                        tempFahrenheit = tempCelsius * 9 / 5 + 32;
                        tempKelvin = tempCelsius - 273.15;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Fehler 404 aufgetreten, Temperatureinheit konnte nicht gefunden werden.");
                        return;
                    }

            }
            Console.WriteLine($"   Celsius: {tempCelsius}\n");
            Console.WriteLine($"Fahrenheit: {tempFahrenheit}\n");
            Console.WriteLine($"    Reamur: {tempReamur}\n");
            Console.WriteLine($"    Kelvin: {tempKelvin}\n");
        }

        private static bool IsValidValue(string value)
        {
            if (value == null) return false;
            return Regex.Match(value, "\\d+.\\d*").Success;
        }

        private static TemperatureType GetType(string input)
        {
            switch (input)
            {
                case "C":
                case "c":
                    return TemperatureType.CELSIUS;
                case "F":
                case "f":
                    return TemperatureType.FAHRENHEIT;
                case "R":
                case "r":
                    return TemperatureType.REAMUR;
                case "K":
                case "k":
                    return TemperatureType.KELVIN;
                default:
                    return TemperatureType.INVALID;
            }
        }

        public static bool IsValidType(string input)
        {
            switch (input)
            {
                case "C":
                case "c":
                case "F":
                case "f":
                case "R":
                case "r":
                case "K":
                case "k":
                    return true;
                default:
                    return false;
            }
        }


    }
}
