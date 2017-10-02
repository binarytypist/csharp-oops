namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;

    /// <summary>
    /// Main application controller.
    /// Acts as an orchestration layer between models, repositories, and business logic.
    /// Handles creation, assignment, and reporting operations.
    /// </summary>
    public class Controller : IController
    {
        private readonly List<IAquarium> aquariums = new List<IAquarium>();
        private readonly DecorationRepository decorations = new DecorationRepository();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType)
            };

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                nameof(Plant) => new Plant(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType)
            };

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName)
                ?? throw new InvalidOperationException($"Aquarium {aquariumName} does not exist.");

            var decoration = decorations.FindByType(decorationType)
                ?? throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration, decorationType));

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName)
                ?? throw new InvalidOperationException($"Aquarium {aquariumName} does not exist.");

            IFish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidFishType)
            };

            bool isCompatible =
                (aquarium is FreshwaterAquarium && fish is FreshwaterFish) ||
                (aquarium is SaltwaterAquarium && fish is SaltwaterFish);

            if (!isCompatible)
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName)
                ?? throw new InvalidOperationException($"Aquarium {aquariumName} does not exist.");

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName)
                ?? throw new InvalidOperationException($"Aquarium {aquariumName} does not exist.");

            decimal decorationsValue = aquarium.Decorations.Sum(d => d.Price);
            decimal fishValue = aquarium.Fish.Sum(f => f.Price);

            decimal totalValue = decorationsValue + fishValue;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}