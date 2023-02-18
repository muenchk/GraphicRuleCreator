using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GraphicRuleCreator
{
    public class Ingredient
    {
        public String name { get; set; } = "";
        public String EditorID { get; set; } = "";
        public UInt32 FormID { get; set; } = 0;
        public String PluginName { get; set; } = "";
        public double Weight { get; set; } = 0;
        public int value { get; set; } = 0;
        public string Effect1 { get; set; } = "";
        public int Duration1 { get; set; } = 0;
        public double Magnitude1 { get; set; } = 0;
        public string Effect2 { get; set; } = "";
        public int Duration2 { get; set; } = 0;
        public double Magnitude2 { get; set; } = 0;
        public string Effect3 { get; set; } = "";
        public int Duration3 { get; set; } = 0;
        public double Magnitude3 { get; set; } = 0;
        public string Effect4 { get; set; } = "";
        public int Duration4 { get; set; } = 0;
        public double Magnitude4 { get; set; } = 0;
        public bool modified { get; set; } = false;

        public string file = "";

        public UInt64 effects { get; set; } = 0;

        public static List<Ingredient> ingredients = new List<Ingredient>();
    }
}
