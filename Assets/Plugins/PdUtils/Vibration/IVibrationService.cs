namespace PdUtils.Vibration
{
    public interface IVibrationService
    {
        bool Enabled { get; set; }

        void Vibrate();
    }
}