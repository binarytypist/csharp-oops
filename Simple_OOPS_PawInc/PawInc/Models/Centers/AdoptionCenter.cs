namespace PawInc.Models.Centers
{
    // AdoptionCenter is responsible for holding animals that are ready for adoption.
    // It inherits common center functionality from BaseCenter.
    public class AdoptionCenter : BaseCenter
    {
        // Constructor passes center name to base class
        public AdoptionCenter(string name) : base(name)
        {
        }

        // Adoption process:
        // Removes animals that have been marked as cleansed (ready for adoption)
        public void Adopt()
        {
            this.Animals.RemoveAll(a => a.CleansingStatus == true);
        }
    }
}