using HarmonyLib;
using System.Collections.Generic;
using TUNING;
using System;
using System.Reflection;
namespace ONI_mod
{
    public class Patches
    {

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]

        public class DuplicantStatsPatch
        {   
            public static void Postfix()
            {
                
                var foundTrait = new DUPLICANTSTATS.TraitVal()
                {
                    id = "PH",
                    dlcId = ""
                };
                foreach (var trait in DUPLICANTSTATS.GENESHUFFLERTRAITS)
                {
                    if (trait.id == "RockCrusher")
                    {
                        foundTrait = trait;
                    }

                }
                if (foundTrait.id != "PH")
                {
                    DUPLICANTSTATS.GENESHUFFLERTRAITS.Remove(foundTrait);
                }

                var addTrait = new DUPLICANTSTATS.TraitVal()
                {
                    id = "RadiationEater",
                    dlcId = "EXPANSION1_ID"
                };
                
                DUPLICANTSTATS.GENESHUFFLERTRAITS.Add(addTrait);
                
            }
            
        }
    }
}
 