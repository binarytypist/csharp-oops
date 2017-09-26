using PawInc.Models.Animals;
using PawInc.Models.Centers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc.Models
{
    // CenterManager acts as the main service layer of the system.
    // It controls all operations between animals and centers:
    // registration, movement, cleansing, castration, and adoption.
    public class CenterManager
    {
        // All registered centers in the system
        private List<AdoptionCenter> adoptionCenters;
        private List<CleansingCenter> cleansingCenters;
        private List<CastrationCenter> castrationCenters;

        // Tracking system statistics
        private List<string> cleansedAnimalNames;
        private List<string> adoptedAnimalNames;
        private List<string> castratedAnimalNames;

        // Constructor initializes all collections
        public CenterManager()
        {
            this.adoptionCenters = new List<AdoptionCenter>();
            this.cleansingCenters = new List<CleansingCenter>();
            this.castrationCenters = new List<CastrationCenter>();

            this.cleansedAnimalNames = new List<string>();
            this.adoptedAnimalNames = new List<string>();
            this.castratedAnimalNames = new List<string>();
        }

        // Registers a cleansing center
        public void RegisterCleansingCenter(string name)
            => this.cleansingCenters.Add(new CleansingCenter(name));

        // Registers an adoption center
        public void RegisterAdoptionCenter(string name)
            => this.adoptionCenters.Add(new AdoptionCenter(name));

        // Registers a castration center
        public void RegisterCastrationCenter(string name)
            => this.castrationCenters.Add(new CastrationCenter(name));

        // Registers a dog into an adoption center
        public void RegisterDog(string name, int age, int commands, string adoptionCenterName)
        {
            var center = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            center.Animals.Add(new Dog(name, age, commands, adoptionCenterName));
        }

        // Registers a cat into an adoption center
        public void RegisterCat(string name, int age, int intelligence, string adoptionCenterName)
        {
            var center = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            center.Animals.Add(new Cat(name, age, intelligence, adoptionCenterName));
        }

        // Moves uncensed animals from adoption center to cleansing center
        public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            var cleansingCenter = this.cleansingCenters.First(c => c.Name == cleansingCenterName);

            var animalsToCleanse = adoptionCenter.Animals
                .Where(a => a.CleansingStatus == false)
                .ToList();

            adoptionCenter.Animals.RemoveAll(a => a.CleansingStatus == false);
            cleansingCenter.Animals.AddRange(animalsToCleanse);
        }

        // Moves uncasterated animals to castration center
        public void SendForCastration(string adoptionCenterName, string castrationCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);
            var castrationCenter = this.castrationCenters.First(c => c.Name == castrationCenterName);

            var animalsToCastrate = adoptionCenter.Animals
                .Where(a => a.CastrationStatus == false)
                .ToList();

            adoptionCenter.Animals.RemoveAll(a => a.CastrationStatus == false);
            castrationCenter.Animals.AddRange(animalsToCastrate);
        }

        // Processes cleansing center and returns animals to adoption centers
        public void Cleanse(string cleansingCenterName)
        {
            var cleansingCenter = this.cleansingCenters.First(c => c.Name == cleansingCenterName);

            var animals = cleansingCenter.Cleanse();

            this.cleansedAnimalNames.AddRange(animals.Select(a => a.Name));

            var adoptionCentersNames = animals.Select(a => a.AdoptionCenterName).Distinct();

            foreach (var name in adoptionCentersNames)
            {
                var center = this.adoptionCenters.First(c => c.Name == name);
                center.Animals.AddRange(animals.Where(a => a.AdoptionCenterName == name));
            }
        }

        // Processes castration center and returns animals to adoption centers
        public void Castrate(string castrationCenterName)
        {
            var castrationCenter = this.castrationCenters.First(c => c.Name == castrationCenterName);

            var animals = castrationCenter.Castrate();

            this.castratedAnimalNames.AddRange(animals.Select(a => a.Name));

            var adoptionCentersNames = animals.Select(a => a.AdoptionCenterName).Distinct();

            foreach (var name in adoptionCentersNames)
            {
                var center = this.adoptionCenters.First(c => c.Name == name);
                center.Animals.AddRange(animals.Where(a => a.AdoptionCenterName == name));
            }
        }

        // Final adoption process (removes cleansed animals)
        public void Adopt(string adoptionCenterName)
        {
            var adoptionCenter = this.adoptionCenters.First(c => c.Name == adoptionCenterName);

            this.adoptedAnimalNames.AddRange(
                adoptionCenter.Animals
                    .Where(a => a.CleansingStatus)
                    .Select(a => a.Name));

            adoptionCenter.Adopt();
        }

        // Prints castration statistics
        public void CastrationStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Paw Inc. Regular Castration Statistics");
            sb.AppendLine($"Castration Centers: {this.castrationCenters.Count}");

            var animals = this.castratedAnimalNames.Count > 0
                ? string.Join(", ", this.castratedAnimalNames.OrderBy(n => n))
                : "None";

            sb.Append($"Castrated Animals: {animals}");

            Console.WriteLine(sb.ToString());
        }

        // System-wide statistics summary
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Paw Incorporative Regular Statistics");
            sb.AppendLine($"Adoption Centers: {this.adoptionCenters.Count}");
            sb.AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}");

            var adopted = this.adoptedAnimalNames.Count > 0
                ? string.Join(", ", this.adoptedAnimalNames.OrderBy(n => n))
                : "None";

            sb.AppendLine($"Adopted Animals: {adopted}");

            var cleansed = this.cleansedAnimalNames.Count > 0
                ? string.Join(", ", this.cleansedAnimalNames.OrderBy(n => n))
                : "None";

            sb.AppendLine($"Cleansed Animals: {cleansed}");

            sb.AppendLine($"Animals Awaiting Adoption: " +
                this.adoptionCenters.Sum(c => c.Animals.Count(a => a.CleansingStatus)));

            sb.AppendLine($"Animals Awaiting Cleansing: " +
                this.cleansingCenters.Sum(c => c.Animals.Count(a => !a.CleansingStatus)));

            return sb.ToString();
        }
    }
}