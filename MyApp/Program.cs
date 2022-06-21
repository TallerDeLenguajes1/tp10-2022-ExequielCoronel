using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tpn10
{
    public class Program {
        static void Main(string[] args)
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                if(strReader == null) return;
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();
                ListaDeCivilizaciones LC = JsonSerializer.Deserialize<ListaDeCivilizaciones>(responseBody);
                System.Console.WriteLine("Listado de Civilizaciones: \n--------------------------------------");
                foreach (var civilizacion in LC.Civilizations)
                {
                    System.Console.WriteLine($"ID: {civilizacion.Id} \n Nombre: {civilizacion.Name} \n Expansion: {civilizacion.Expansion} \n Tipo de Arma: {civilizacion.ArmyType} \n {civilizacion.TeamBonus}\n");
                }
                System.Console.WriteLine("Muestro por pantalla las caracteristicas de una civilizacion Random: \n");
                Random rnd = new Random();
                Civilization CivilizacionRandom = LC.Civilizations[rnd.Next(0,LC.Civilizations.Count)];
                System.Console.WriteLine($"ID: {CivilizacionRandom.Id} \n Nombre: {CivilizacionRandom.Name} \n Expansion: {CivilizacionRandom.Expansion} \n Tipo de Arma: {CivilizacionRandom.ArmyType} \n Bonus: {CivilizacionRandom.TeamBonus}\n");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error");
                throw;
            }
        }     
    } 
}