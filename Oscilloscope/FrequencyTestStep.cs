// Author: MyName
// Copyright:   Copyright 2022 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using OpenTap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Oscilloscope
{
    [Display("Frequency", Group: "Oscilloscope", Description: "Frequency measurement of the signal")]
    public class FrequencyTestStep : TestStep
    {
        #region Settings
        // ToDo: Add property here for each parameter the end user should be able to change
        [Display("Instrument")]
        public scope OSC { get; set; }
        [Display("Channel")]
        public Channel Chan { get; set; }
        #endregion

        public enum Channel
        {
            Channel1,
            Channel2,
            Channel3,
            Channel4
        }
        public FrequencyTestStep()
        {
            // ToDo: Set default values for properties / settings.
            Chan = Channel.Channel1;
        }

        public override void Run()
        {
            //OSC.ScpiCommand("*RST");
            OSC.ScpiCommand("Channel1:Display Off");
            OSC.ScpiCommand($"{Chan}:Display ON");
            string Freq = OSC.ScpiQuery(":MEASure:FREQuency? " + Chan);

            Log.Info(Freq+"Hz");

            float floatFreq = (float)Convert.ToDouble(Freq);
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
    }
}
