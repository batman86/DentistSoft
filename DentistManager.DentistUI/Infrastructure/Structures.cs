
namespace DentistManager.DentistUI.Infrastructure
{
    public enum seassionNamesList
    {
        SecurtaryActivePatient,
        SecurtaryActiveClinec,
        DoctorActivePatient,
        DoctorActiveClinec
    };
    public enum seassionProbertyNamesList
    {
        ActivePatientID,
        ActiveClinecID
    };

    public enum ImageSize
    {
        large,
        medium,
        small,
        icon
    };

    public enum PatientSchduelStatus
    {
        waiting,
        postponed,
        canceled,
        progress,
        finished
    };

    public enum ImageExtension
    {
        jpeg
    };
}