namespace BookingCare.Shared.Setting
{
    public class CloudStorageSetting
    {
        public string? BucketName { get; set; }
        public string? CredentialPath { get; set; }
        public string DoctorFolder => "static/doctor";
        public string SpecialtyFolder => "static/specialty";
        public string ReceptionistFolder => "static/receptionist";
    }
}
