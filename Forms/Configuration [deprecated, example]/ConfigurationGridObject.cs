using System.ComponentModel;

namespace DeviceManagerGUI
{
	public partial class ConfigurationGridObject
    {
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("R1 in ohms. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Resistances")]
        [DisplayName("R1")]
        public ushort R1 { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("R2 in ohms. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Resistances")]
        [DisplayName("R2")]
        public ushort R2 { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("R3 in ohms. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Resistances")]
        [DisplayName("R3")]
        public ushort R3 { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("R6 in ohms. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Resistances")]
        [DisplayName("R6")]
        public ushort R6 { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("CnA. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Coefficients")]
        [DisplayName("CnA")]
        public double CnA { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("CnB. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Coefficients")]
        [DisplayName("CnB")]
        public double CnB { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("CsA. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Coefficients")]
        [DisplayName("CsA")]
        public double CsA { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("CsB. 0 to ignore. 1 to reset to factory settings.")]
        [Category("Coefficients")]
        [DisplayName("CsB")]
        public double CsB { get; set; }
    }
}
