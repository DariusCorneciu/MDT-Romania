namespace MDT_Romania.Models
{
    public class CivilianLicence
    {
        public int CivilianId { get; set; }

        public int LicenceId { get; set; }
        public virtual Civilian? Civilian { get; set; }
        public virtual Licence? Licence { get; set; }
    }
}
