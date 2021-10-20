using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class RecipePrint : IRecipePrint
    {
        // Cambiado por OCP
        private IList<BaseStep> steps = new List<BaseStep>();

        public Product FinalProduct { get; set; }

               public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (BaseStep step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }

        // Agregado por Expert
        public double GetProductionCost()
        {
            double result = 0;

            foreach (BaseStep step in this.steps)
            {
                result = result + step.GetStepCost();
            }

            return result;
        }
    }
}