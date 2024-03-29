﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace GraphicRuleCreator
{
    public class Effects
    {
        public string name { get; set; } = "";
        public UInt32 FormID { get; set; } = 0;
        public string EditorID { get; set; } = "";
        public string PluginName { get; set; } = "";
        public ActorValue ActorValue { get; set; } = ActorValue.kNone;

        public string ActorValueName { get; set; } = "";
        public Alchem AlchemyEffect { get; set; } = new Alchem(AlchemyBaseEffectFirst.kNone, AlchemyBaseEffectSecond.kNone);
        public string AlchemyEffectName { get; set; } = "";
        public bool Overwrite { get; set; } = false;
        public bool detrimental { get; set; } = false;
        public bool modified { get; set; } = false;

        public string file = "";

        public HashSet<Ingredient> References { get; set; } = new HashSet<Ingredient>();
        public HashSet<Potion> ReferencesPotions { get; set; } = new HashSet<Potion>();

        public static Dictionary<string, Effects> effects = new System.Collections.Generic.Dictionary<string, Effects>();
    }
}
