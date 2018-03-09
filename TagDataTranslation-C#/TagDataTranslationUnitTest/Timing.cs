using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture ()]
    public class Timing
    {
        [Test ()]
        public void Initialisation ()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            TDTEngine engine = new TDTEngine();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Assert.LessOrEqual(ts.TotalMilliseconds, 400);
        }

        [Test ()]
        public void TenThousandTranslations ()
        {
            Stopwatch stopWatch = new Stopwatch ();

            TDTEngine engine = new TDTEngine ();

            List<string> epcIdentifiers = new List<string> ();
            Random rnd = new Random ();
            for (int i = 0; i < 10000; i++) {
                string epcIdentifier = @"gtin=08710966610350;serial=" + rnd.Next (1000000);
                epcIdentifiers.Add (epcIdentifier);
            }

            stopWatch.Start ();

            string parameterList = @"filter=1;gs1companyprefixlength=7;tagLength=96";
            foreach (string epcIdentifier in epcIdentifiers) {
                string resultBinary = engine.Translate(epcIdentifier, parameterList, @"BINARY");
                string resultPureIdentity = engine.Translate(resultBinary, parameterList, @"PURE_IDENTITY");
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Assert.LessOrEqual(ts.TotalMilliseconds, 10000);
        }
    }
}

