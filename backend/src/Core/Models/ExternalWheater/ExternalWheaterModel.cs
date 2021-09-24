namespace Core.Models
{
    public abstract class ExternalWheaterModel
    {
        public abstract bool Valid();
        public abstract double Temperature();
        public abstract double Sensation();
    }
}
