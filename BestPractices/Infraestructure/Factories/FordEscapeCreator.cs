using Best_Practices.ModelBuilders;
using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    // Factory Method para la creación de vehículos Ford Escape
public class FordEscapeCreator : Creator
    {
        public override Vehicle Create()
        {
            var builder = new CarBuilder();

            return builder
                .SetBrand("Ford")
                .SetModel("Escape")
                .SetColor("Red")
                .Build();
        }
    }
}