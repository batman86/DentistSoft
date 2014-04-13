
namespace DentistManager.DentistUI.Infrastructure
{
    public enum seassionNamesList
    {
        SecurtaryActivePatient,
        SecurtaryActiveClinec,
        DoctorActivePatient,
        DoctorActiveClinec,
        DoctorCustomMatrailFilterParamter
    };
    public enum seassionProbertyNamesList
    {
        ActivePatientID,
        ActiveClinecID,
        FilterType
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
        Reserved,      
        waiting,
        InProgress,
        Finished,
        Postponed
    };
    public enum SchduelStatusTimeFilter
    {
        Daily,
        Weekly,
        Monthly
    };
    public enum ImageExtension
    {
        jpeg
    };
}