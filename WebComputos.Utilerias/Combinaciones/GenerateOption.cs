using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Utilerias.Combinaciones
{
    public enum GenerateOption
    {
        /// <summary>
        /// Do not generate additional sets, typical implementation.
        /// </summary>
        WithoutRepetition,
        /// <summary>
        /// Generate additional sets even if repetition is required.
        /// </summary>
        WithRepetition
    }
}
