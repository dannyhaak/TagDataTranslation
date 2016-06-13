using System;
using System.Collections;
using System.Collections.Generic;

using TagDataTranslation;

using NLog;

namespace TagDataTranslationDemo
{
    class MainClass
    {
        private static Logger logger = LogManager.GetCurrentClassLogger ();

        public static void Main (string[] args)
        {
            TDTEngine engine = new TDTEngine ();

            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

            List<string> epcIdentifiers = new List<string> ();
            epcIdentifiers.Add (@"gtin=00037000302414;serial=10419703");
            epcIdentifiers.Add (@"gln=0003700030247;serial=1041970");
            epcIdentifiers.Add (@"grai=00037000302414274877906943");
            epcIdentifiers.Add (@"giai=123456789012312345");
            epcIdentifiers.Add (@"generalmanager=5;objectclass=17;serial=23");
            epcIdentifiers.Add (@"cageordodaac=AB123;serial=3789156");

            foreach (string epcIdentifier in epcIdentifiers) {
                logger.Info("Translating {0} to outputFormat BINARY", epcIdentifier);
                string result = engine.BinaryToHex(engine.Translate(epcIdentifier, parameterList, @"BINARY"));
                logger.Info("Result is: {0}", result);

                logger.Info("Translating {0} to outputFormat LEGACY", result);
                string result2 = engine.Translate(engine.HexToBinary(result), parameterList, @"LEGACY");
                logger.Info("Result is: {0}", result2);
            }
        }
    }
}
