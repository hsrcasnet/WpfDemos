using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DependencyProperties
{
  public class BetterTextLabel:TextLabel
  {
    static BetterTextLabel()
    {
      TextLabel.FontSizeProperty.OverrideMetadata(typeof(BetterTextLabel)
                                            , new FrameworkPropertyMetadata
                                            (35.0,
                                            FrameworkPropertyMetadataOptions.AffectsMeasure));
    }

    // Natürlich sollte das BetterTextLabel auch noch
    // etwas Code enthalten, der es tatsächlich zu
    // einem besseren, zumindest umfangreicheren Label macht. 
    // Hier dient es lediglich zur Veranschaulichung, wie Subklassen
    // Metadaten überschreiben können.
  }


}
