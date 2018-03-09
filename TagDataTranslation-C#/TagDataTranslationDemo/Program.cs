using System;
using System.Collections.Generic;

using TagDataTranslation;

namespace TagDataTranslationDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TDTEngine engine = new TDTEngine();

            string parameterList = @"filter=3;gs1companyprefixlength=7;taglength=96";

            List<string> epcIdentifiers = new List<string>();
            epcIdentifiers.Add(@"gtin=00037000302414;serial=10419703");
            epcIdentifiers.Add(@"gln=0003700030247;serial=1041970");
            epcIdentifiers.Add(@"grai=00037000302414274877906943");
            epcIdentifiers.Add(@"giai=123456789012312345");
            epcIdentifiers.Add(@"generalmanager=5;objectclass=17;serial=23");
            epcIdentifiers.Add(@"cageordodaac=AB123;serial=3789156");
            epcIdentifiers.Add(engine.HexToBinary(@"3074257bf7194e4000001a85"));

            foreach (string epcIdentifier in epcIdentifiers)
            {
                Console.WriteLine("Translating {0} to outputFormat BINARY", epcIdentifier);
                var result = engine.BinaryToHex(engine.Translate(epcIdentifier, parameterList, @"BINARY"));
                Console.WriteLine("Result is: {0}", result);

                Console.WriteLine("Translating {0} to outputFormat LEGACY", result);
                var result2 = engine.Translate(engine.HexToBinary(result), parameterList, @"LEGACY");
                Console.WriteLine("Result is: {0}", result2);
            }
        }
    }
}
